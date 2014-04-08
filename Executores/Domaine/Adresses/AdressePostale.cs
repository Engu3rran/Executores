using System.Collections.Generic;

namespace Executores
{
    public class AdressePostale
    {
        public AdressePostale() 
        {
            CodePostal = new CodePostal(null);
        }

        public string Voie { get; set; }
        public string Complément { get; set; }
        public CodePostal CodePostal { get; set; }
        public string Commune { get; set; }

        public void modifier(IAdressePostaleMessage message)
        {
            Voie = message.Voie;
            Complément = message.Complément;
            CodePostal = new CodePostal(message.CodePostal);
            Commune = message.Commune;
        }

        public bool estValide()
        {
            return laVoieEstValide()
                && leComplémentALaBonneLongueur()
                && CodePostal.estValide()
                && laCommuneEstValide();
        }

        private bool laVoieEstValide()
        {
            return laVoieEstRenseignée()
                && laVoieALaBonneLongueur();
        }

        private bool laVoieEstRenseignée()
        {
            return !string.IsNullOrEmpty(Voie);
        }

        private bool laVoieALaBonneLongueur()
        {
            return Voie == null
                || Voie.Length <= VALIDATION.CHAINE_LONGUEUR_MAX;
        }

        private bool leComplémentALaBonneLongueur()
        {
            return Complément == null
                || Complément.Length <= VALIDATION.CHAINE_LONGUEUR_MAX;
        }

        private bool laCommuneEstValide()
        {
            return laCommuneEstRenseignée()
                && laCommuneALaBonneLongueur();
        }

        private bool laCommuneEstRenseignée()
        {
            return !string.IsNullOrEmpty(Commune);
        }

        private bool laCommuneALaBonneLongueur()
        {
            return Commune == null
                || Commune.Length <= VALIDATION.CHAINE_LONGUEUR_MAX;
        }

        public ListeErreurs donnerLesErreurs()
        {
            ListeErreurs erreurs = new ListeErreurs();
            donnerLesErreursDeLaVoie(erreurs);
            donnerLesErreursDuComplément(erreurs);
            erreurs.ajouterUneErreur(CodePostal.donnerLErreur());
            donnerLesErreursDeLaCommune(erreurs);
            return erreurs;
        }

        private void donnerLesErreursDeLaVoie(ListeErreurs erreurs)
        {
            if (!laVoieEstRenseignée())
                erreurs.ajouterUneErreur(VALIDATION.REQUIS_VOIE);
            else if (!laVoieALaBonneLongueur())
                erreurs.ajouterUneErreur(VALIDATION.LONGUEUR_VOIE);
        }

        private void donnerLesErreursDuComplément(ListeErreurs erreurs)
        {
            if (!leComplémentALaBonneLongueur())
                erreurs.ajouterUneErreur(VALIDATION.LONGUEUR_COMPLEMENT);
        }

        private void donnerLesErreursDeLaCommune(ListeErreurs erreurs)
        {
            if (!laCommuneEstRenseignée())
                erreurs.ajouterUneErreur(VALIDATION.REQUIS_COMMUNE);
            else if (!laCommuneALaBonneLongueur())
                erreurs.ajouterUneErreur(VALIDATION.LONGUEUR_COMMUNE);
        }
    }
}
