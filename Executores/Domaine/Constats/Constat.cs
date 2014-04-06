using System;
using System.Collections.Generic;

namespace Executores
{
    public class Constat : Agregat
    {
        public Constat()
        {
            Fichiers = new List<Fichier>();
        }

        public List<Fichier> Fichiers { get; set; } 
    }
}
