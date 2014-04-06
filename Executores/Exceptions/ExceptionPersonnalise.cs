using System;

namespace Executores
{
    public abstract class ExceptionPersonnalise : Exception
    {
        protected Exception _exceptionEncapsulée;
        protected string _message;

        public ExceptionPersonnalise(string message)
        {
            _message = message;
        }

        public ExceptionPersonnalise(Exception e)
        {
            _exceptionEncapsulée = e;
        }

        protected abstract string donnerLeTitre();

        public override string Message
        {
            get
            {
                string message = _message ?? _exceptionEncapsulée.Message;
                return string.Concat(donnerLeTitre(), message);
            }
        }
    }
}
