using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    public static event System.Action<bool> OnDialogueChange;
    private bool started = false;
    public DataGame data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindWithTag("DataGame").GetComponent<DataGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetLines(string[] script){
        lines = script;
    }
    IEnumerator TypeLine(){
        foreach (char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    public void checkDialogue(){
        if(started){
            if(textComponent.text == lines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }else{
            textComponent.text = string.Empty;
            started = true;
            OnDialogueChange?.Invoke(started);
            StartDialogue();
            
        }
    }

    private void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }
    private void NextLine(){
        if (index < lines.Length -1){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            
        }else{
            started = false;
            OnDialogueChange?.Invoke(started);
            gameObject.SetActive(false);
        }
    }
}
