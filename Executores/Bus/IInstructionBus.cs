using System;

namespace Executores
{
    public interface IInstructionBus<T, K> where T : IMessageBus where K : IReponseInstructionBus
    {
        K exécuter(T message);
    }

    public interface IInstructionBus
    {
        Type TypeDuMessage { get; }
    }
}
