
namespace Executores
{
    public class Utilisateur : Agregat<Utilisateur>
    {
        public Utilisateur(IEntrepotPersistance entrepot) : base(entrepot)
        {

        }

        public AdresseEmail AdresseEmail { get; set; }
        public MotDePasse MotDePasse { get; set; }
        public Civilite Civilité { get; set; }
        public Nom Nom { get; set; }
        public Prenom Prénom { get; set; }
        public Cabinet Cabinet { get; set; }

        public override bool estValide()
        {
            throw new System.NotImplementedException();
        }

        public override ListeErreurs donnerLesErreurs()
        {
            throw new System.NotImplementedException();
        }
    }
}
