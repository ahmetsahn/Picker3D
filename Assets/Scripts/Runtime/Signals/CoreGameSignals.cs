using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Extensions;
using UnityEngine;

public class CoreGameSignals : MonoSingleton<CoreGameSignals>
{
    public Action onGameStart;
    public Action onGameRestart;
   
}
