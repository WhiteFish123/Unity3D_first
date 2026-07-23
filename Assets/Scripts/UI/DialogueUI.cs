using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance{ get; private set; }
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button continueButton;
    private int dialogueIndex=0;
    public List<string>contentList;
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
        nameText=transform.Find("Name").GetComponent<TextMeshProUGUI>();
        contentText=transform.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        continueButton=transform.Find("ContinueButton").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnContinueButtonClick);
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Show(string name,List<string>content)
    {
        nameText.text=name;
        contentList=new List<string>();//清空之前的内容
        dialogueIndex=0;
        contentList.AddRange(content);//添加新的内容
        contentText.text=contentList[0];//显示第一条内容
        Show();

    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void OnContinueButtonClick()
    {
        dialogueIndex++;
        if(dialogueIndex>=contentList.Count)
        {
            Hide();
            return;
        }
        contentText.text=contentList[dialogueIndex];
    }
}
