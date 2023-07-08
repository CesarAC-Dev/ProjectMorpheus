using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EscenaHistoria()
    {
        SceneManager.LoadScene("SelectorHistoria");
    }

    public void EscenaPuzles()
    {
        SceneManager.LoadScene("SelectorPuzles");
    }
}
