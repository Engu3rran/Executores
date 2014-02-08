using System;
using Executores.Entrepots;

namespace Executores.Commandes
{
    public class CreerConstatCommande : Commande<ICreerConstatMessageCommande>
    {
        public override ReponseCommande exécuter(ICreerConstatMessageCommande message)
        {
            IEntrepotConstat entrepotConstat = FabriqueEntrepot.construire<IEntrepotConstat>();
            Constat constat = new Constat();
            if (entrepotConstat.ajouter(constat))
            {
                return ReponseCommande.générerUnSuccès(
                    CodeMessageBus.SUCCES_CREATION_CONSTAT,
                    _Validation
                        .ajouterLIdGénéré(constat.Id.ToString())
                        .exporter());
            }
            return ReponseCommande.générerUnEchec(CodeMessageBus.ERREUR_ENREGISTREMENT_ENTREPOT);
        }
    }
}
