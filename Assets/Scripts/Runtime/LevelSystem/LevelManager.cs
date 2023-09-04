using System;
using Runtime.Commands.Level;
using Runtime.Data.ValueObjects.Level;
using Runtime.Signals;
using Runtime.UISystem;
using UnityEngine;

namespace Runtime.LevelSystem
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform levelRoot;
        
        private LevelData _levelData;
        
        private int _currentLevelIndex;
        private int _currentStageIndex; 
            
        private LevelLoaderCommand _levelLoaderCommand;
        private LevelDestroyerCommand _levelDestroyerCommand;

        private void Awake()
        {
            Init();
        }
        
        private void Init()
        {
            _levelLoaderCommand = new LevelLoaderCommand(ref levelRoot);
            _levelDestroyerCommand = new LevelDestroyerCommand(ref levelRoot);
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }
        
        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            LevelSignals.Instance.onLevelStart += _levelLoaderCommand.Execute;
            LevelSignals.Instance.onNextLevel += _levelDestroyerCommand.Execute;
            LevelSignals.Instance.onNextLevel += OnNextLevel;
            LevelSignals.Instance.onLevelRestart += _levelDestroyerCommand.Execute;
            LevelSignals.Instance.onLevelRestart += OnLevelRestart;
            LevelSignals.Instance.onStageSuccess += OnStageSuccess;
            LevelSignals.Instance.onGetCurrentLevelIndex += OnGetCurrentLevelIndex;
            LevelSignals.Instance.onGetCurrentStageIndex += OnGetCurrentStageIndex;
        }
        
        private void UnsubscribeEvents()
        {
            LevelSignals.Instance.onLevelStart -= _levelLoaderCommand.Execute;
            LevelSignals.Instance.onNextLevel -= _levelDestroyerCommand.Execute;
            LevelSignals.Instance.onNextLevel -= OnNextLevel;
            LevelSignals.Instance.onLevelRestart -= _levelDestroyerCommand.Execute;
            LevelSignals.Instance.onLevelRestart -= OnLevelRestart;
            LevelSignals.Instance.onStageSuccess -= OnStageSuccess;
            LevelSignals.Instance.onGetCurrentLevelIndex -= OnGetCurrentLevelIndex;
            LevelSignals.Instance.onGetCurrentStageIndex -= OnGetCurrentStageIndex;
        }

        private void OnNextLevel()
        {
            _currentStageIndex = 0;
            _currentLevelIndex++;
            UISignals.Instance.onClosePanel?.Invoke(0);
            CoreGameSignals.Instance.onGameRestart?.Invoke();
            LevelSignals.Instance.onLevelStart?.Invoke(_currentLevelIndex);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.StartPanel, 1);
        }
        
        private void OnLevelRestart()
        {
            _currentStageIndex = 0;
            UISignals.Instance.onClosePanel?.Invoke(0);
            CoreGameSignals.Instance.onGameRestart?.Invoke();
            LevelSignals.Instance.onLevelStart?.Invoke(_currentLevelIndex);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.StartPanel, 1);
        }

        private void Start()
        {
            LevelSignals.Instance.onLevelStart?.Invoke(_currentLevelIndex);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.StartPanel, 1);
        }
        
        private void OnStageSuccess()
        {
            _currentStageIndex++;
        }
        
        private int OnGetCurrentLevelIndex()
        {
            return _currentLevelIndex;
        }
        
        private int OnGetCurrentStageIndex()
        {
            return _currentStageIndex;
        }
    }
}