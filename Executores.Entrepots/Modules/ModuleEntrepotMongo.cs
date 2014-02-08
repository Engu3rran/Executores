using Executores.Mongo;

namespace Executores.Entrepots
{
    public class ModuleEntrepotMongo : ModuleEntrepot
    {
        public override void Load()
        {
            chargerLesEntrepots();
            this.Bind<IFournisseur>().To<FournisseurMongo>().InSingletonScope();
        }
    }
}
