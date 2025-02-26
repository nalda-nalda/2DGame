using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject talkPanel;
    public TextMeshProUGUI talkText;
    public GameObject scanObject;
    public bool isAction;


    public void Action(GameObject scanObj){
     
    
        if (isAction) {
            isAction = false;
            talkPanel.SetActive(false);
        } 
        else {
            isAction = true;
            talkPanel.SetActive(true);
            scanObject = scanObj;
            talkText.text = "이것의 이름은 " + scanObject.name + "라고 한다.";
            
        }
    }


    void Update()
    {
        if (isAction && Input.GetKeyDown(KeyCode.Escape))
        {
            isAction = false;
            talkPanel.SetActive(false);
        }
    }
    }
