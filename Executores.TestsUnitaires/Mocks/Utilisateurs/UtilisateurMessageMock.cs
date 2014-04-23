
namespace Executores.TestsUnitaires
{
    public class UtilisateurMessageMock : IUtilisateurMessage
    {
        public string AdresseEmail { get; set; }
        public string MotDePasse { get; set; }
        public int TypeUtilisateur { get; set; }
        public int Civilité { get; set; }
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public string IdCabinet { get; set; }
    }
}
