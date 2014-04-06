using System;

namespace Executores
{
    public class InjectionException : ExceptionPersonnalise
    {
        public InjectionException(string message) : base(message) { }

        public InjectionException(Exception e) : base(e) { }

        protected override string donnerLeTitre()
        {
            return "Erreur de configuration de l'injection de dépendance :\n";
        } 
    }
}
