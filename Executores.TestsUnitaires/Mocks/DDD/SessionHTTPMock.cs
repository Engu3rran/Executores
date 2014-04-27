using System;

namespace Executores.TestsUnitaires
{
    public class SessionHTTPMock : ISessionHTTP
    {
        public SessionHTTPMock()
        {
            Id = Guid.NewGuid();
            DateDeConnexion = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime DateDeConnexion { get; set; }
    }
}
