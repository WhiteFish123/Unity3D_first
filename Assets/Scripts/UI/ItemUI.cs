using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image IconImage;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI TypeText;

    public ItemSO itemSO;
    public void initItem(ItemSO itemSO)
    {
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
        IconImage.sprite = itemSO.itemIcon;
        NameText.text = itemSO.itemName;
        TypeText.text = type;
        this.itemSO=itemSO;
    }

    public void OnClick()
    {
        Debug.Log($"[ItemUI] 点击了物品: {itemSO.itemName}, itemSO={itemSO != null}");
        InventoryUI.Instance.OnItemClick(itemSO);
    }
}