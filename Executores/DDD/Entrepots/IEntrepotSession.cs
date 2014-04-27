using System.Collections.Generic;

namespace Executores
{
    public interface IEntrepotSession
    {
        List<T> donnerLesSessions<T>() where T : ISessionHTTP;
        void enregistrerLaSession<T>(T session) where T : ISessionHTTP;
        void supprimerLaSession<T>(T session) where T : ISessionHTTP;
        T donnerLaSessionEnCours<T>() where T : ISessionHTTP;
    }
}
