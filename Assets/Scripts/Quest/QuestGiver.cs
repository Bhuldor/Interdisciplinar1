using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    private PlayerStatus player;

    private GameObject questWindow;
    private Text titleText;
    private Text descriptionText;
    private Text goalText;
    private Text rewardText;
    private Button AcceptButton;
    private Text acceptButtonText;
    
    private void Start()
    {
        player = FindObjectOfType<PlayerStatus>();
        questWindow = GameObject.Find("QuestUI");
        titleText = GameObject.Find("QuestTitle").GetComponent<Text>();
        descriptionText = GameObject.Find("QuestDescription").GetComponent<Text>();
        goalText = GameObject.Find("QuestGoal").GetComponent<Text>();
        rewardText = GameObject.Find("QuestReward").GetComponent<Text>();
        AcceptButton = GameObject.Find("QuestAcceptButton").GetComponent<Button>();
        acceptButtonText = GameObject.Find("QuestAcceptButtonText").GetComponent<Text>(); 
    }
    public void OpenQuestWindow()
    {
        if (quest.isFinished)
            return;
        LeanTween.scaleX(questWindow, 1f, 0.5f);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        goalText.text = $"{quest.goal.description} ({quest.goal.currentAmount}/{quest.goal.requiredAmount})";
        rewardText.text = $"Experiência: {quest.experienceReward}.\nItens: Set de armadura de escamas média.";
        if (quest.isActive)
        {
            if (quest.goal.isReached)
            {
                acceptButtonText.text = "Concluir";
                AcceptButton.onClick.AddListener(() => GetRewards());
            }
            else
            {
                acceptButtonText.text = "Continuar";
                AcceptButton.onClick.AddListener(() => CloseWindow());
            }
        }
        else
        {
            acceptButtonText.text = "Aceitar";
            AcceptButton.onClick.AddListener(() => AcceptQuest());
        }
        
    }

    private void AcceptQuest()
    {
        player.setActiveSideQuest(quest);
        quest.isActive = true;
        CloseWindow();
    }
    private void CloseWindow()
    {
        LeanTween.scaleX(questWindow, 0f, 0.5f);
    }

    private void GetRewards()
    {
        player.ObtainExp(quest.experienceReward);
        foreach(int i in quest.itemRewardID)
        {
            Item item = new Item();
            item.Clone(Inventory.instance.GetItemByID(i));
            item.quantity = 1;
            Inventory.instance.ObtainDrop(item);
        }
        
        quest.isFinished = true;
    }


}
