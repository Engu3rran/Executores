
namespace Executores
{
    public interface IClientParticulierMessage
    {
        string Id { get; }
        int Civilité { get; }
        string Nom { get; }
        string Prénom { get; }
        string AdresseEmail { get; }
        string Téléphone { get; }
        IAdressePostaleMessage AdressePostale { get; }
    }
}
