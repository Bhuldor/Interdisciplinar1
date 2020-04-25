using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    protected float attack; 
    protected float defense; 
    protected float speed; 

    public Status(float atk, float def, float spd){
        attack = atk;
        defense = def;
        speed = spd;
    }

    public float getAttack(){return attack;}
    public float getDefense(){return defense;}
    public float getSpeed(){return speed;}

    public void setAttack(float atk){this.attack = atk;}
    public void setDefense(float def){this.defense = def;}
    public void setSpeed(float spd){this.speed = spd;}
}
