using System;
using Executores.Entrepots;

namespace Executores.Commandes
{
    public class AjouterFichierConstatCommande : Commande<IAjouterFichierConstatMessageCommande>
    {
        private Guid idConstat;

        public override ReponseCommande exécuter(IAjouterFichierConstatMessageCommande message)
        {
            if (estUnGuidValide(message))
            {
                IEntrepotConstat entrepot = FabriqueEntrepot.construire<IEntrepotConstat>();
                return ajouterLeFichierAuConstat(message, entrepot);
            }
            return ReponseCommande.générerUnEchec(CodeMessageBus.ERREUR_ID_CONSTAT);
        }

        private bool estUnGuidValide(IAjouterFichierConstatMessageCommande message)
        {
            return Guid.TryParse(message.IdConstat, out idConstat);
        }

        private ReponseCommande ajouterLeFichierAuConstat(IAjouterFichierConstatMessageCommande message,
            IEntrepotConstat entrepot)
        {
            Constat constat = entrepot.récupérer(idConstat);
            if (constat != null)
            {
                Fichier fichierAAjouter = Fichier.initialiser(message.Nom, message.Données);
                return validerEtEnregistrerLeConstat(fichierAAjouter, constat, entrepot);
            }
            return ReponseCommande.générerUnEchec(CodeMessageBus.ERREUR_ID_CONSTAT);
        }

        private ReponseCommande validerEtEnregistrerLeConstat(Fichier fichierAAjouter, Constat constat, IEntrepotConstat entrepot)
        {
            if (fichierAAjouter.estValide())
            {
                constat.Fichiers.Add(fichierAAjouter);
                return enregistrerLeConstat(entrepot, constat);
            }
            return ReponseCommande.générerUnEchec(CodeMessageBus.ENREGISTREMENT_FICHIER_IMPOSSIBLE, fichierAAjouter.donnerLesErreurs().exporter());
        }

        private ReponseCommande enregistrerLeConstat(IEntrepotConstat entrepot, Constat constat)
        {
            if (entrepot.modifier(constat))
                return ReponseCommande.générerUnSuccès(CodeMessageBus.SUCCES_AJOUT_FICHIER);
            return ReponseCommande.générerUnEchec(CodeMessageBus.ERREUR_ENREGISTREMENT_ENTREPOT);
        }
    }
}
