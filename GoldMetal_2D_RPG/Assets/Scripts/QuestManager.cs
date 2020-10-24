using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;

    Dictionary<int, QuestDate> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestDate>();
        GenerateDate();
    }

    void GenerateDate()
    {
        questList.Add(10, new QuestDate("마을 사람들과 대화하기",
                                            new int[] { 1000, 2000 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public void QuestCheck()
    {
        questActionIndex++;
    }
}
