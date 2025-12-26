using UnityEngine;

public enum UnitClassType
{
    Warrior, //근거리
    Archer,  //원거리
    Mage,    //마법
}

public abstract class UnitSkillScriptable : ScriptableObject
{
    public abstract void Activity(UnitController unit);
}
