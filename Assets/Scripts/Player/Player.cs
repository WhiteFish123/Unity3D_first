using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerAttack playerAttack;
    public PlayerProperty playerProperty;
    
    void Start()
    {
        playerAttack=GetComponent<PlayerAttack>();
        playerProperty=GetComponent<PlayerProperty>();
    }

    public void UseItem(ItemSO itemSO)
    {
        switch(itemSO.itemType)
        {
            case ItemType.Weapon:
            playerAttack.LoadWeapon(itemSO);
            break;
            case ItemType.Consumable:
            playerProperty.UseDrug(itemSO);
            break;
        }
    }
}
