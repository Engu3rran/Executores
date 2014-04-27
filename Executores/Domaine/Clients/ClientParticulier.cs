
namespace Executores
{
    public class ClientParticulier : Client
    {
        public ClientParticulier() : base() 
        {
            AdressePostale = new AdressePostale();
        }

        public AdressePostale AdressePostale { get; set; }

        public override bool estValide()
        {
            return Nom.estValide()
                && Prénom.estValide()
                && AdresseEmail.estValide()
                && AdressePostale.estValide()
                && Téléphone.estValide();
        }

        public override ListeMessagesValidation donnerLesMessagesDeValidation()
        {
            ListeMessagesValidation messages = new ListeMessagesValidation();
            messages.ajouterUneErreur(Nom.donnerLErreur());
            messages.ajouterUneErreur(Prénom.donnerLErreur());
            messages.ajouterUneErreur(AdresseEmail.donnerLErreur());
            messages.ajouterUneErreur(Téléphone.donnerLErreur());
            messages.ajouterLesErreurs(AdressePostale.donnerLesMessagesDeValidation());
            return messages;
        }

        public void modifier(IClientParticulierMessage message)
        {
            Civilité = (Civilite)message.Civilité;
            Nom = new Nom(message.Nom);
            Prénom = new Prenom(message.Prénom);
            AdresseEmail = new AdresseEmail(message.AdresseEmail);
            Téléphone = new NumeroTelephone(message.Téléphone);
            AdressePostale.modifier(message.AdressePostale);
        }

        public static ClientParticulier créer(IClientParticulierMessage message)
        {
            ClientParticulier client = new ClientParticulier();
            client.modifier(message);
            return client;
        }
    }
}
