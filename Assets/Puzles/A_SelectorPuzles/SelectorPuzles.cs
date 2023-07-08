using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorPuzles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PuzleSimon()
    {
        SceneManager.LoadScene("SimonDice");
    }
    public void PuzleSlider()
    {
        SceneManager.LoadScene("SliderPuzle");
    }
    public void PuzleSliderV2()
    {
        SceneManager.LoadScene("SliderV2");
    }
    public void PuzleHabilidad()
    {
        SceneManager.LoadScene("PruebaHabilidad");
    }
    public void PuzleRayosLuz()
    {
        SceneManager.LoadScene("RayosLuz");
    }
    public void PuzleCables()
    {
        SceneManager.LoadScene("Cables");
    }
}
