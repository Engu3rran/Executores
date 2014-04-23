using System.Collections.Generic;

namespace Executores.Bus
{
    public class BusCommande : Bus<IMessageCommande,ReponseCommande>
    {

        protected override void chargerLaListeDesInstruction()
        {
            _listeDesInstructions = new List<IInstructionBus>();
        }
    }
}
