
namespace Executores
{
    public class Erreur : ObjetValeur
    {
        public Erreur(string code) : base(code) { }

        public Erreur(string code, string messageParDéfaut) : base(code)
        {
            MessageParDéfaut = messageParDéfaut;
        }

        public string Code 
        { 
            get
            {
                return _valeur;
            }
        }

        public string MessageParDéfaut { get; private set; }
    }
}
