using Runtime.PlayerSystem;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.CameraSystem
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _playerManager;
        
        private Vector3 _offset;
        private Vector3 _firstPosition;
        
        
        private void OnEnable()
        {
            SubscribeEvents();
        }
        
        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void Start()
        {
            SetFirstPosition();
        }

        private void SetFirstPosition()
        {
            _firstPosition = transform.position;
        }
        private void SubscribeEvents()
        {
            CameraSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
            CoreGameSignals.Instance.onGameRestart += OnGameRestart;
        }
        
        private void UnsubscribeEvents()
        {
            CameraSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
            CoreGameSignals.Instance.onGameRestart -= OnGameRestart;
        }
        
        private void OnSetCameraTarget()
        {
            _playerManager = FindObjectOfType<PlayerManager>().transform;
            
            SetOffset();
        }

        private void SetOffset()
        {
            _offset = transform.position - _playerManager.position;
        }

        private void OnGameRestart()
        {
            transform.position = _firstPosition;
        }
        
        private void LateUpdate()
        {
            FollowPlayer();
        }

        private void FollowPlayer()
        {
            if (_playerManager == null) return;

            var newPosition = transform.position;
            newPosition.x = 0;

            var targetPosition = _playerManager.position + _offset;
            targetPosition.x = newPosition.x;

            transform.position = targetPosition;
        }
    }
}