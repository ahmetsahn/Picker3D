using System;
using Runtime.Extensions;
using Runtime.UISystem;
using UnityEngine;

namespace Runtime.Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public Action<UIPanelTypes, int> onOpenPanel;
        public Action<int> onClosePanel;
        public Action onCloseAllPanels;
        public Action<int> onSetStageColor;
        public Action onPlayButtonClick;
        public Action onRestartButtonClick;
        public Action onNextLevelButtonClick;
    }
}