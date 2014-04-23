using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Executores.Bus
{
    public class ValidationFormulaire
    {
        private Dictionary<string, string> _champs;

        public ValidationFormulaire()
        {
            _champs = new Dictionary<string, string>();
        }

        public Dictionary<string, string> exporter()
        {
            return _champs;
        }

        public ValidationFormulaire ajouterLaValidationDUnChamp(string nom, string valeur)
        {
            _champs.Add(nom, valeur);
            return this;
        }

        public ValidationFormulaire ajouterLIdGénéré(string id)
        {
            _champs.Add("Id", id);
            return this;
        }
    }
}
