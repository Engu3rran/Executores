using System;

namespace Executores
{
    public interface IAgregat
    {
        Guid Id { get; set; }
        DateTime? DateCréation { get; set; }
        DateTime? DateModification { get; set; }
        DateTime? DateSuppression { get; set; }
    }
}
