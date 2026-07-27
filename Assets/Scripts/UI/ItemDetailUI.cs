using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetailUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI descriptionText;
    public GameObject propertyGrid;
    public GameObject propertyTemplate;

    private void Start()
    {
        propertyTemplate.SetActive(false);
    }

    public void UpdateItemDetailUI(ItemSO itemSO)
    {
        Debug.Log($"[ItemDetailUI] UpdateItemDetailUI 被调用: {itemSO.itemName}");
        Debug.Log($"[ItemDetailUI] propertyGrid={propertyGrid != null}, propertyTemplate={propertyTemplate != null}");
        Debug.Log($"[ItemDetailUI] propertyList.Count={itemSO.propertyList.Count}");

        string type="";
        switch(itemSO.itemType)
        {
            case ItemType.Weapon:
            type="武器";
            break;

            case ItemType.Consumable:
            type="可消耗品";
            break;
        }
        iconImage.sprite = itemSO.itemIcon;
        nameText.text = itemSO.itemName;
        typeText.text = type;
        descriptionText.text=itemSO.description;

        foreach(Transform child in propertyGrid.transform)
        {
            if(child.gameObject.activeSelf)
            {
                Destroy(child.gameObject);
            }
        }

        foreach(ItemProperty property in itemSO.propertyList)
        {
            string propertyStr="";
            string propertyName="";
            switch(property.propertyType)
            {
                case ItemPropertyType.HPValue:
                propertyName="生命值：";
                break;

                case ItemPropertyType.EnergyValue:
                propertyName="饥饿值：";
                break;

                case ItemPropertyType.MentalValue:
                propertyName="精神值：";
                break;
                case ItemPropertyType.SpeedValue:
                propertyName="速度：";
                break;
                case ItemPropertyType.AttackValue:
                propertyName="攻击力：";
                break;

                default:
                break;
            }
            propertyStr+=propertyName;
            propertyStr+=property.propertyValue;
            GameObject go = GameObject.Instantiate(propertyTemplate);
            go.SetActive(true);
            go.transform.parent=propertyGrid.transform;
            TextMeshProUGUI text = go.transform.GetComponentInChildren<TextMeshProUGUI>();
            Debug.Log($"[ItemDetailUI] 生成属性: {propertyStr}, text={text != null}");
            if(text != null)
            {
                text.text = propertyStr;
            }
        }
    }

}