using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SlotObject : MonoBehaviour
{
    public int ObjectSpriteIndex = 0;
    public void SetObjectSprite(int index){
        
        this.GetComponent<Image>().sprite = GameObject.FindGameObjectWithTag("DataGame").GetComponent<InventoryObjects>().GetInventoryObjectSprite(index);
        ObjectSpriteIndex = index;
    }
    public int GetObjectSpriteIndex(){
        return ObjectSpriteIndex;
    }
}
