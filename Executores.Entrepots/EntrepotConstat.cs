
using System;

namespace Executores.Entrepots
{
    public class EntrepotConstat : Entrepot<Constat>, IEntrepotConstat
    {
        public EntrepotConstat(IEntrepotPersistance fournisseur) : base(fournisseur)
        {
        }
    }
}
