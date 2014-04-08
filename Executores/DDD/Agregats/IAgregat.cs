using System;

namespace Executores
{
    public interface IAgregat : IEntite
    {
        DateTime? DateCréation { get; }
        DateTime? DateModification { get; }
        DateTime? DateArchivage { get; }
    }
}
