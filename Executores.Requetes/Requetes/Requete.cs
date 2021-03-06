﻿using System;

namespace Executores.Requetes
{
    public abstract class Requete<T> : IInstructionBus, IInstructionBus<T,ReponseRequete> where T : IMessageRequete
    {
        public abstract ReponseRequete exécuter(T message);

        public Type TypeDuMessage { get { return typeof (T); } }
    }
}
