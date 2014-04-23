using System.Collections;
using System.Collections.Generic;

namespace Executores
{
    public class ListeMessagesValidation : IEnumerable<MessageValidation>
    {
        private List<MessageValidation> _erreurs = new List<MessageValidation>();

        public void ajouterUneErreur(MessageValidation uneErreur)
        {
            if (uneErreur != null)
                _erreurs.Add(uneErreur);
        }

        public void ajouterLesErreurs(ListeMessagesValidation listeDesErreurs)
        {
            _erreurs.AddRange(listeDesErreurs._erreurs);
        }

        public IEnumerator<MessageValidation> GetEnumerator()
        {
            return _erreurs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _erreurs.GetEnumerator();
        }
    }
}
