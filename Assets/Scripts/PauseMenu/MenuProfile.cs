using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuProfile : MonoBehaviour
{
    [SerializeField] private PlayerStatus player;
    [SerializeField] private Text availablePointsText;
    [SerializeField] private Text attributes;
    [SerializeField] private GameObject ButtonCon;
    [SerializeField] private GameObject ButtonStr;
    [SerializeField] private GameObject ButtonRes;
    [SerializeField] private GameObject ButtonAgl;

    [SerializeField] private Text level;
    [SerializeField] private Text expNeeded;
    [SerializeField] private Text health;
    [SerializeField] private Text damage;
    [SerializeField] private Text defense;
    [SerializeField] private Text speed;
    [SerializeField] private Text burnResist;
    [SerializeField] private Text poisonResist;
    [SerializeField] private Text paralyseResist;
    [SerializeField] private Text fearResist;

    [SerializeField] private LevelUpBar levelUpbar;

    [SerializeField] private GameObject attention, attention2;

    private int availablePoints = 0;
    private bool verify = true;
    private void Start()
    {
        PlayerStatus.OnLevelUp += getAvailablePoints;
    }
    private void Update()
    {
        if (verify)
        {
            if (availablePoints > 0)
            {
                attention.SetActive(true);
                attention2.SetActive(true);
            }
            if (availablePoints == 0)
            {
                attention.SetActive(false);
                attention2.SetActive(false);
                verify = false;
            }
        }
    }
    public void OpenProfile()
    {
        availablePoints = player.getAvailablePoints();
        availablePointsText.text = $"Pontos disponiveis: {availablePoints}";
        attributes.text = $"Constituição: {player.getConstitution()} \n\nForça: {player.getStrength()} \n\nResistência: {player.getResistance()} \n\nAgilidade: {player.getAgility()}";
        
        level.text = $"Level {player.getLevel()}";
        int exp = Convert.ToInt32(player.getNextLevelExp() - player.getActualExp());
        expNeeded.text = $"Exp necessária: {exp}";
        health.text = $"Vida: {player.getTotalHP()} ( +{PlayerEquipment.instance.GetTotalEquipedHealth()} )";
        damage.text = $"Ataque: {player.getTotalAttack()} ( +{PlayerEquipment.instance.GetTotalEquipedDamage()} )";
        defense.text = $"Defesa: {player.getTotalDefense()} ( +{PlayerEquipment.instance.GetTotalEquipedDefense()} )";
        speed.text = $"Velocidade: {player.getTotalSpeed()} ( +{PlayerEquipment.instance.GetTotalEquipedSpeed()} )";
        var resist = player.getTotalFireResist();
        if (resist > 100)
            resist = 100;
        burnResist.text = $"Resistência ao fogo: {resist}% ( +{PlayerEquipment.instance.GetTotalEquipedBurnResist()} )";
        resist = player.getTotalPoisonResist();
        if (resist > 100)
            resist = 100;
        poisonResist.text = $"Resistência ao veneno: {resist}% ( +{PlayerEquipment.instance.GetTotalEquipedPoisonResist()} )";
        resist = player.getTotalParalyseResist();
        if (resist > 100)
            resist = 100;
        paralyseResist.text = $"Resistência a paralisação: {resist}% ( +{PlayerEquipment.instance.GetTotalEquipedParalyseResist()} )";
        resist = player.getTotalFearResist();
        if (resist > 100)
            resist = 100;
        fearResist.text = $"Resistência ao medo: {resist}% ( +{PlayerEquipment.instance.GetTotalEquipedFearResist()} )";
        levelUpbar.SetNewLevel(player.getActualLevelExp(), player.getNextLevelExp());
        levelUpbar.SetExpValue(player.getActualExp());

        if(availablePoints > 0)
        {
            ButtonCon.SetActive(true);
            ButtonRes.SetActive(true);
            ButtonStr.SetActive(true);
            ButtonAgl.SetActive(true);
        }
        else
        {
            ButtonCon.SetActive(false);
            ButtonRes.SetActive(false);
            ButtonStr.SetActive(false);
            ButtonAgl.SetActive(false);
        }
    }

    public void UpAtribbute(int attribute)
    {
        player.levelUpAttribute(attribute);
        OpenProfile();
    }

    public void getAvailablePoints()
    {
        availablePoints = player.getAvailablePoints();
        verify = true;
    }
    private void OnDestroy()
    {
        PlayerStatus.OnLevelUp -= getAvailablePoints;
    }
}
