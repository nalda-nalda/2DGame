using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{

    Dictionary<int, string[]> talkData;

    void Awake(){
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        talkData.Add(1000, new string[] {"안녕?","이 곳에 처음 왔구나?"});
        talkData.Add(2000, new string[] {"...","... ...", "이 호수는 정말 아름다워","이 호수에는 비밀이 숨겨져있다고 해."});

        talkData.Add(100, new string[] {"평범한 나무상자다."});
        talkData.Add(200, new string[] {"누군가 사용한 흔적이 있는 책상이다."});
    }

    public string GetTalk(int id,int talkIndex){
        if(talkIndex == talkData[id].Length){
            return null;
        } else {
            return talkData[id][talkIndex];
        }
        
    }
}
