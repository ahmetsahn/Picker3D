using System;
using Runtime.CollectablesSystem;
using Runtime.Extensions;
using UnityEngine;

namespace Runtime.Signals
{
    public class CollectableSignals : MonoSingleton<CollectableSignals>
    {
        public Action onThrowCollectables;
        public Action onHitThePool;
    }
}