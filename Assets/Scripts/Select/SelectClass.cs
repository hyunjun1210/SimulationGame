using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectClass : MonoBehaviour
{
    public UnitScriptable archer;
    public UnitScriptable warrior;
    public UnitScriptable mage;
    public void Archer()
    {
        UnitManager.Instance.unitClassType = UnitClassType.Archer;
        UnitManager.Instance.unit = archer;
        MapManager.Instance.SceneLoad(1);
    }

    public void Warrior()
    {
        UnitManager.Instance.unitClassType = UnitClassType.Warrior;
        UnitManager.Instance.unit = warrior;
        MapManager.Instance.SceneLoad(1);
    }

    public void Mage()
    {
        UnitManager.Instance.unitClassType = UnitClassType.Mage;
        UnitManager.Instance.unit = mage;
        MapManager.Instance.SceneLoad(1);
    }
}
