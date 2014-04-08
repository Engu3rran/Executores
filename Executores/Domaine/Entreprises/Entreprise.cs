using System.Linq;

namespace Executores
{
    public class Entreprise : Agregat<Entreprise>
    {
        private bool? _aUnNuméroSIRETDisponible;

        public Entreprise(IEntrepotPersistance entrepot) : base(entrepot)
        {
            AdressePostale = new AdressePostale();
        }

        public NumeroSIRET NuméroSIRET {get; set;}
        public Denomination Dénomination { get; set; }
        public AdressePostale AdressePostale { get; set; }

        public void modifier(IEntrepriseMessage message)
        {
            NuméroSIRET = new NumeroSIRET(message.NuméroSIRET);
            Dénomination = new Denomination(message.Nom);
            AdressePostale.modifier(message.AdressePostale);
        }

        public override bool estValide()
        {
            vérifierQueLeNuméroSIRETEstDisponible();
            return NuméroSIRET.estValide()
                && aUnNuméroSIRETDisponible()
                && Dénomination.estValide()
                && AdressePostale.estValide();
        }

        protected void vérifierQueLeNuméroSIRETEstDisponible()
        {
            _aUnNuméroSIRETDisponible = !_entrepot
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

        public override ListeErreurs donnerLesErreurs()
        {
            ListeErreurs erreurs = new ListeErreurs();
            erreurs.ajouterUneErreur(NuméroSIRET.donnerLErreur());
            if (!aUnNuméroSIRETDisponible())
                erreurs.ajouterUneErreur(VALIDATION.INDISPONIBLE_NUMERO_SIRET);
            erreurs.ajouterUneErreur(Dénomination.donnerLErreur());
            erreurs.ajouterLesErreurs(AdressePostale.donnerLesErreurs());
            return erreurs;
        }
    }
}
