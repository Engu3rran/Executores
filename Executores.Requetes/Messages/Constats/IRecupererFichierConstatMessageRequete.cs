
namespace Executores.Requetes
{
    public interface IRecupererFichierConstatMessageRequete : IMessageRequete
    {
        string IdConstat { get; set; }
        string IdFichier { get; set; }
    }
}
