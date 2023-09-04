using Runtime.Data.ValueObjects.Time;
using UnityEngine;

namespace Runtime.Data.Scriptables.Time
{
    [CreateAssetMenu(fileName = "SO_Time", menuName = "Scriptable Objects/Time", order = 0)]
    public class SO_Time : ScriptableObject
    {
        public InGameCooldownData InGameCooldownData;
    }
}