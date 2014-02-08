using Executores.Entrepots;

namespace Executores.TestsUnitaires.Entrepots
{
    class EntrepotMock : Entrepot<AgregatMock>
    {
        public EntrepotMock(IFournisseur fournisseur) : base(fournisseur)
        {
        }
    }
}
