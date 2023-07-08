using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleInteractableScript : MonoBehaviour, IInteractable
{
    GameObject me;
    [SerializeField] GameObject panel;
    [SerializeField] string[] lines;
    Dialogue dialogue;
    bool dialogueEnd = false;

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
        if(!panel.activeSelf){
            panel.SetActive(true);
            dialogue = panel.GetComponent<Dialogue>();
            dialogue.SetLines(lines);
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
        Debug.Log("It did something");
    }
}
