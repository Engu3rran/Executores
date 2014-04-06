using System.Linq;

namespace Executores
{
    public class Entreprise : Agregat<Entreprise>
    {
        private bool? _aUnNuméroSIRETDisponible;

        public Entreprise(IEntrepotPersistance entrepot) : base(entrepot)
        {
            NuméroSIRET = new NumeroSIRET();
            AdressePostale = new AdressePostale();
        }

        public NumeroSIRET NuméroSIRET {get; set;}
        public string Nom { get; set; }
        public AdressePostale AdressePostale { get; set; }

        public void modifier(IEntrepriseMessage message)
        {
            NuméroSIRET = new NumeroSIRET(message.NuméroSIRET);
            Nom = message.Nom;
            AdressePostale.modifier(message.AdressePostale);
        }

        public bool estValide()
        {
            return NuméroSIRET.estValide()
                && aUnNuméroSIRETDisponible()
                && leNomEstValide()
                && AdressePostale.estValide();
        }

        protected void vérifierQueLeNuméroSIRETEstDisponible()
        {
            _aUnNuméroSIRETDisponible = _entrepot
                .prendreLaCollection<Entreprise>()
                .Any(x => 
                    x.Id != Id
                    && !x.DateArchivage.HasValue
                    && x.NuméroSIRET == NuméroSIRET
                );
        }

        protected bool aUnNuméroSIRETDisponible()
        {
            return _aUnNuméroSIRETDisponible == null
                || _aUnNuméroSIRETDisponible.Value;
        }

        protected bool leNomEstValide()
        {
            return leNomEstRenseigné()
                && leNomALaBonneLongueur();
        }

        protected bool leNomEstRenseigné()
        {
            return !string.IsNullOrEmpty(Nom);
        }

        protected bool leNomALaBonneLongueur()
        {
            return Nom == null
                || Nom.Length <= VALIDATION.CHAINE_LONGUEUR_MAX;
        }

        public ListeErreurs donnerLesErreurs()
        {
            ListeErreurs erreurs = new ListeErreurs();
            return erreurs;
        }
    }
}
