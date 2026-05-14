using Microsoft.EntityFrameworkCore;
using ApiFilmes.Data;
using ApiFilmes.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.EnsureCreated();
}

app.MapGet("/", () =>
{
    return "API de Filmes - Minimal API com .NET";
});

app.MapGet("/status", () =>
{
    return Results.Ok(new
    {
        status = "online",
        mensagem = "API funcionando corretamente",
        dataHora = DateTime.Now
    });
});

app.MapGet("/filmes", async (AppDbContext db) =>
{
    var filmes = await db.Filmes.ToListAsync();

    return Results.Ok(filmes);
});

app.MapGet("/filmes/emcartaz", async (AppDbContext db) =>
{
    var filmesEmCartaz = await db.Filmes
        .Where(f => f.EmCartaz)
        .ToListAsync();

    return Results.Ok(filmesEmCartaz);
});

app.MapGet("/filmes/quantidade", async (AppDbContext db) =>
{
    var quantidade = await db.Filmes.CountAsync();

    return Results.Ok(new
    {
        totalFilmes = quantidade
    });
});

app.MapGet("/filmes/busca/{titulo}", async (string titulo, AppDbContext db) =>
{
    var filmes = await db.Filmes
        .Where(f => f.Titulo.Contains(titulo))
        .ToListAsync();

    return Results.Ok(filmes);
});


app.MapGet("/filmes/{id}", async (int id, AppDbContext db) =>
{
    var filme = await db.Filmes.FindAsync(id);

    if (filme is null)
    {
        return Results.NotFound("Filme não encontrado");
    }

    return Results.Ok(filme);
});

app.MapPost("/filmes", async (Filme filme, AppDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(filme.Titulo))
    {
        return Results.BadRequest(new
        {
            erro = "O título é obrigatório"
        });
    }

    if (string.IsNullOrWhiteSpace(filme.Diretor))
    {
        return Results.BadRequest(new
        {
            erro = "O diretor é obrigatório"
        });
    }

    if (filme.DuracaoMinutos <= 0)
    {
        return Results.BadRequest(new
        {
            erro = "A duração deve ser maior que zero"
        });
    }

    await db.Filmes.AddAsync(filme);

    await db.SaveChangesAsync();

    return Results.Created($"/filmes/{filme.Id}", filme);
});


app.MapPut("/filmes/{id}", async (int id, Filme dadosAtualizados, AppDbContext db) =>
{
    var filme = await db.Filmes.FindAsync(id);

    if (filme is null)
    {
        return Results.NotFound(new
        {
            erro = "Filme não encontrado"
        });
    }

    if (string.IsNullOrWhiteSpace(dadosAtualizados.Titulo))
    {
        return Results.BadRequest(new
        {
            erro = "O título é obrigatório"
        });
    }

    if (dadosAtualizados.DuracaoMinutos <= 0)
    {
        return Results.BadRequest(new
        {
            erro = "A duração deve ser maior que zero"
        });
    }

    filme.Titulo = dadosAtualizados.Titulo;
    filme.Diretor = dadosAtualizados.Diretor;
    filme.DuracaoMinutos = dadosAtualizados.DuracaoMinutos;
    filme.EmCartaz = dadosAtualizados.EmCartaz;
    filme.DataLancamento = dadosAtualizados.DataLancamento;

    await db.SaveChangesAsync();

    return Results.Ok(filme);
});

app.MapDelete("/filmes/{id}", async (int id, AppDbContext db) =>
{
    var filme = await db.Filmes.FindAsync(id);

    if (filme is null)
    {
        return Results.NotFound("Filme não encontrado");
    }

    db.Filmes.Remove(filme);

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();