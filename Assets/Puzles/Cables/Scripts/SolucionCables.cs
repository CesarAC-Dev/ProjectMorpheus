using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RDG;

public class SolucionCables : MonoBehaviour
{
    [SerializeField] private Cable[] cables;
    [SerializeField] private Cable[] todos;
    [SerializeField] private GameObject botonReintentar;
    [SerializeField] private GameObject botonContinuar;
    [SerializeField] private GameObject cartelVictoria;
    [SerializeField] private Image Oscurecer;
    
    void Start()
    {
        DesactivarUI(true);
    }
    private void DesactivarUI(bool activo)
    {
        Oscurecer.enabled = !activo;
        botonContinuar.SetActive(!activo);
        botonReintentar.SetActive(activo);
        cartelVictoria.SetActive(!activo);
    }
    private void VictoriaRoyal()
    {
        DesactivarUI(false);
    }

    public void Reintentar()
    {
        Vibration.VibratePredefined(1);
        SceneManager.LoadScene("Cables");
    }

    public void Continuar()
    {
        Vibration.VibratePredefined(1);
        SceneManager.LoadScene("SelectorPuzles");
    }

    public void ComprobarPosiciones()
    {
        bool correcto = true;
        foreach(Cable cable in cables)
        {
            if(cable.posicionCorrecta == false)
            {
                correcto = false;
                break;
            }
        }
        if(correcto)
        {
            foreach(Cable cable in todos)
            {
                cable.interactuable = false;
            }    
            StartCoroutine(passiveMe(0.1f));
        }
    }

    IEnumerator passiveMe(float secs)
    {
        foreach(Cable cable in cables)
        {
            cable.Activar();
            Vibration.VibratePredefined(1);
            yield return new WaitForSeconds(secs);
        }
        VictoriaRoyal();   
    }
}
