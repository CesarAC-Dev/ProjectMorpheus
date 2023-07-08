using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RDG;
using UnityEngine.SceneManagement;

public class Boton : MonoBehaviour
{ 
    [SerializeField] private GameObject botonComenzar;
    [SerializeField] private GameObject botonReintentar;
    [SerializeField] private GameObject botonContinuar;
    [SerializeField] private GameObject cartelVictoria;
    [SerializeField] private GameObject cartelDerrota;
    [SerializeField] private Image OscurecerDerecho;
    [SerializeField] private Image OscurecerIzquierdo;
    [SerializeField] private Button botonRojo;
    [SerializeField] private Button botonAmarillo;
    [SerializeField] private Button botonVerde;
    [SerializeField] private Button botonAzul;
    [SerializeField] private GameObject rojo;
    [SerializeField] private GameObject amarillo;
    [SerializeField] private GameObject verde;
    [SerializeField] private GameObject azul;
    [SerializeField] private int maxSolucion = 6;
    private Vector2 posIni = new Vector2(-0.15f, 7);
    private List<int> simonDice = new List<int>();
    private int contador = 0;
    private int maxLista = 0;

    private void Start()
    {
        IniciarJuego();
    }
    public void IniciarJuego()
    {
        botonReintentar.SetActive(false);
        botonContinuar.SetActive(false);
        cartelDerrota.SetActive(false);
        cartelVictoria.SetActive(false);
        DesactivarBotones(false);
        ValoresPorDefecto();
    }

    private void ValoresPorDefecto()
    {
        maxLista = 0;
        contador = 0;
        simonDice.Clear();
    }
    public void Pulsar(int boton)
    {
        Vibration.VibratePredefined(1);
        ComprobarSolucion(contador, boton);
    }

    private void GenerarPatron()
    {
        DesactivarBotones(false);
        simonDice.Add(Random.Range(0,4));
        maxLista++;
        //Debug.Log(simonDice.Count);
        StartCoroutine(passiveMe(1.5f));
        contador = 0;
        
    }

    private void ComprobarSolucion(int pos, int boton)
    {
        if(simonDice[pos] == boton)
        {
            contador++;
            Debug.Log("Correcto");
            if(maxLista == contador)
            {
                if(maxLista == maxSolucion)
                {
                    VictoriaRoyal();
                }
                else
                {
                    BotonCorrecto();
                }
                
            }
        }
        else
        {
            Derrota();
        }
    }
    private void VictoriaRoyal()
    {
        cartelVictoria.SetActive(true);
        botonContinuar.SetActive(true);
        DesactivarBotones(false);
        Debug.Log("SUPER VICTORIA ROYAL");
    }

    private void BotonCorrecto()
    {
        DesactivarBotones(false);
        Debug.Log("GANASTEEEEEE");
        GenerarPatron();
    }
    private void Derrota()
    {
        cartelDerrota.SetActive(true);
        botonReintentar.SetActive(true);
        DesactivarBotones(false);
        Debug.Log("MANCOOOOOOOOOOOOO");
    }

    IEnumerator passiveMe(float secs) {
        foreach(int dato in simonDice)
        {
            switch(dato)
            {
                case 0:
                    rojo.SetActive(true);
                    yield return new WaitForSeconds(secs);
                    rojo.transform.position = posIni;
                    rojo.SetActive(false);
                    break;
                case 1:
                    amarillo.SetActive(true);
                    yield return new WaitForSeconds(secs);
                    amarillo.transform.position = posIni;
                    amarillo.SetActive(false);
                    break;
                case 2:
                    verde.SetActive(true);
                    yield return new WaitForSeconds(secs);
                    verde.transform.position = posIni;
                    verde.SetActive(false);
                    break;
                case 3:
                    azul.SetActive(true);
                    yield return new WaitForSeconds(secs);
                    azul.transform.position = posIni;
                    azul.SetActive(false);
                    break;
            }
        }
         DesactivarBotones(true);   
    }

    private void DesactivarBotones(bool activo)
    {
        OscurecerDerecho.enabled = !activo;
        OscurecerIzquierdo.enabled = !activo;
        botonRojo.interactable = activo;
        botonAmarillo.interactable = activo;
        botonVerde.interactable = activo;
        botonAzul.interactable = activo;
    }

    public void Reintentar()
    {
        Vibration.VibratePredefined(1);
        SceneManager.LoadScene("SimonDice");
    }

    public void Continuar()
    {
        Vibration.VibratePredefined(1);
        SceneManager.LoadScene("SelectorPuzles");
    }
    public void Comenzar()
    {
        Vibration.VibratePredefined(1);
        botonComenzar.SetActive(false);
        GenerarPatron();
    }

}
