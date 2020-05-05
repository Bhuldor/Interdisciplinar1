using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterStatus : CharacterStatus
{
    protected float givenExp;
    public MonsterStatus(float atk, float def, float spd, float hp, float gExp) : base(atk, def, spd, hp)
    {
        attack = atk;
        defense = def;
        speed = spd;
        hitPoints = hp;
        givenExp = gExp;
    }

    public float getExp() { return givenExp; }
}
