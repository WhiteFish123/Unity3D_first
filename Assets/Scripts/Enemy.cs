using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private enum EnemyState
    {
        NomalState,
        IdleState,
        MovingState,
        FightingState
    }
    private EnemyState enemyState;
    private EnemyState childState=EnemyState.IdleState;
    private NavMeshAgent agent;
    public int HP=100;
    public float restTime=2;
    private float restTimer=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyState==EnemyState.NomalState)
        {
            if(childState==EnemyState.IdleState)
            {
                restTimer+=Time.deltaTime;
                if(restTimer>=restTime)
                {
                    Vector3 RandomPos=FindRandomPosition();
                    agent.destination=RandomPos;
                    childState=EnemyState.MovingState;

                }
            }
            else if(childState==EnemyState.MovingState)
            {
                if(agent.remainingDistance<=0)
                {
                    childState=EnemyState.IdleState;
                    restTimer=0;
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(30);
        }
    }

    private Vector3 FindRandomPosition()
    {
        Vector3 randomDir=new Vector3(Random.Range(-1f,1f),0,Random.Range(-1f,1f));
        return transform.position + randomDir*Random.Range(2f,5f);
    }

    public void TakeDamage(int damage)
    {
        HP-=damage;
        if(HP<=0)
        {
            GetComponent<Collider>().enabled=false;
            int count=Random.Range(0,4);
            for(int i=0;i<count;i++)
            {
                ItemScriptObject item=ItemDB_Manager.instance.GetRandomItem();

                Instantiate(item.itemPrefab,transform.position,Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }
}
