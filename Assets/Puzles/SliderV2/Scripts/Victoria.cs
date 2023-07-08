using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RDG;

public class Victoria : MonoBehaviour
{
    [SerializeField] private GameObject botonReintentar;
    [SerializeField] private GameObject botonContinuar;
    [SerializeField] private GameObject cartelVictoria;
    [SerializeField] private Image Oscurecer;
    [SerializeField] private Arrastrar[] piezasScript;
    
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
        for(int i = 0; i < piezasScript.Length; i++)
        {
            piezasScript[i].jugando = false;
        }
        DesactivarUI(false);
        Debug.Log("SUPER VICTORIA ROYAL");
    }

    private void OnTriggerEnter2D(Collider2D colldier)
    {
        VictoriaRoyal();
    }

    public void Reintentar()
    {
        Vibration.VibratePredefined(1);
        SceneManager.LoadScene("SliderV2");
    }

    public void Continuar()
    {
        Vibration.VibratePredefined(1);
        SceneManager.LoadScene("SelectorPuzles");
    }
}
