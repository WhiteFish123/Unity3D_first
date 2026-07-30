using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance{ get; private set; }
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button continueButton;
    private int dialogueIndex=0;
    private GameObject uiGameObject;
    public List<string>contentList;
    private Action OnDialogueEnd;
    void Awake()
    {
        if(Instance!=null && Instance!=this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance=this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameText=transform.Find("UI/Name").GetComponent<TextMeshProUGUI>();
        contentText=transform.Find("UI/DialogueText").GetComponent<TextMeshProUGUI>();
        continueButton=transform.Find("UI/ContinueButton").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnContinueButtonClick);
        uiGameObject=transform.Find("UI").gameObject;
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Show()
    {
        uiGameObject.SetActive(true);
    }
    public void Show(string name,List<string>content,Action OnDialogueEnd=null)
    {
        nameText.text=name;
        contentList=new List<string>();//清空之前的内容
        dialogueIndex=0;
        contentList.AddRange(content);//添加新的内容
        contentText.text=contentList[0];//显示第一条内容
        Show();
        this.OnDialogueEnd=OnDialogueEnd;
    }
    private void Hide()
    {
       uiGameObject.SetActive(false);
    }
    private void OnContinueButtonClick()
    {
        dialogueIndex++;
        if(dialogueIndex>=contentList.Count)
        {
            OnDialogueEnd?.Invoke();
            Hide();
            return;
        }
        contentText.text=contentList[dialogueIndex];
    }
}
