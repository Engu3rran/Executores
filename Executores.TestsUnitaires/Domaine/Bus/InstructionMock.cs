using System;

namespace Executores.TestsUnitaires.Domaine.Bus
{
    class InstructionMock : IInstructionBus<IMessageBusMock, ReponseBusMock>, IInstructionBus
    {
        public ReponseBusMock exécuter(IMessageBusMock message)
        {
            return new ReponseBusMock() {Réussite = true};
        }

        public Type TypeDuMessage { get { return typeof(IMessageBusMock); } }
    }
}
