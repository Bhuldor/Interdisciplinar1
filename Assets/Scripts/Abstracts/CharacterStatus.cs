using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStatus : Status
{
    protected float hitPoints;
    public CharacterStatus(float atk, float def, float spd, float hp) : base(atk, def, spd)
    {
        attack = atk;
        defense = def;
        speed = spd;
        hitPoints = hp;
    }

    public float getHp() { return hitPoints; }

    public void setHp(float hp) { this.hitPoints = hp; }
}
