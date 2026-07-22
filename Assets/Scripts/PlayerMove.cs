using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
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
        if(Input.GetMouseButtonDown(0)&&EventSystem.current.IsPointerOverGameObject()==false)//当按下鼠标左键的时候
        {
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            bool isCollide=Physics.Raycast(ray,out hit);//判断是否碰撞到物体
            if(isCollide)
            {
                if(hit.collider.CompareTag("Ground"))
                {
                    playerAgent.stoppingDistance=0;
                    playerAgent.SetDestination(hit.point);  
                }
                else if(hit.collider.CompareTag("Interactable"))
                {
                    hit.collider.GetComponent<InteractableObject>().OnClick(playerAgent);//获取交互脚本，调用Onclick方法
                }
            }
        }
        
    }
}
