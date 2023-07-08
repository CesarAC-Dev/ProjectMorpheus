using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    private void Start()
    {
    }

    public void SaveGameData()
    {
        Vector3 playerPosition = GameObject.FindWithTag("Player").transform.position;
        DataGame data = GameObject.FindWithTag("DataGame").GetComponent<DataGame>();
        int place = data.place;
        string sceneName = data.sceneName;
        InventoryBehaviour inventory = GameObject.FindWithTag("InventoryWeel").GetComponent<InventoryBehaviour>();
        int slotUsed = inventory.GetUsedSlot();
        GameObject[] slots = inventory.GetInventorySlots();
        int[] spriteSlots = new int[slots.Length];
        for(int i = 0; i < slots.Length; i++){
            spriteSlots[i] = slots[i].GetComponentInChildren<SlotObject>().GetObjectSpriteIndex();
        }



        GameData gameData = new GameData();
        gameData.playerPosition = playerPosition;
        gameData.place = place;
        gameData.sceneName = sceneName;
        DataSerializer.SaveGameData(gameData);
        gameData.slotUsed = slotUsed;
        gameData.itemsInInventory = spriteSlots;

    }
}