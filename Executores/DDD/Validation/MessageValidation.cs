
namespace Executores
{
    public class MessageValidation : ObjetValeur
    {
        public MessageValidation(string code) : base(code) { }

        public MessageValidation(string code, string messageParDéfaut) : base(code)
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
