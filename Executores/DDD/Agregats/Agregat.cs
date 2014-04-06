using System;

namespace Executores
{
    public class Agregat : IAgregat
    {
        public Guid Id { get; set; }
        public DateTime? DateCréation { get; set; }
        public DateTime? DateModification { get; set; }
        public DateTime? DateArchivage { get; set; }
    }
}
