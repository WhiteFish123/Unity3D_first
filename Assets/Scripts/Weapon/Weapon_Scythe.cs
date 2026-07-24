using UnityEngine;

public class Weapon_Scythe : Weapon
{
    public const string ANIM_ATTACK_TRIGGER = "isAttack";
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    override public void Attack()
    {
        anim.SetTrigger(ANIM_ATTACK_TRIGGER);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tag.Enemy))
        {
            Debug.Log("Hit enemy with scythe, damage: " + attackValue);
        }
    }
}
