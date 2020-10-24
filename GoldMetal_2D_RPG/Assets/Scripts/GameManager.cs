using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager quesetManger;
    public GameObject talkPanel;
    public Text talkText;
    public Image portraitimage;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public void Action(GameObject scanobj)
    {
            isAction = true;
            scanObject = scanobj;
            ObjDate objDate = scanObject.GetComponent<ObjDate>();
            Talk(objDate.id, objDate.isNpc);

            talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = quesetManger.GetQuestTalkIndex(id);
        string talkDate = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        if(talkDate == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(quesetManger.QuestCheck(id));
            return;
        }


        if (isNpc)
        {
            talkText.text = talkDate.Split(':')[0]; //Split() : 구분자를 통해서 배열로 나눠주는 문자열 함수


            portraitimage.sprite = talkManager.GetPortrait(id, int.Parse(talkDate.Split(':')[1]));
                                                // talkManager 스크립트에서 GetPortrail함수를 불러오고 두개의 값을 집어 넣어줌
                                                // Parse에 대한 이해가 필요 => 문자열을 해당 타입으로 변환해주는 함수
                                                // Split[] 배열에 있는 숫자값이 ':'인자를 기준으로 0이 왼쪽, 1이 오른쪽의 값
            portraitimage.color = new Color(1, 1, 1, 1);
            // 확인결과 NPC라면서 제일마지막 알파값(투명도가) 1이되게해서 눈에 보이게 만들면됨
        }
        else
        {
            talkText.text = talkDate;
            portraitimage.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }
}
