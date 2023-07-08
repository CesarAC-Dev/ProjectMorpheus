using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using System;

public class Contador : MonoBehaviour
{
    [SerializeField] Sprite[] llaves;
    [SerializeField] Sprite[] basura;
    DateTime tiempoInicial;
    int duracion = 4;
    private Spawner spawner;
    private bool contando = true;
    [SerializeField] private bool llave = false;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        CambiarSkin(llave);
        tiempoInicial = DateTime.Now;
        spawner = FindObjectOfType<Spawner>();
    }

    private void CambiarSkin(bool esLlave)
    {
        if(esLlave)
        {
            spriteRenderer.sprite = llaves[UnityEngine.Random.Range(0,3)];
        }
        else
        {
            spriteRenderer.sprite = basura[UnityEngine.Random.Range(0,3)];
        }
        
    }

    private void Update()
    {
        if(contando)
        {
            DateTime tiempoActual = DateTime.Now;
            TimeSpan tiempoTranscurrido = tiempoActual - tiempoInicial;

            int segundosTranscurridos = (int)tiempoTranscurrido.TotalSeconds;
            int segundosRestantes = duracion - segundosTranscurridos;

            if (segundosRestantes <= 0)
            {
                spawner.EliminarYRecolocar(this.gameObject, llave);
                contando = false;
            }
        }
    }

}
