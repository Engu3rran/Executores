
using System.Collections.Generic;

namespace Executores.Commandes
{
    public class ReponseCommande : IReponseInstructionBus
    {
        public bool Réussite { get; set; }
        public int CodeMessage { get; set; }
        public Dictionary<string,string> ValidationFormulaire { get; set; }

        private static ReponseCommande générer(bool réussite, int codeMessage, Dictionary<string, string> validationFormulaire)
        {
            return new ReponseCommande()
            {
                Réussite = réussite,
                CodeMessage = codeMessage,
                ValidationFormulaire = validationFormulaire
            };
        }

        public static ReponseCommande générerUnSuccès(int codeMessage, Dictionary<string, string> validationFormulaire)
        {
            return générer(true, codeMessage, validationFormulaire);
        }

        public static ReponseCommande générerUnSuccès(int codeMessage)
        {
            return générer(true, codeMessage, null);
        }

        public static ReponseCommande générerUnSuccès()
        {
            return générer(true, 0, null);
        }

        public static ReponseCommande générerUnEchec(int codeMessage, Dictionary<string, string> validationFormulaire)
        {
            return générer(false, codeMessage, validationFormulaire);
        }

        public static ReponseCommande générerUnEchec(int codeMessage)
        {
            return générer(false, codeMessage, null);
        }

    }
}
