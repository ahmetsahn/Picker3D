using System;
using Runtime.Extensions;
using UnityEngine;

namespace Runtime.Signals
{
    public class CameraSignals : MonoSingleton<CameraSignals>
    {
        public Action onSetCameraTarget;
    }
}