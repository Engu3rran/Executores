using System;

namespace Executores
{
    public abstract class Client : Agregat<Client>
    {
        public Client() : base() 
        {
            Civilité = Civilite.Mademoiselle;
            Nom = new Nom(null);
            Prénom = new Prenom(null);
            AdresseEmail = new AdresseEmail(null);
            AdresseEmail.rendreFacultatif();
            Téléphone = new NumeroTelephone(null);
        }

        public Civilite Civilité { get; set; }
        public Nom Nom { get; set; }
        public Prenom Prénom { get; set; }
        public AdresseEmail AdresseEmail { get; set; }
        public NumeroTelephone Téléphone { get; set; }
    }
}
