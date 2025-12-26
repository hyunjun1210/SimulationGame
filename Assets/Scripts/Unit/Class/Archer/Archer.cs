using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Archer", menuName = "Unit/Archer")]
public class Archer : UnitScriptable
{
    public Sprite sprite;
    public int level;
    public float maxHp;
    public float hp;

    public override void Initialize(Unit unit)
    {
        unit.spriteRenderer.sprite = sprite;
    }
}
