using UnityEngine;
using System.Collections.Generic;
public class PlayerAttack : MonoBehaviour
{
    public Weapon weapon;
    
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
    public void UnloadWeapon()
    {
        weapon = null;
    }
}
