using System.IO;

namespace Executores.Commandes
{
    public interface IAjouterFichierConstatMessageCommande : IMessageCommande
    {
        string IdConstat { get; set; }
        string Nom { get; set; }
        Stream Données { get; set; }
    }
}
