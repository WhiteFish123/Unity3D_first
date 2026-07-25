using UnityEngine;

public class ItemDB_Manager : MonoBehaviour
{
    public static ItemDB_Manager instance{get; private set;}
    public ItemDB_SO itemDB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(instance!=null && instance!=this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance=this;
    }

    public ItemScriptObject GetRandomItem()
    {
        int RandomIndex=Random.Range(0,itemDB.itemScriptObjects_List.Count);
        return itemDB.itemScriptObjects_List[RandomIndex];
    }   
}
