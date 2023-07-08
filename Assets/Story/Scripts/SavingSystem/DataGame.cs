using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int place;
    public string sceneName;
    public bool inDialogue;
    public static event System.Action<bool> OnDialogueChange;
    public static event System.Action<bool> OnPauseWorldChange;

    public 
    
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        Dialogue.OnDialogueChange += UpdateDialogue;
        GameData gameData = DataSerializer.LoadGameData();
        if(gameData != null){
            GameObject player = GameObject.FindWithTag("Player");
            if(player != null){
                player.transform.position = gameData.playerPosition;
            }
            // GameObject inventoryWeel = GameObject.FindWithTag("InventoryWeel");
            // if(inventoryWeel != null){

            //     while(inventoryWeel.GetComponent<InventoryBehaviour>().GetUsedSlot() != gameData.slotUsed){
            //         inventoryWeel.GetComponent<InventoryBehaviour>().ChangeSlots(1);
            //     }
            //     GameObject[] inventorySlots = inventoryWeel.GetComponent<InventoryBehaviour>().GetInventorySlots();
            //     for(int i = 0; i < inventorySlots.Length ; i++){
            //         inventorySlots[i].GetComponentInChildren<SlotObject>().SetObjectSprite(gameData.itemsInInventory[i]);
            //     }
            // }
            
        }

        // GameObject inventoryWeel = GameObject.FindWithTag("InventoryWeel");
        // if(inventoryWeel != null){

        //     // while(inventoryWeel.GetComponent<InventoryBehaviour>().GetUsedSlot() != gameData.slotUsed){
        //     //     inventoryWeel.GetComponent<InventoryBehaviour>().ChangeSlots(1);
        //     // }

        //     GameObject[] inventorySlots = inventoryWeel.GetComponent<InventoryBehaviour>().GetInventorySlots();
        //     for(int i = 0; i < inventorySlots.Length ; i++){
        //         inventorySlots[i].GetComponentInChildren<SlotObject>().setObjectSprite(i);
        //     }
        // }
    }
    void UpdateDialogue(bool newValue){
        inDialogue = newValue;
        OnDialogueChange?.Invoke(inDialogue);
        UpdatePauseWorld(inDialogue);
    }
    void UpdatePauseWorld(bool newValue){
        OnPauseWorldChange?.Invoke(inDialogue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
