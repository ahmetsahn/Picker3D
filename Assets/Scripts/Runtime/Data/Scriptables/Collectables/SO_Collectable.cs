using Runtime.Data.ValueObjects.Collectable;
using UnityEngine;

namespace Runtime.Data.Scriptables.Collectables
{
    [CreateAssetMenu(fileName = "SO_Collectable", menuName = "Scriptable Objects/Collectable", order = 0)]
    public class SO_Collectable : ScriptableObject
    {
        public CollectableForceData CollectableForceData;
    }
}