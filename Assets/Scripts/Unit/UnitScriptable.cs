using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitScriptable : ScriptableObject
{
    public abstract void Initialize(UnitController unit);
}
