
namespace Executores.TestsUnitaires.Domaine.Bus
{
    class ReponseBusMock : IReponseInstructionBus
    {
        public bool Réussite { get; set; }
        public int CodeMessage { get; set; }
    }
}
