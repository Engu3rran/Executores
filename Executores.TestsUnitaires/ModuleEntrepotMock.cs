using Executores.Entrepots;

namespace Executores.TestsUnitaires
{
    public class ModuleEntrepotMock : ModuleEntrepot
    {
        public override void Load()
        {
            chargerLesEntrepots();
            this.Bind<IFournisseur>().To<FournisseurMock>().InSingletonScope();
        }
    }
}
