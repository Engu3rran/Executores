using System;

namespace Executores
{
    public class PersistanceException : ExceptionPersonnalise
    {
        public PersistanceException(string message) : base(message) { }

        public PersistanceException(Exception e) : base(e) { }

        protected override string donnerLeTitre()
        {
            return "Erreur de persistance :\n";
        }
    }
}
