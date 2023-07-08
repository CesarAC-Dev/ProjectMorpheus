using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObjects : MonoBehaviour
{   
    [SerializeField] private int index;
    [SerializeField] private List<Sprite> inventoryObjectSpriteList = new List<Sprite>();
    


    public Sprite GetInventoryObjectSprite(int index){
        return inventoryObjectSpriteList[index];
    }

        
}
