
namespace Executores
{
    public interface IEntrepriseMessage
    {
        string NuméroSIRET { get; }
        string Nom { get; }
        IAdressePostaleMessage AdressePostale { get; }
    }
}
