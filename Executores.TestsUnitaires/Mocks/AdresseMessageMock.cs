
namespace Executores.TestsUnitaires
{
    public class AdresseMessageMock : IAdressePostaleMessage
    {
        public string Voie { get; set; }
        public string Complément { get; set; }
        public string CodePostal { get; set; }
        public string Commune { get; set; }
    }
}
