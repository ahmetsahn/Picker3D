using Runtime.Data.ValueObjects.Collectable;
using UnityEngine;

namespace Runtime.CollectablesSystem
{
    public class CollectableMovement
    {
        private readonly CollectableForceData _collectableForceData;
        
        private readonly Rigidbody _rigidbody;
        
        private float _upForceValue;
        private float _forwardForceValue;
        
        private bool _isCanThrow;
        
        public CollectableMovement(ref CollectableForceData collectableForceData, ref Rigidbody rigidbody)
        {
            _collectableForceData = collectableForceData;
            _rigidbody = rigidbody;
            
            SetCollectableMovementValues();
        }
        
        private void SetCollectableMovementValues()
        {
            _upForceValue = _collectableForceData.UpForceValue;
            _forwardForceValue = _collectableForceData.ForwardForceValue;
        }

        public void Throw()
        {
            if(!_isCanThrow) return;
            _rigidbody.AddForce(Vector3.up * _upForceValue, ForceMode.Impulse);
            _rigidbody.AddForce(Vector3.forward * _forwardForceValue, ForceMode.Impulse);
        }
        
        public void SetTrueCanThrow()
        {
            _isCanThrow = true;
        }
    }
}