using System;

namespace Executores
{
    public interface ISessionHTTP
    {
        Guid Id { get; }
        DateTime DateDeConnexion { get; }
    }
}
