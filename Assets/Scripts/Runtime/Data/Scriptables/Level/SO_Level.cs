using System.Collections.Generic;
using Runtime.Data.ValueObjects.Level;
using UnityEngine;

namespace Runtime.Data.Scriptables.Level
{
    [CreateAssetMenu(fileName = "SO_Level", menuName = "Scriptable Objects/Level", order = 0)]
    public class SO_Level : ScriptableObject
    {
        public List<LevelData> LevelDatas;
        public PoolMaterialData PoolMaterialData;
    }
}