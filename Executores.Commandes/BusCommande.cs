using System.Collections.Generic;
using Executores.Entrepots;

namespace Executores.Commandes
{
    public class BusCommande : Bus<IMessageCommande,ReponseCommande>
    {

        protected override void chargerLaListeDesInstruction()
        {
            _listeDesInstructions = new List<IInstructionBus>();
            _listeDesInstructions.Add(new CreerConstatCommande());
            _listeDesInstructions.Add(new AjouterFichierConstatCommande());
        }

        public static void utiliserMongo()
        {
            FabriqueEntrepot.chargerUnModule(new ModuleEntrepotMongo());
        }

        public static void utiliserUnModule(ModuleEntrepot module)
        {
            FabriqueEntrepot.chargerUnModule(module);
        }
    }
}
