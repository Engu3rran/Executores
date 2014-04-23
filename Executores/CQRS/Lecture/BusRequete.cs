using System.Collections.Generic;

namespace Executores.Bus
{
    public class BusRequete : Bus<IMessageRequete, ReponseRequete>
    {
        protected override void chargerLaListeDesInstruction()
        {
            _listeDesInstructions = new List<IInstructionBus>();
        }
    }
}
