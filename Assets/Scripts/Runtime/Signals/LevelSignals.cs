using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Extensions;
using UnityEngine;

public class LevelSignals : MonoSingleton<LevelSignals>
{
    public Action<int> onLevelStart;
    public Action onLevelRestart;
    public Action onStageSuccess;
    public Action onNextLevel;
    public Action onControlStageSuccess;
    public Func<int> onGetCurrentLevelIndex;
    public Func<int> onGetCurrentStageIndex;
}
