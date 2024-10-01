namespace SistemaColecionador.Domain.Dto;

public sealed class BookDto
{
    public string? Nome { get; set; }

    public int? Ano { get; set; }

    public string? Autor { get; set; }

    public string? Editora { get; set; }

    public string? Ilustrador { get; set; }

    public int? Paginas { get; set; }
}