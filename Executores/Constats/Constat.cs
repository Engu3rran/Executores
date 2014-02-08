using System;

namespace Executores
{
    public class Constat : IAgregat
    {
        public Constat()
        {
        }

        public Guid Id { get; set; }
        public DateTime? DateCréation { get; set; }
        public DateTime? DateModification { get; set; }
        public DateTime? DateSuppression { get; set; }
    }
}
