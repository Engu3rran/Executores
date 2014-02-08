using System.Collections.Generic;

namespace Executores.TestsUnitaires.Domaine.Bus
{
    class BusMock : Bus<IMessageBusTest, ReponseBusMock>
    {
        protected override void chargerLaListeDesInstruction()
        {
            _listeDesInstructions = new List<IInstructionBus>();
            _listeDesInstructions.Add(new InstructionMock());
        }
    }
}
