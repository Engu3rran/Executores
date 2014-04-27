using System;
using System.Collections.Generic;

namespace Executores
{
    public class SessionUtilisateur : ISessionHTTP
    {
        private IEntrepotSession _sessions = Fabrique.constuire<IEntrepotSession>();

        public SessionUtilisateur()
        {
            Id = Guid.NewGuid();
            DateDeConnexion = DateTime.Now;
            Type = TypeUtilisateur.Anonyme;
        }

        public Guid Id { get; set; }
        public DateTime DateDeConnexion { get; set; }
        public Guid IdUtilisateur { get; set; }
        public TypeUtilisateur Type { get; set; }

        public void connecter()
        {
            _sessions.enregistrerLaSession<SessionUtilisateur>(this);
        }

        public void déconnecter()
        {
            _sessions.supprimerLaSession<SessionUtilisateur>(this);
        }

        public bool estUnSuperviseur()
        {
            return Type == TypeUtilisateur.Superviseur;
        }

        public bool estAuthentifié()
        {
            return Type != TypeUtilisateur.Anonyme;
        }

        public static SessionUtilisateur chargerLaSessionEnCours()
        {
            SessionUtilisateur sessionEnCours = Fabrique
                .constuire<IEntrepotSession>()
                .donnerLaSessionEnCours<SessionUtilisateur>();
            if (sessionEnCours != null)
                return sessionEnCours;
            return new SessionUtilisateur();
        }

        public static List<SessionUtilisateur> donnerToutesLesSessions()
        {
            return Fabrique
                .constuire<IEntrepotSession>()
                .donnerLesSessions<SessionUtilisateur>();
        }
    }
}
