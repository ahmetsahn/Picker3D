using System;
using System.Threading.Tasks;
using Runtime.Data.Scriptables.Time;
using Runtime.Data.ValueObjects.Time;
using Runtime.Interfaces;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.LevelSystem
{
    public class StageStopZone : MonoBehaviour,IInteractableWithPlayer
    {
        private InGameCooldownData _inGameCooldownData;

        private const string TIME_DATA_PATH = "Data/Time/SO_Time";
        
        private BoxCollider _boxCollider;

        private void Awake()
        {
            GetTimeData();
            FindReferences();
        }
        
        private void FindReferences()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }
        
        private void GetTimeData()
        {
            _inGameCooldownData = Resources.Load<SO_Time>(TIME_DATA_PATH).InGameCooldownData;
        }

        public async void Interact()
        {
            _boxCollider.enabled = false;
            PlayerSignals.Instance.onDetectThrowCollectables?.Invoke();
            PlayerSignals.Instance.onPlayerCanMove?.Invoke(false);
            CollectableSignals.Instance.onThrowCollectables?.Invoke();
            
            await Task.Delay(TimeSpan.FromSeconds(_inGameCooldownData.StageSuccessControlWaitingTime));
            
            LevelSignals.Instance.onControlStageSuccess?.Invoke();
        }
    }
}