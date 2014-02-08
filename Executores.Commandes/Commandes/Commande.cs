using System;

namespace Executores.Commandes
{
    public abstract class Commande<T> : IInstructionBus, IInstructionBus<T,ReponseCommande>  where T : IMessageCommande
    {
        protected ValidationFormulaire _Validation = new ValidationFormulaire();

        public abstract ReponseCommande exécuter(T message);

        public Type TypeDuMessage { get { return typeof (T); } }
    }
}
