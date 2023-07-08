using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class buttonInteract : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool dialogueStarted;
    // Start is called before the first frame update
    void Start()
    {
        DataGame.OnPauseWorldChange += UpdatePause;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdatePause(bool newValue){
        dialogueStarted = newValue;
    }
    public void PlayDialogue(){
        if(!dialogueStarted){
            panel.SetActive(true);
        }
        
    }
}
