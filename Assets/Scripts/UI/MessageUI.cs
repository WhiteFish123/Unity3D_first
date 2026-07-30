using TMPro;
using UnityEngine;

public class MessageUI : MonoBehaviour
{
    public static MessageUI Instance{get;private set;}
    private TextMeshProUGUI messageText;
    private void Awake()
    {
        if(Instance!=null&&Instance!=this)
        {
            Destroy(gameObject);
            return;
        }
        Instance=this;
    }
    
    void Start()
    {
        messageText=transform.Find("Text").GetComponent<TextMeshProUGUI>();
        Hide();
    }

    public void Update()
    {
        if(messageText.enabled)
        {
            Color color=messageText.color;
            float alpha=Mathf.Lerp(color.a,0,Time.deltaTime*2);
            messageText.color=new Color(color.r,color.g,color.b,alpha);
            
            if(alpha==0)
            {
                Hide();
            }
        }
    }
    public void Show(string message)
    {
        messageText.enabled=true;
        messageText.text=message;
        messageText.color=Color.white;
    }
    public void Hide()
    {
        messageText.enabled=false;
    }
}
