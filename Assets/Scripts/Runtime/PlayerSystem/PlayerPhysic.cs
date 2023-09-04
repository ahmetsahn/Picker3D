using Runtime.CollectablesSystem;
using Runtime.Interfaces;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.PlayerSystem
{
    public class PlayerPhysic : MonoBehaviour
    {
        [SerializeField] private Transform overlapSphereTransform;
        
        private const float OVERLAP_SPHERE_RADIUS = 2f;
        
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
            PlayerSignals.Instance.onDetectThrowCollectables += OnDetectThrowCollectables;
        }
        
        private void UnsubscribeEvents()
        {
            PlayerSignals.Instance.onDetectThrowCollectables -= OnDetectThrowCollectables;
        }

        
        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractableWithPlayer interactableObject))
            {
                interactableObject.Interact();
            }
        }
        
        private void OnDetectThrowCollectables()
        {
            var collectablesToBeThrown = Physics.OverlapSphere(overlapSphereTransform.position, OVERLAP_SPHERE_RADIUS);
            
            foreach (var collectableCollider in collectablesToBeThrown)
            {
                if (collectableCollider.TryGetComponent(out CollectableManager collectableObject))
                {
                    collectableObject.SetTrueCanThrow();
                }
            }
        }
    }
}