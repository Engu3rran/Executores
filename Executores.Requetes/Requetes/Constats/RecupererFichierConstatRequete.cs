
using System;

namespace Executores.Requetes
{
    public class RecupererFichierConstatRequete : Requete<IRecupererFichierConstatMessageRequete>
    {
        private Guid idConstat;
        private Guid idFichier;

        public override ReponseRequete exécuter(IRecupererFichierConstatMessageRequete message)
        {
            throw new System.NotImplementedException();
        }
    }
}
