using DG.Tweening;
using UnityEngine;

namespace Runtime.CollectablesSystem
{
    public class CollectableMesh
    {
        private readonly MeshRenderer _meshRenderer;
        
        private bool _isInPool;

        public CollectableMesh(ref MeshRenderer meshRenderer)
        {
            _meshRenderer = meshRenderer;
        }
       
        public void OnChangeColor()
        {
            if(!_isInPool) return;
            _meshRenderer.material.DOColor(Color.blue, 0.5f);
        }
        
        public void SetTrueIsInPool()
        {
            _isInPool = true;
        }
    }
}