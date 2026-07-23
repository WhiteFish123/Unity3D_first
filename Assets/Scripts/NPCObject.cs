using UnityEngine;
using System.Collections.Generic;

public class NPCObject : InteractableObject
{
    public string npcName;
    public List<string>contentList=new List<string>();
    protected override void Interact()
    {
        DialogueUI.Instance.Show(npcName,contentList);
    }
}
