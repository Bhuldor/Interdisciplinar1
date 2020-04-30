using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : CharacterStatus
{
    private float actualExp;
    private float nextLevelExp;
    private int level;

    public PlayerStatus(float atk, float def, float spd, float hp, float actualExp, float nextLevelExp, int lvl) : base(atk, def, spd, hp)
    {
        attack = atk;
        defense = def;
        speed = spd;
        hitPoints = hp;
        this.actualExp = actualExp;
        this.nextLevelExp = nextLevelExp;
        this.level = lvl;
    }

    public void levelUp(){
        level++;
        hitPoints += 5;
    }

    public void levelUpAttribute(int whichAtt){
        //whichAtt representa a escolha do atributo ao player passar de nível
        //0 - Attack
        //1 - Defense
        //2 - Speed
        switch (whichAtt){
            case 0:
                attack++;
                break;
            case 1:
                defense++;
                break;
            case 2:
                speed++;
                break;
        }
    }
}
