using System;

namespace Runtime.Data.ValueObjects.Time
{
    [Serializable]
    public struct InGameCooldownData
    {
        public float StageSuccessControlWaitingTime;
        public float PlayerMovementWaitingTime;
        public float MaterialDefaultWaitingTime;
    }
}