namespace SistemaColecionador.Domain.Resource;

public static class Message
{
    public const string RequiredName = "O nome do livro é obrigatório.";
    public const string NameMaximumCharacters = "O nome do livro não pode ter mais que 150 caracteres.";
    public const string RequiredYear = "O ano de publicação é obrigatório.";
    public const string InvalidYear = "O ano de publicação deve não deve ultrapassar o ano atual.";
    public const string RequiredAuthor = "O nome do autor é obrigatório.";
    public const string AuthorMaximumCharacters = "O nome do autor não pode ter mais que 100 caracteres.";
    public const string RequiredPublisher = "O nome da editora é obrigatório.";
    public const string PublisherMaximumCharacters = "O nome da editora não pode ter mais que 100 caracteres.";
    public const string IlustratorMaximumCharacters = "O nome do ilustrador não pode ter mais que 100 caracteres.";
    public const string PagesRequired = "O número de páginas é obrigatório.";
    public const string PagesGreaterThanZero = "O número de páginas deve ser maior que zero.";
}