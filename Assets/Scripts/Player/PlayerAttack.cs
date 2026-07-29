using UnityEngine;
using System.Collections.Generic;
public class PlayerAttack : MonoBehaviour
{
    public Weapon weapon;
    public Sprite weaponIcon;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon!=null&&Input.GetKeyDown(KeyCode.Space))
        {
            weapon.Attack();
        }
    }
    
    public void LoadWeapon(Weapon Weapon)
    {
        this.weapon = Weapon;
    }
    public void LoadWeapon(ItemSO itemSO)
    {
        if(weapon!=null)//如果已经装备了武器
        {
            Destroy(weapon.gameObject);
            weapon=null;
        }

        Transform weaponParent;
        if(itemSO.id==3)//3是标枪
            weaponParent=transform.Find("Weapon_Javlin_Position");
        else//4是镰刀
            weaponParent=transform.Find("Weapon_Scythe_Position");
        GameObject weaponGo=GameObject.Instantiate(itemSO.itemPrefab);
        weaponGo.transform.SetParent(weaponParent);
        weaponGo.transform.localPosition=Vector3.zero;
        weaponGo.transform.localRotation=Quaternion.identity;
        this.weapon=weaponGo.GetComponent<Weapon>();
        this.weaponIcon=itemSO.itemIcon;
        PlayerPropertyUI.Instance.UpdatePlayerPropertyUI();
    }
    public void UnloadWeapon()
    {
        weapon = null;
    }
}
