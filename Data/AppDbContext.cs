using Microsoft.EntityFrameworkCore;
using ApiFilmes.Models;

namespace ApiFilmes.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Filme> Filmes => Set<Filme>();
}