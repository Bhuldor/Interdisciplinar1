
using System.Diagnostics;
using UnityEngine;

public class PlayerStatus : CharacterStatus
{
    private float actualExp;
    private float nextLevelExp;
    private float actualLevelExp;
    private int level;
    private int constitution;
    private int strength;
    private int resistance;
    private int agility;
    private int availablePoints;
    private float burnResistance;
    private float poisonResistance;
    private float paralyseResistance;
    private float fearResistance;

    public delegate void LevelUp();
    public static event LevelUp OnLevelUp;


    public void Start()
    {
        level = 1;
        actualLevelExp = 0;
        nextLevelExp = 100;
        constitution = 1;
        strength = 1;
        resistance = 1;
        agility = 1;
        hitPoints = 25;
        attack = 5;
        defense = 5;
        speed = 5;
    }
    public PlayerStatus(float atk, float def, float spd, float hp, float actualExp, float nextLevelExp, int lvl, int constitution, int strength, 
        int resistance, int agility, int availablePoints, float burnResist, float poisonResist, float paralyseResist, float fearResist) : base(atk, def, spd, hp)
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
        this.burnResistance = burnResist;
        this.poisonResistance = poisonResist;
        this.paralyseResistance = paralyseResist;
        this.fearResistance = fearResist;
        
    }

    public float getActualExp() { return actualExp; }
    public float getNextLevelExp() { return nextLevelExp; }
    public float getActualLevelExp() { return actualLevelExp; }
    public int getLevel() { return level; }
    public int getConstitution() { return constitution; }
    public int getStrength() { return strength; }
    public int getResistance() { return resistance; }
    public int getAgility() { return agility; }
    public int getAvailablePoints() { return availablePoints; }
    public float getBurnResistance() { return burnResistance; }
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
        actualLevelExp = nextLevelExp;
        nextLevelExp = (nextLevelExp * getMultiplier());

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

        OnLevelUp?.Invoke();

        if (actualExp > nextLevelExp)
            ObtainExp(0);
    }


    public void levelUpAttribute(int whichAtt){
        //whichAtt representa a escolha do atributo ao player passar de nível
        //0 - Constitution
        //1 - Strength
        //2 - Resistance
        //3 - Agility
        switch (whichAtt){
            case 0:
                constitution++;
                hitPoints += 5;
                poisonResistance += 2;
                break;
            case 1:
                strength++;
                attack += 3;
                fearResistance += 2;
                break;
            case 2:
                resistance++;
                defense += 2;
                hitPoints += 2;
                burnResistance += 2;
                poisonResistance += 0.5f;
                paralyseResistance += 0.5f;
                fearResistance += 0.5f;
                break;
            case 3:
                agility++;
                speed += 3;
                attack += 1;
                paralyseResistance += 2;
                break;
        }
        availablePoints--;
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

    public float getTotalDefense()
    {
        return defense + PlayerEquipment.instance.GetTotalEquipedDefense();
    }
    public float getTotalHP()
    {
        return hitPoints + PlayerEquipment.instance.GetTotalEquipedHealth();
    }
    public float getTotalAttack()
    {
        return attack + PlayerEquipment.instance.GetTotalEquipedDamage();
    }
    public float getTotalSpeed()
    {
        return speed + PlayerEquipment.instance.GetTotalEquipedSpeed();
    }
    public float getTotalFireResist()
    {
        return burnResistance + PlayerEquipment.instance.GetTotalEquipedBurnResist();
    }
    public float getTotalPoisonResist()
    {
        return poisonResistance + PlayerEquipment.instance.GetTotalEquipedPoisonResist();
    }
    public float getTotalParalyseResist()
    {
        return poisonResistance + PlayerEquipment.instance.GetTotalEquipedParalyseResist();
    }
    public float getTotalFearResist()
    {
        return fearResistance + PlayerEquipment.instance.GetTotalEquipedFearResist();
    }

    private float getMultiplier()
    {
        if (level == 2)
            return 2.2f;
        else if (level == 3)
            return 1.5f;
        else if (level > 3 && level < 17)
            return 1.3f;
        else if (level > 16 && level < 26)
            return 1.2f;
        else
            return 1.1f;
    }
}
