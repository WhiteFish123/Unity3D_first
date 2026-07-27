using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance{get; private set;}
    private GameObject uiGameObject;
    private GameObject content;
    public GameObject itemPrefab;
    
    void Awake()
    {
        if(Instance!=null&&Instance!=this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        uiGameObject = transform.Find("UI").gameObject;
        content = transform.Find("UI/ListBg/Scroll View/Viewport/Content").gameObject;
    }
    void Show()
    {
        uiGameObject.SetActive(true);
    }
    void Hide()
    {
        uiGameObject.SetActive(false);
    }
    private void AddItem(ItemSO itemSO)
    {
        GameObject itemGO = GameObject.Instantiate(itemPrefab);
        itemGO.transform.SetParent(content.transform);
        ItemUI itemUI=itemGO.GetComponent<ItemUI>();
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
        itemUI.initItem(itemSO.itemIcon,itemSO.itemName,type);
    }
    
}
