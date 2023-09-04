using Runtime.Signals;
using UnityEngine;

namespace Runtime.PoolSystem
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private PoolController[] poolControllers;
        
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
            CollectableSignals.Instance.onHitThePool += OnHitThePool;
            LevelSignals.Instance.onControlStageSuccess += OnControlStageSuccess;
        }
        
        private void UnsubscribeEvents()
        {
            CollectableSignals.Instance.onHitThePool -= OnHitThePool;
            LevelSignals.Instance.onControlStageSuccess -= OnControlStageSuccess;
        }
        
        private void OnHitThePool()
        {
            poolControllers[LevelSignals.Instance.onGetCurrentStageIndex.Invoke()].IncreasePoolScore();
            poolControllers[LevelSignals.Instance.onGetCurrentStageIndex.Invoke()].UpdateScoreText();
        }
        
        private void OnControlStageSuccess()
        {
            poolControllers[LevelSignals.Instance.onGetCurrentStageIndex.Invoke()].OnControlStageSuccess();
        }
    }
}