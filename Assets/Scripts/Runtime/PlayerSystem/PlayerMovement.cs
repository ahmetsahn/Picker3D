using Runtime.Data.ValueObjects.Player;
using UnityEngine;

namespace Runtime.PlayerSystem
{
    public class PlayerMovement
    {
        private float _horizontalSpeed;
        private float _verticalSpeed;
        
        private Vector2 _xClampValue;
        
        private bool _isCanMove;
        
        private readonly PlayerMovementData _playerMovementData;
        
        private readonly Rigidbody _rigidbody;
        
        public PlayerMovement(PlayerMovementData playerMovementData,ref Rigidbody rigidbody)
        {
            _playerMovementData = playerMovementData;
            _rigidbody = rigidbody;
            
            SetPlayerMovementValues();
        }

        private void SetPlayerMovementValues()
        {
            _horizontalSpeed = _playerMovementData.HorizontalSpeed;
            _verticalSpeed = _playerMovementData.VerticalSpeed;
            _xClampValue = _playerMovementData.XClampValue;
        }
        
        public void Move(float horizontalInput)
        {
            if(!_isCanMove) return;
            _rigidbody.velocity = new Vector3(horizontalInput * _horizontalSpeed, _rigidbody.velocity.y, _verticalSpeed) * Time.fixedDeltaTime;
            _rigidbody.position = new Vector3(Mathf.Clamp(_rigidbody.position.x, _xClampValue.x, _xClampValue.y), _rigidbody.position.y, _rigidbody.position.z);
        }
        
        public void SetCanMove(bool isCanMove)
        {
            _isCanMove = isCanMove;
        }
    }
}