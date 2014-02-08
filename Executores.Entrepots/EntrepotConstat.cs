
using System;

namespace Executores.Entrepots
{
    public class EntrepotConstat : Entrepot<Constat>, IEntrepotConstat
    {
        public EntrepotConstat(IFournisseur fournisseur) : base(fournisseur)
        {
        }
    }
}
