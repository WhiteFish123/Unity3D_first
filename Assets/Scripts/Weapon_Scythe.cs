using UnityEngine;

public class Weapon_Scythe : Weapon
{
    public const string ANIM_ATTACK_TRIGGER = "isAttack";
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.Space))
    //     {
    //         Attack();
    //     }
    // }
    override public void Attack()
    {
        anim.SetTrigger(ANIM_ATTACK_TRIGGER);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy with scythe, damage: " + attackValue);
        }
    }
}
