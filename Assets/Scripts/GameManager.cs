using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public TextMeshProUGUI talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public void Action(GameObject scanObj){
       
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);
       
            talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc){
        string talkData =  talkManager.GetTalk(id, talkIndex);

        if(talkData == null){
            isAction = false;
            talkIndex = 0;
            return;
        }
        if(isNpc){
            talkText.text = talkData;
        } else {
            talkText.text = talkData;
        }
        
        isAction = true;
        talkIndex++;
    }


    // void Update()
    // {
    //     if (isAction && Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         isAction = false;
    //         talkPanel.SetActive(false);
    //     }
    // }
}
