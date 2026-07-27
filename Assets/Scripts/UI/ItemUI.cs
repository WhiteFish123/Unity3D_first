using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image IconImage;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI TypeText;
    public void initItem(Sprite icon,string name,string type)
    {
        IconImage.sprite = icon;
        NameText.text = name;
        TypeText.text = type;
    }
}
