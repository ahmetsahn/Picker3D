using System;
using Runtime.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.UISystem
{
    public class UIEventSubscriber : MonoBehaviour
    {
        [SerializeField] private UIEventSubscriptionType subscriptionType;
        
        private Button _button;
        
        private void Awake()
        {
            FindReferences();
        }
        
        private void FindReferences()
        {
            _button = GetComponent<Button>();
        }
        
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
            switch (subscriptionType)
            {
                case UIEventSubscriptionType.Play:
                {
                    _button.onClick.AddListener(UISignals.Instance.onPlayButtonClick.Invoke);
                    break;
                }
                
                case UIEventSubscriptionType.Win:
                {
                    _button.onClick.AddListener(UISignals.Instance.onNextLevelButtonClick.Invoke);
                    break;
                }
                
                case UIEventSubscriptionType.Lose:
                {
                    _button.onClick.AddListener(UISignals.Instance.onRestartButtonClick.Invoke);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void UnsubscribeEvents()
        {
            switch (subscriptionType)
            {
                case UIEventSubscriptionType.Play:
                {
                    _button.onClick.RemoveListener(UISignals.Instance.onPlayButtonClick.Invoke);
                    break;
                }
                
                case UIEventSubscriptionType.Win:
                {
                    _button.onClick.RemoveListener(UISignals.Instance.onNextLevelButtonClick.Invoke);
                    break;
                }
                
                case UIEventSubscriptionType.Lose:
                {
                    _button.onClick.RemoveListener(UISignals.Instance.onRestartButtonClick.Invoke);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}