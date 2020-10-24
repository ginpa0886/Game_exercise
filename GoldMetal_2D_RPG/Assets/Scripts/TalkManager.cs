using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkDate;
    Dictionary<int, Sprite> portraitDate;

    public Sprite[] portraitArr;

    void Awake()
    {
        talkDate = new Dictionary<int, string[]>();
        portraitDate = new Dictionary<int, Sprite>();
        GenerateDate();
    }

    void GenerateDate()
    {
        talkDate.Add(1000, new string[] { "안녕 ? :0", " 너 이곳에 처음 왔구나? :1" });
        talkDate.Add(2000, new string[] { "여어:1", "이 호수는 아름답지?:0", "이 호수에는 비밀이 숨겨져 있다고해:1" }); //말문자 뒤에 :숫자 는 portrait에 index 의미를 갖고 있는 형태로 써 존재

        talkDate.Add(100, new string[] { "평범한 나무 상자다. " });
        talkDate.Add(200, new string[] { "누군가 사용했던 흔적이 있는 책상이다. " });

            portraitDate.Add(1000 + 0, portraitArr[0]);
            portraitDate.Add(1000 + 1, portraitArr[1]);
            portraitDate.Add(1000 + 2, portraitArr[2]);
            portraitDate.Add(1000 + 3, portraitArr[3]);
            portraitDate.Add(2000 + 0, portraitArr[4]);
            portraitDate.Add(2000 + 1, portraitArr[5]);
            portraitDate.Add(2000 + 2, portraitArr[6]);
            portraitDate.Add(2000 + 3, portraitArr[7]);

        //Quest talk
        talkDate.Add(10 + 1000, new string[] { "어서와 : 0",
                                               "이 마을에 놀라운 전설이 있다는데 :1",
                                               "오른쪽 호수에 루도가 알려줄꺼야 :0"});
        talkDate.Add(11 + 2000, new string[] { "여어. : 0", 
                                               "이 호수에 전설을 들으러 온거야? :1", 
                                               "그럼 일 좀 하나 해주면 좋겠는데....:0", 
                                               "내 집 근처에 떨어진 동전 좀 주워줬으면 해 :1"});


    }

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex == talkDate[id].Length){
            return null;
        }else{
            return talkDate[id][talkIndex];
        }
        
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {

        return portraitDate[id + portraitIndex];
    }
}
