using System;

namespace Executores
{
    public class Constat : Agregat<Constat>
    {
        public Client Client { get; set; }
        public Utilisateur Huissier { get; set; }
        public Utilisateur Créateur { get; set; }
    }
}
