using Runtime.Signals;
using UnityEngine;

namespace Runtime.UISystem
{
    public class UIManager : MonoBehaviour
    {
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
            UISignals.Instance.onPlayButtonClick += Play;
            UISignals.Instance.onNextLevelButtonClick += NextLevel;
            UISignals.Instance.onRestartButtonClick += RestartLevel;
        }
        
        private void UnsubscribeEvents()
        {
            UISignals.Instance.onPlayButtonClick -= Play;
            UISignals.Instance.onNextLevelButtonClick -= NextLevel;
            UISignals.Instance.onRestartButtonClick -= RestartLevel;
        }

        private void Play()
        {
            UISignals.Instance.onClosePanel?.Invoke(1);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.LevelPanel, 0);
            PlayerSignals.Instance.onPlayerCanMove?.Invoke(true);
            CoreGameSignals.Instance.onGameStart?.Invoke();
            CameraSignals.Instance.onSetCameraTarget?.Invoke();
        }

        private void NextLevel()
        {
            LevelSignals.Instance.onNextLevel?.Invoke();
        }
        
        private void RestartLevel()
        {
            LevelSignals.Instance.onLevelRestart?.Invoke();
        }
    }
}
