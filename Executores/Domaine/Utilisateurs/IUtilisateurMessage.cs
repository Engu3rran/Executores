
namespace Executores
{
    public interface IUtilisateurMessage
    {
        string AdresseEmail { get; }
        string MotDePasse { get; }
        int Civilité { get; }
        string Nom { get; }
        string Prénom { get; }
        string IdCabinet { get; }
    }
}
