using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string title;
    public string description;
    public float experienceReward;
    public List<int> itemRewardID;

    public bool isActive;
    public bool isFinished;
    public QuestGoal goal;
}
