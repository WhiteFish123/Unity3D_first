using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance{get;private set;}
    

    private void Awake()
    {
        if(Instance!=null&&Instance!=this)
        {
            Destroy(gameObject);
            return;
        }
        Instance=this;
    }
    public List<ItemSO> itemList;
    public ItemSO defaultWeapon;
    
    public void AddItem(ItemSO item)
    {
        itemList.Add(item);
        InventoryUI.Instance.AddItem(item);

        MessageUI.Instance.Show("你获得了一个： "+item.itemName);
    }
    public void RemoveItem(ItemSO item)
    {
        itemList.Remove(item);
    }
}
