using Ninject;

namespace Executores.Entrepots
{
    public class FabriqueEntrepot
    {
        private IKernel _injecteur;

        private FabriqueEntrepot(ModuleEntrepot module)
        {
            _injecteur = new StandardKernel(module);
        }

        private T résoudre<T>() where T : IEntrepot
        {
            return _injecteur.Get<T>();
        }

        private static FabriqueEntrepot _fabriqueCourante = new FabriqueEntrepot(new ModuleEntrepotMongo());

        public static void chargerUnModule(ModuleEntrepot module)
        {
            _fabriqueCourante = new FabriqueEntrepot(module);
        }

        public static T construire<T>() where T : IEntrepot
        {
            return _fabriqueCourante.résoudre<T>();
        }
    }
}
