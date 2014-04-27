
namespace Executores.TestsUnitaires
{
    public class ClientParticulierMessageMock : IClientParticulierMessage
    {
        public string Id { get; set; }
        public int Civilité { get; set; }
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public string AdresseEmail { get; set; }
        public string Téléphone { get; set; }
        public IAdressePostaleMessage AdressePostale { get; set; }
    }
}
