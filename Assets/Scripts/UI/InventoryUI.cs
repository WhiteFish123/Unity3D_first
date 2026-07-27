using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance{get; private set;}
    private GameObject uiGameObject;
    private GameObject content;
    public GameObject itemPrefab;
    private bool isShow=false;

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
        content = transform.Find("UI/List_Bg/Scroll View/Viewport/Content").gameObject;
        Hide();
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            if(isShow)
            {
                Hide();
                isShow=false;
            }
            else
            {
                Show();
                isShow=true;
            }
        }
    }
    void Show()
    {
        uiGameObject.SetActive(true);
    }
    void Hide()
    {
        uiGameObject.SetActive(false);
    }
    public void AddItem(ItemSO itemSO)
    {
        GameObject itemGO = GameObject.Instantiate(itemPrefab);
        itemGO.transform.SetParent(content.transform);
        ItemUI itemUI=itemGO.GetComponent<ItemUI>();
        
        itemUI.initItem(itemSO);
    }
    public void OnItemClick(ItemSO itemSO)
    {
        
    }
}
