using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Warrior", menuName = "Unit/Warrior")]
public class Warrior : UnitScriptable
{
    public Sprite sprite;
    public int level;
    public float maxHp;
    public float hp;

    public override void Initialize(UnitController unit)
    {
        unit.spriteRenderer.sprite = sprite;
    }
}
