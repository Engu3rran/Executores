using System;
using System.Collections.Generic;
using System.Linq;

namespace Executores.TestsUnitaires
{
    class EntrepotSessionMock : IEntrepotSession
    {
        private Dictionary<Type, ISessionHTTP> _sessionsEnCours = new Dictionary<Type, ISessionHTTP>();
        private Dictionary<Type, List<ISessionHTTP>> _sessions = new Dictionary<Type,List<ISessionHTTP>>();

        public List<T> donnerLesSessions<T>() where T : ISessionHTTP
        {
            List<ISessionHTTP> listeDeSessions = _sessions[typeof(T)];
            List<T> listeConvertie = new List<T>();
            foreach (ISessionHTTP session in listeDeSessions)
                listeConvertie.Add((T)session);
            return listeConvertie;
        }

        public void enregistrerLaSession<T>(T session) where T : ISessionHTTP
        {
            List<ISessionHTTP> sessions = supprimerLaSessionActuelle<T>(session);
            sessions.Add(session);
            _sessionsEnCours.Add(typeof(T), session);
        }

        public void supprimerLaSession<T>(T session) where T : ISessionHTTP
        {
            supprimerLaSessionActuelle<T>(session);
        }

        private List<ISessionHTTP> supprimerLaSessionActuelle<T>(T session) where T : ISessionHTTP
        {
            if (!_sessions.ContainsKey(typeof(T)))
                _sessions.Add(typeof(T), new List<ISessionHTTP>());
            List<ISessionHTTP> sessions = _sessions[typeof(T)];
            ISessionHTTP sessionAModifier = sessions.SingleOrDefault(x => x.Id == session.Id);
            if (sessionAModifier != null)
                sessions.Remove(sessionAModifier);
            if (_sessionsEnCours.ContainsKey(typeof(T)))
                _sessionsEnCours.Remove(typeof(T));
            return sessions;
        }

        public T donnerLaSessionEnCours<T>() where T : ISessionHTTP
        {
            if(_sessionsEnCours.ContainsKey(typeof(T)))
                return (T)_sessionsEnCours[typeof(T)];
            return default(T);
        }
    }
}
