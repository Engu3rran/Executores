using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Executores
{
    public abstract class Bus<T, K> where T : IMessageBus where K : IReponseInstructionBus
    {
        public Bus()
        {
            chargerLaListeDesInstruction();
        }

        protected List<IInstructionBus> _listeDesInstructions;

        protected abstract void chargerLaListeDesInstruction();

        public K exécuter(T message)
        {
            Type typeDuMessage = trouverLeTypeDuMessage(message);
            if (typeDuMessage != null)
                return exécuterLInstruction(message, typeDuMessage);
            return créerUneRéponse(false, CodeMessageBus.ERREUR_TYPE_MESSAGE_BUS);
        }

        private K exécuterLInstruction(T message, Type typeDuMessage)
        {
            try
            {
                object instructionAssociéeAuMessage = _listeDesInstructions.Single(instruction => instruction.TypeDuMessage == typeDuMessage);
                string nomDeLaMéthodeDExécution = typeof(IInstructionBus<T,K>).GetMethods().FirstOrDefault().Name;
                MethodInfo methodInfo = instructionAssociéeAuMessage.GetType().GetMethod(nomDeLaMéthodeDExécution);
                object[] paramètres = new object[] { message };
                return (K)methodInfo.Invoke(instructionAssociéeAuMessage, paramètres);
            }
            catch (Exception)
            {
                //TODO : log
                return créerUneRéponse(false, CodeMessageBus.ERREUR_EXECUTION_BUS);
            }
        }

        protected Type trouverLeTypeDuMessage(IMessageBus message)
        {
            Type[] interfaces = message.GetType().GetInterfaces();
            return interfaces.FirstOrDefault(x => _listeDesInstructions.Any(instruction => instruction.TypeDuMessage == x ));
        }

        protected K créerUneRéponse(bool réussite, int codeMessage)
        {
            K réponse = (K)Activator.CreateInstance(typeof(K));
            réponse.Réussite = réussite;
            réponse.CodeMessage = codeMessage;
            return réponse;
        }
    }
}
