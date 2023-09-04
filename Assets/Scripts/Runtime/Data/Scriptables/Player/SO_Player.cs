using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Data.ValueObjects;
using Runtime.Data.ValueObjects.Player;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Player", menuName = "Scriptable Objects/Player", order = 1)]
public class SO_Player : ScriptableObject
{
    public PlayerMovementData PlayerMovementData;
}
