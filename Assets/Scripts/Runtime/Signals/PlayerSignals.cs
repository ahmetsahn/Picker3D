using System;
using Runtime.Extensions;
using UnityEngine;

namespace Runtime.Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public Action<bool> onPlayerCanMove;
        public Action onDetectThrowCollectables;
    }
}