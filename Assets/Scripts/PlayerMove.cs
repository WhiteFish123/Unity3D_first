using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))//当按下鼠标左键的时候
        {
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            bool isCollide=Physics.Raycast(ray,out hit);//判断是否碰撞到物体
            if(isCollide)
            {
                playerAgent.SetDestination(hit.point);
            }
        }
        
    }
}
