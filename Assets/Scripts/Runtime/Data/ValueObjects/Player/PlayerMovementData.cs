using System;
using UnityEngine;

namespace Runtime.Data.ValueObjects.Player
{
    [Serializable]
    public struct PlayerMovementData
    {
        public float HorizontalSpeed;
        public float VerticalSpeed;
        public Vector2 XClampValue;
    }
}