using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;


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
        questList.Add(20, new QuestDate("루도의 동전 찾아주기",
                                            new int[] { 5000, 2000 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string QuestCheck(int id)
    {
        
        if(id == questList[questId].npcId[questActionIndex])
        questActionIndex++;

        //Control QuestObject
        ControlObject();

        if (questActionIndex == questList[questId].npcId.Length){
            NextQuest();
        }

        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if(questActionIndex == 2)
                {
                    questObject[0].SetActive(true);
                }
                    

                break;
            case 20:
                if(questActionIndex == 1)
                {
                    questObject[0].SetActive(false);
                }

                break;
        }
    }
}
