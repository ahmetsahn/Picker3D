using Runtime.CollectablesSystem;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.PoolSystem
{
    public class PoolPhysic : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out CollectableManager collectable)) return;
            CollectableSignals.Instance.onHitThePool?.Invoke();
            collectable.SetTrueIsInPool();
            Destroy(other.gameObject,1f);
        }
    }
}