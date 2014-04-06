
using System.Collections.Generic;
using Executores.Entrepots;

namespace Executores.Requetes
{
    public class BusRequete : Bus<IMessageRequete, ReponseRequete>
    {
        protected override void chargerLaListeDesInstruction()
        {
            _listeDesInstructions = new List<IInstructionBus>();
            _listeDesInstructions.Add(new ChargerConstatRequete());
            _listeDesInstructions.Add(new RecupererFichierConstatRequete());
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
