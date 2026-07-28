using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerAttack playerAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAttack=GetComponent<PlayerAttack>();
    }

    public void UseItem(ItemSO itemSO)
    {
        switch(itemSO.itemType)
        {
            case ItemType.Weapon:
            playerAttack.LoadWeapon(itemSO);
            break;
            case ItemType.Consumable:
            break;
        }
    }
}
