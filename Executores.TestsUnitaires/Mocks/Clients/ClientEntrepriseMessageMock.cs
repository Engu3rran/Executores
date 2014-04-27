
namespace Executores.TestsUnitaires
{
    public class ClientEntrepriseMessageMock : IClientEntrepriseMessage
    {
        public string Id { get; set; }
        public int Civilité { get; set; }
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public string AdresseEmail { get; set; }
        public string Téléphone { get; set; }
        public string IdEntreprise { get; set; }
    }
}
