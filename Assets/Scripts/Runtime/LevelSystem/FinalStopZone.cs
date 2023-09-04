using Runtime.Interfaces;
using Runtime.Signals;
using Runtime.UISystem;
using UnityEngine;

namespace Runtime.LevelSystem
{
    public class FinalStopZone : MonoBehaviour,IInteractableWithPlayer
    {
        public void Interact()
        {
            PlayerSignals.Instance.onPlayerCanMove?.Invoke(false);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.WinPanel, 1);
        }
    }
}