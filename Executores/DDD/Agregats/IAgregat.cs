using System;

namespace Executores
{
    public interface IAgregat : IEntite, IEnregistrable
    {
        DateTime? DateCréation { get; }
        DateTime? DateModification { get; }
        DateTime? DateArchivage { get; }
    }
}
