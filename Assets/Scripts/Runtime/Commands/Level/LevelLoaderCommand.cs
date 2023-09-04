using UnityEngine;

namespace Runtime.Commands.Level
{
    public class LevelLoaderCommand
    {
        private readonly Transform _levelRoot;
        
        private const string LEVEL_PREFAB_PATH = "Prefabs/LevelPrefabs/level ";

        public LevelLoaderCommand(ref Transform levelRoot)
        {
            _levelRoot = levelRoot;
        }

        public void Execute(int levelIndex)
        {
            Object.Instantiate(Resources.Load<GameObject>(LEVEL_PREFAB_PATH + levelIndex), _levelRoot);
        }
    }
}