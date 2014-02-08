using System;
using Executores.Entrepots;

namespace Executores.Requetes
{
    public class ChargerConstatRequete : Requete<IChargerConstatMessageRequete>
    {
        public override ReponseRequete exécuter(IChargerConstatMessageRequete message)
        {
            if (aUnIdConstatRenseigné(message))
                return obtenirLeConstat(message);
            return ReponseRequete.générerUnEchec(CodeMessageBus.ID_CONSTAT_MANQUANT);
        }

        private bool aUnIdConstatRenseigné(IChargerConstatMessageRequete message)
        {
            return !string.IsNullOrEmpty(message.IdConstat);
        }

        private ReponseRequete obtenirLeConstat(IChargerConstatMessageRequete message)
        {
            Guid idConstat;
            if (!Guid.TryParse(message.IdConstat, out idConstat))
                return ReponseRequete.générerUnEchec(CodeMessageBus.ERREUR_ID_CONSTAT);
            Constat constat = FabriqueEntrepot.construire<IEntrepotConstat>().récupérer(idConstat);
            if (constat != null)
                return ReponseRequete.générerUnSuccès(constat);
            return ReponseRequete.générerUnEchec(CodeMessageBus.ERREUR_ID_CONSTAT);
        }
    }
}
