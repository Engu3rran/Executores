using System.Collections;
using System.Collections.Generic;

namespace Executores
{
    public class ListeErreurs : IEnumerable<Erreur>
    {
        private List<Erreur> _erreurs = new List<Erreur>();

        public void ajouterUneErreur(Erreur uneErreur)
        {
            if (uneErreur != null)
                _erreurs.Add(uneErreur);
        }

        public void ajouterLesErreurs(ListeErreurs listeDesErreurs)
        {
            _erreurs.AddRange(listeDesErreurs._erreurs);
        }

        public IEnumerator<Erreur> GetEnumerator()
        {
            return _erreurs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _erreurs.GetEnumerator();
        }
    }
}
