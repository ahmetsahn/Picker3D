using System.Collections.Generic;
using DG.Tweening;
using Runtime.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.UISystem
{
    public class LevelPanelController : MonoBehaviour
    {
        [SerializeField] private List<Image> stageImages = new List<Image>();
        
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
            UISignals.Instance.onSetStageColor += OnSetStageColor;
        }
        
        private void UnsubscribeEvents()
        {
            UISignals.Instance.onSetStageColor -= OnSetStageColor;
        }
        
        private void OnSetStageColor(int stageID)
        {
            stageImages[stageID].DOColor(new Color(0.9960785f, 0.4196079f, 0.07843138f), 0.5f);
        }
    }
}