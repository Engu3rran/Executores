
namespace Executores.TestsUnitaires
{
    public class EntrepriseMessageMock : IEntrepriseMessage
    {
        public string NuméroSIRET { get; set; }
        public string Nom { get; set; }
        public IAdressePostaleMessage AdressePostale { get; set; }
    }
}
