using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class InteractableObject : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    bool isInteracting=false;
    private Coroutine moveToObjectCo;//先创建一个协程变量
    public void OnClick(NavMeshAgent playerAgent)
    {
        this.playerAgent=playerAgent;
        if(moveToObjectCo!=null)//如果协程不为空，说明之前已经有一个协程在执行了
        {
            StopCoroutine(moveToObjectCo);//那么就先停止之前的协程
        }
        moveToObjectCo=StartCoroutine(MoveToObjectCo());
        //开启新的协程，MoveToObjectCo是方法，moveToObjectCo是协程变量
        //协程变量的作用是为了在下一次点击时，能够停止之前的协程，避免多个协程同时执行

        //Interact();
    }
    
    protected virtual void Interact()
    {
        Debug.Log("Interacting with " + gameObject.name);
    }
    private IEnumerator MoveToObjectCo()
    {
        //检查playerAgent是否为空
        //检查路径是否可达
        if (playerAgent == null) yield break;
        playerAgent.stoppingDistance=2;
        if (!playerAgent.SetDestination(transform.position))//设置目的地的同时检查是否可达
        {
            Debug.LogWarning("Destination unreachable");
            yield break;
        }

        yield return new WaitUntil(()=>playerAgent.pathPending==false);//先等待计算完路径
        yield return new WaitUntil(()=>playerAgent.remainingDistance<=playerAgent.stoppingDistance);//再等待玩家到达目的地

        Interact();//正式交互
    }
}
