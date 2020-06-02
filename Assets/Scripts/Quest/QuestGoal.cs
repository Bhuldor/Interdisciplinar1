using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public string description;
    public bool isReached;
    public int currentAmount = 0;
    public int requiredAmount = 0;
    public string enemyTag;


    public bool isComplete()
    {
        if (currentAmount >= requiredAmount)
        {
            isReached = true;
            return true;
        }
        return false;
    }

    public void EnemyKilled(string tag)
    {
        if(tag == enemyTag)
        {
            currentAmount++;
            isComplete();
        }
    }
}
