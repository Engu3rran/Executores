using Ninject.Modules;

namespace Executores.Entrepots
{
    public abstract class ModuleEntrepot : NinjectModule
    {
        protected void chargerLesEntrepots()
        {
            this.Bind<IEntrepotConstat>().To<EntrepotConstat>();
        }
    }
}
