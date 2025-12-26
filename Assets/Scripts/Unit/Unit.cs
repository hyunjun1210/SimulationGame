using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitScriptable unit;
    public UnitSkillScriptable skill;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        unit.Initialize(this);
    }

    public void Activity()
    {
        skill.Activity(this);
    }
}
