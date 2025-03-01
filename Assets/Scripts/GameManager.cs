using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public Animator talkPanel;
    public Animator portraitAnim;
    public TypeEffect talk;
    public Image portraitImg;
    public TextMeshProUGUI questTalk;
    public GameObject menuSet;
    public GameObject scanObject;
    public GameObject player;
    public bool isAction;
    public int talkIndex;
    public Sprite prevPortait;

    void Start()
    {
        GameLoad();
        questTalk.text = questManager.CheckQuest();
    }

    void Update()
    {
        
        if(Input.GetButtonDown("Cancel")){
            if(menuSet.activeSelf){
                menuSet.SetActive(false);
            }else {
                menuSet.SetActive(true);
            }
        }
    }
    public void Action(GameObject scanObj)
    {

        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = 0;
        string talkData = "";

        if(talk.isAnim){
            talk.SetMsg("");
            return;
        } else{
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        }

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questTalk.text = questManager.CheckQuest(id);
            return;
        }
        if (isNpc)
        {
            talk.SetMsg(talkData.Split(":")[0]);

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(":")[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
            if (prevPortait != portraitImg.sprite)
            {
                portraitAnim.SetTrigger("doEffect");
                prevPortait = portraitImg.sprite;
            }
        }
        else
        {
            talk.SetMsg(talkData);
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
        
    }

    public void GameSave(){
        PlayerPrefs.SetFloat("PlayerX",player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY",player.transform.position.y);
        PlayerPrefs.SetInt("QuestId",questManager.questId);
        PlayerPrefs.SetInt("QusetActionIndex",questManager.questActionIndex);
        PlayerPrefs.Save();

        menuSet.SetActive(false);

    }
    public void GameLoad(){
        if(!PlayerPrefs.HasKey("PlayerX")){
            return;
        }
        
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        player.transform.position = new Vector3(x,y,0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        questManager.ControlObject();
    }
    public void GameExit(){
        Application.Quit();
    }
}
