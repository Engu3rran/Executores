
namespace Executores
{
    public interface IClientEntrepriseMessage
    {
        string Id { get; }
        int Civilité { get; }
        string Nom { get; }
        string Prénom { get; }
        string AdresseEmail { get; }
        string Téléphone { get; }
        string IdEntreprise { get; }
    }
}
