using Ninject.Modules;

namespace Executores.TestsUnitaires
{
    class ModuleInjectionTest : NinjectModule
    {
        public override void Load()
        {
            Bind<IEntrepotPersistance>().To<EntrepotPersistanceMock>().InSingletonScope();
            Bind<IEntrepotSession>().To<EntrepotSessionMock>().InSingletonScope();
        }
    }
}
