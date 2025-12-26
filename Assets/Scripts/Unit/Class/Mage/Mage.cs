using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mage", menuName = "Unit/Mage")]
public class Mage : UnitScriptable
{
    public Sprite sprite;
    public int level;
    public float maxHp;
    public float hp;
    public float maxMp;
    public float mp;

    public override void Initialize(UnitController unit)
    {
        unit.spriteRenderer.sprite = sprite;
    }
}
