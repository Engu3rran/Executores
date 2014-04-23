
namespace Executores.Bus
{
    public class ReponseRequete : IReponseInstructionBus
    {
        public bool Réussite { get; set; }
        public int CodeMessage { get; set; }
        public object Résultat { get; set; }

        private static ReponseRequete générer(bool réussite, int codeMessage, object résultat)
        {
            return new ReponseRequete()
            {
                Réussite = réussite,
                CodeMessage = codeMessage,
                Résultat = résultat
            };
        }

        public static ReponseRequete générerUnSuccès(int codeMessage, object résultat)
        {
            return générer(true, codeMessage, résultat);
        }

        public static ReponseRequete générerUnSuccès(object résultat)
        {
            return générer(true, 0, résultat);
        }

        public static ReponseRequete générerUnSuccès()
        {
            return générer(true, 0, null);
        }

        public static ReponseRequete générerUnEchec(int codeMessage, object résultat)
        {
            return générer(false, codeMessage, résultat);
        }

        public static ReponseRequete générerUnEchec(int codeMessage)
        {
            return générer(false, codeMessage, null);
        }
    }
}
