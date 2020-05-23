using System;
using UnityEngine;

public class PlayerStatus : CharacterStatus
{
    private float actualExp;
    private float nextLevelExp;
    private int level;
    private int constitution;
    private int strength;
    private int resistance;
    private int agility;
    private int availablePoints;
    private float fireResistance;
    private float poisonResistance;
    private float paralyseResistance;
    private float fearResistance;
    

    public PlayerStatus(float atk, float def, float spd, float hp, float actualExp, float nextLevelExp, int lvl, int constitution, int strength, 
        int resistance, int agility, int availablePoints, float fireResist, float poisonResist, float paralyseResist, float fearResist) : base(atk, def, spd, hp)
    {
        attack = atk;
        defense = def;
        speed = spd;
        hitPoints = hp;
        this.actualExp = actualExp;
        this.nextLevelExp = nextLevelExp;
        this.level = lvl;
        this.constitution = constitution;
        this.strength = strength;
        this.resistance = resistance;
        this.agility = agility;
        this.availablePoints = availablePoints;
        this.fireResistance = fireResist;
        this.poisonResistance = poisonResist;
        this.paralyseResistance = paralyseResist;
        this.fearResistance = fearResist;
    }

    public float getActualExp() { return actualExp; }
    public float getNextLevelExp() { return nextLevelExp; }
    public int getLevel() { return level; }
    public int getConstitution() { return constitution; }
    public int getStrength() { return strength; }
    public int getResistance() { return resistance; }
    public int getAgility() { return agility; }
    public int getAvailablePoints() { return availablePoints; }
    public float getFireResistance() { return fireResistance; }
    public float getPoisonResistance() { return poisonResistance; }
    public float getParalyseResistance() { return paralyseResistance; }
    public float getFearResistance() { return fearResistance; }

    /*
    public void setConstitution(int constitution) { this.constitution = constitution; }
    public void setStrength(int strength) { this.strength = strength; }
    public void setResistance(int resistance) { this.resistance = resistance; }
    public void setAgility(int agility) { this.agility = agility; }
    public void setAvailablePoints(int availablePoints) { this.availablePoints = availablePoints; }
    public void setFireResistance(float fireResistance) { this.fireResistance = fireResistance; }
    public void setPoisonResistance(float poisonResistance) { this.poisonResistance = poisonResistance; }
    public void setParalyseResistance(float paralyseResistance) { this.paralyseResistance = paralyseResistance; }
    public void setFearResistance(float fearResistance) { this.fearResistance = fearResistance; }
    */

    public void levelUp(){
        level++;
        hitPoints += 5;
        nextLevelExp *= 1.5f;

        if (level % 3 == 0)
        {
            attack += 2;
            defense += 2;
            speed += 2;
        }
        else
        {
            attack++;
            defense++;
            speed++;
        }

        if (level % 5 == 0)
            availablePoints += 2;
        else
            availablePoints++; 
    }

    public void levelUpAttribute(int whichAtt){
        //whichAtt representa a escolha do atributo ao player passar de nível
        //0 - Constitution
        //1 - Strength
        //2 - Resistance
        //3 - Agility
        switch (whichAtt){
            case 0:
                hitPoints += 5;
                poisonResistance += 2;
                break;
            case 1:
                attack += 3;
                fearResistance += 2;
                break;
            case 2:
                defense += 2;
                hitPoints += 2;
                fireResistance += 2;
                poisonResistance += 0.5f;
                paralyseResistance += 0.5f;
                fearResistance += 0.5f;
                break;
            case 3:
                speed += 3;
                attack += 1;
                paralyseResistance += 2;
                break;
        }
    }

    public bool ObtainExp(float obtainedExp)
    {
        actualExp += obtainedExp;
        if(actualExp >= nextLevelExp)
        {
            levelUp();
            return true;
        }
        return false;
    }
}
