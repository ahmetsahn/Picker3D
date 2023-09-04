using Runtime.Signals;
using UnityEngine;

namespace Runtime.UISystem
{
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private Transform[] layers;
        
        private const string PANELS_PATH = "Screens/";
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
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
            UISignals.Instance.onCloseAllPanels += OnCloseAllPanels;
        }

        private void OnCloseAllPanels()
        {
            foreach (var layer in layers)
            {
                if (layer.childCount <= 0) return;
#if UNITY_EDITOR
                DestroyImmediate(layer.GetChild(0).gameObject);
#else
                Destroy(layer.GetChild(0).gameObject);
#endif
            }
        }

        private void OnClosePanel(int panelIndex)
        {
            if (layers[panelIndex].childCount <= 0) return;

#if UNITY_EDITOR
            DestroyImmediate(layers[panelIndex].GetChild(0).gameObject);
#else
                Destroy(layers[value].GetChild(0).gameObject);
#endif
        }

        private void UnsubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
        }
        
        private void OnOpenPanel(UIPanelTypes panelType, int panelIndex)
        {
            OnClosePanel(panelIndex);
            Instantiate(Resources.Load<GameObject>(PANELS_PATH + panelType), layers[panelIndex]);
        }
    }
}