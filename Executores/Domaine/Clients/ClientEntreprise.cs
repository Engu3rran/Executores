
namespace Executores
{
    public class ClientEntreprise : Client
    {
        public ClientEntreprise() : base()
        {
            Entreprise = new Entreprise();
        }

        public Entreprise Entreprise { get; set; }

        public override bool estValide()
        {
            return Nom.estValide()
                && Prénom.estValide()
                && AdresseEmail.estValide()
                && Téléphone.estValide()
                && Entreprise.estValide();
        }

        public override ListeMessagesValidation donnerLesMessagesDeValidation()
        {
            ListeMessagesValidation messages = new ListeMessagesValidation();
            messages.ajouterUneErreur(Nom.donnerLErreur());
            messages.ajouterUneErreur(Prénom.donnerLErreur());
            messages.ajouterUneErreur(AdresseEmail.donnerLErreur());
            messages.ajouterUneErreur(Téléphone.donnerLErreur());
            messages.ajouterLesErreurs(Entreprise.donnerLesMessagesDeValidation());
            return messages;
        }

        public void modifier(IClientEntrepriseMessage message)
        {
            Civilité = (Civilite)message.Civilité;
            Nom = new Nom(message.Nom);
            Prénom = new Prenom(message.Prénom);
            AdresseEmail = new AdresseEmail(message.AdresseEmail);
            Téléphone = new NumeroTelephone(message.Téléphone);
            Entreprise = Entreprise.charger(message.IdEntreprise);
        }

        public static ClientEntreprise créer(IClientEntrepriseMessage message)
        {
            ClientEntreprise client = new ClientEntreprise();
            client.modifier(message);
            return client;
        }
    }
}
