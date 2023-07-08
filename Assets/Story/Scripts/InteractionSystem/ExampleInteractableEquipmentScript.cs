using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleInteractableEquipmentScript : MonoBehaviour, IInteractable
{
    GameObject me;
    [SerializeField] GameObject panel;
    [SerializeField] string[] lines;
    [SerializeField] string[] linesNotPossible;
    Dialogue dialogue;
    bool dialogueEnd = false;
    [SerializeField] int itemIndex;
    int inventoryIndex;
    bool empty = false;
    GameObject[] slots;

    // Start is called before the first frame update
    void Start()
    {
        me = this.gameObject;
        DataGame.OnDialogueChange += UpdateDialogue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Interactor interactor){
        empty = checkInventory();
        if(!panel.activeSelf && empty){
            panel.SetActive(true);
            dialogue = panel.GetComponent<Dialogue>();
            dialogue.SetLines(lines);
        }else if(!panel.activeSelf){
            panel.SetActive(true);
            dialogue = panel.GetComponent<Dialogue>();
            dialogue.SetLines(linesNotPossible);
        }
        dialogue.checkDialogue();
        if(dialogueEnd){
            DoSomething();
        }
    }
    void UpdateDialogue(bool newValue){
        dialogueEnd = !newValue;
    }
    void DoSomething(){
        slots[inventoryIndex].GetComponentInChildren<SlotObject>().SetObjectSprite(itemIndex);
        Debug.Log("It did something");
    }
    bool checkInventory(){
        Debug.Log("Inventory Checked");
        slots = GameObject.FindGameObjectWithTag("InventoryWeel").GetComponent<InventoryBehaviour>().GetInventorySlots();
        for(int i = 0; i < slots.Length; i++){
            
            if(slots[i].GetComponentInChildren<SlotObject>().GetObjectSpriteIndex() == 0){
                inventoryIndex = i;
                return true;
            }
        }  
        return false;
    }
}
