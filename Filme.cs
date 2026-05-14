namespace ApiFilmes.Models;

public class Filme
{
    public int Id { get; set; }

    public string Titulo { get; set; } = "";

    public string Diretor { get; set; } = "";

    public int DuracaoMinutos { get; set; }

    public bool EmCartaz { get; set; }

    public DateTime DataLancamento { get; set; }
}