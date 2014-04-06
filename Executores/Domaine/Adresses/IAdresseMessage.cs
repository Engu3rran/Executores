
namespace Executores
{
    public interface IAdressePostaleMessage
    {
        string Voie { get; }
        string Complément { get; }
        string CodePostal { get; }
        string Commune { get; }
    }
}
