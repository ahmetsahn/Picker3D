using UnityEngine;

namespace Runtime.PlayerSystem
{
    public class PlayerMouseInput : IPlayerInput
    {
        private float _horizontalInput;
        
        private Vector3 _mousePosition;
        
        private readonly float _screenWidthHalf = Screen.width / 2.0f;
        public void ReadInput()
        {
            _mousePosition = Input.mousePosition;
            _horizontalInput = (_mousePosition.x - _screenWidthHalf) / _screenWidthHalf;
        }
        
        public float GetInput()
        {
            return _horizontalInput;
        }
    }
}