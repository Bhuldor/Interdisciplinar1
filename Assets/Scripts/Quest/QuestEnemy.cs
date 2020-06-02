using UnityEngine;

public class QuestEnemy : MonoBehaviour
{
    [SerializeField] private QuestGiver questGiver;
    [SerializeField] private bool openQuestPanelAtDeath = false;
    public bool testDestroy = false;


    private void OnDestroy()
    {
        questGiver.quest.goal.EnemyKilled(this.gameObject.tag);
        if (openQuestPanelAtDeath)
            questGiver.OpenQuestWindow();
    }

    private void Update()
    {
        if (testDestroy)
            Destroy(this.gameObject);
    }
}
