using System;
using Ninject;
using Ninject.Modules;

namespace Executores
{
    public class Fabrique
    {
        private static IKernel _noyau;

        public static T constuire<T>()
        {
            try
            {
                return _noyau.Get<T>();
            }
            catch (Exception e)
            {
                throw new InjectionException(e);
            }
        }

        public static void configurerLInjectionDeDépendance(NinjectModule module)
        {
            _noyau = new StandardKernel(module);
        }
    }
}
