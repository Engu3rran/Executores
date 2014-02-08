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
        }

        public void utiliserMongo()
        {
            FabriqueEntrepot.chargerUnModule(new ModuleEntrepotMongo());
        }

        public void utiliserUnModule(ModuleEntrepot module)
        {
            FabriqueEntrepot.chargerUnModule(module);
        }
    }
}
