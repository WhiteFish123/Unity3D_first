using UnityEngine;

public class Weapon_Scythe : Weapon
{
    public const string ANIM_ATTACK_TRIGGER = "isAttack";
    private Animator anim;

    public int atkValue=30;
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
        if(other.CompareTag(Tag.ENEMY))
        {
            other.GetComponent<Enemy>().TakeDamage(atkValue);
        }
    }
}
