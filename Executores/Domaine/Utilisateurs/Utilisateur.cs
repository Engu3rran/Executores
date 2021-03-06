﻿using System.Linq;

namespace Executores
{
    public class Utilisateur : Agregat<Utilisateur>
    {
        public Utilisateur() : base()
        {
            Civilité = Civilite.Mademoiselle;
            Type = TypeUtilisateur.Anonyme;
        }

        public AdresseEmail AdresseEmail { get; set; }
        public MotDePasse MotDePasse { get; set; }
        public Civilite Civilité { get; set; }
        public Nom Nom { get; set; }
        public Prenom Prénom { get; set; }
        public Cabinet Cabinet { get; set; }
        public TypeUtilisateur Type { get; set; }

        public void modifier(IUtilisateurMessage message)
        {
            AdresseEmail = new AdresseEmail(message.AdresseEmail);
            if (doitModifierLeMotDePasse(message))
                MotDePasse = new MotDePasse(message.MotDePasse);
            Type = (TypeUtilisateur)message.TypeUtilisateur;
            Civilité = (Civilite)message.Civilité;
            Nom = new Nom(message.Nom);
            Prénom = new Prenom(message.Prénom);
            if(Type != TypeUtilisateur.Superviseur)
                Cabinet = _entrepot
                .prendreLaCollection<Entreprise>()
                .Where(x => x is Cabinet)
                .Cast<Cabinet>()
                .Single(x => x.Id.ToString() == message.IdCabinet);
        }

        private bool doitModifierLeMotDePasse(IUtilisateurMessage message)
        {
            return !string.IsNullOrEmpty(message.MotDePasse);
        }

        public override bool estValide()
        {
            return AdresseEmail.estValide()
                && MotDePasse.estValide()
                && Nom.estValide()
                && Prénom.estValide()
                && Cabinet.estValide();
        }

        public override ListeMessagesValidation donnerLesMessagesDeValidation()
        {
            ListeMessagesValidation erreurs = new ListeMessagesValidation();
            erreurs.ajouterUneErreur(AdresseEmail.donnerLErreur());
            erreurs.ajouterUneErreur(MotDePasse.donnerLErreur());
            erreurs.ajouterUneErreur(Nom.donnerLErreur());
            erreurs.ajouterUneErreur(Prénom.donnerLErreur());
            erreurs.ajouterLesErreurs(Cabinet.donnerLesMessagesDeValidation());
            return erreurs;
        }

        public static Utilisateur créer(IUtilisateurMessage message)
        {
            Utilisateur nouvelUtilisateur = Fabrique.constuire<Utilisateur>();
            nouvelUtilisateur.modifier(message);
            return nouvelUtilisateur;
        }

        public static bool authentifier(IAuthentificationMessage message)
        {
            AdresseEmail login = new AdresseEmail(message.Login);
            MotDePasse motDePasse = new MotDePasse(message.MotDePasse);
            Utilisateur utilisateur = Fabrique.constuire<IEntrepotPersistance>()
                .prendreLaCollection<Utilisateur>()
                .SingleOrDefault(x =>
                    x.DateArchivage == null
                    && x.AdresseEmail == login
                    && x.MotDePasse == motDePasse);
            if(utilisateur != null)
            {
                SessionUtilisateur session = new SessionUtilisateur();
                session.IdUtilisateur = utilisateur.Id;
                session.Type = utilisateur.Type;
                session.connecter();
                return true;
            }
            return false;
        }
    }
}
