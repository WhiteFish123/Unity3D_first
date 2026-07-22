using UnityEngine;
using UnityEngine.AI;
public class InteractableObject : MonoBehaviour
{
    public void OnClick(NavMeshAgent playerAgent)
    {
        playerAgent.SetDestination(transform.position);  

        Interact();
    }
    protected virtual void Interact()
    {
        Debug.Log("Interacting with " + gameObject.name);
    }
}
