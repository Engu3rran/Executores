using System;

namespace Executores.TestsUnitaires
{
    class AgregatMock : IAgregat
    {
        public AgregatMock()
        {
        }

        public Guid Id { get; set; }
        public DateTime? DateCréation { get; set; }
        public DateTime? DateModification { get; set; }
        public DateTime? DateArchivage { get; set; }
    }
}
