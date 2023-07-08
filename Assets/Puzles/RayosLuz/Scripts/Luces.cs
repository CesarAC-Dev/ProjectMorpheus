using UnityEngine;
using System.Collections.Generic;
using RDG;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Luces : MonoBehaviour
{
    [SerializeField] private List<Range> rangosDeRotacion;
    [SerializeField] private List<Colorines> coloresDeRangos;
    [SerializeField] SpriteRenderer rayoRojo;
    [SerializeField] SpriteRenderer rayoAmarillo;
    [SerializeField] SpriteRenderer rayoVerde;
    [SerializeField] SpriteRenderer rayoAzul;
    [SerializeField] private float countdownTime = 1.5f;
    private Coroutine countdownCoroutine;
    [SerializeField] private GameObject botonContinuar;
    [SerializeField] private GameObject cartelVictoria;
    [SerializeField] private Image Oscurecer;
    [SerializeField] public bool gameOver = false;
    Color amarillo = new Color(0.9962f, 1f, 0, 1f);
    Color verde = new Color(0, 0.7547f, 0.1657f, 1f);

    private bool[] estaEnRangoCorrecto;

    private void Start()
    {
        cambiarColor(4);
        estaEnRangoCorrecto = new bool[rangosDeRotacion.Count];
        botonContinuar.SetActive(false);
        cartelVictoria.SetActive(false);
        Oscurecer.enabled = false;
    }

    private void Update()
    {
        if(!gameOver)
        {
            float rotacionZActual = transform.eulerAngles.z;

            for (int i = 0; i < rangosDeRotacion.Count; i++)
            {
                if (!estaEnRangoCorrecto[i] && EstaDentroDelRango(rotacionZActual, rangosDeRotacion[i].minRotation, rangosDeRotacion[i].maxRotation))
                {
                    estaEnRangoCorrecto[i] = true;
                    cambiarColor(i);
                    Vibration.VibratePredefined(1);
                    if(i == 3)
                    {
                        ComenzarCuentaAtras();
                    }
                }
                else if (estaEnRangoCorrecto[i] && !EstaDentroDelRango(rotacionZActual, rangosDeRotacion[i].minRotation, rangosDeRotacion[i].maxRotation))
                {
                    estaEnRangoCorrecto[i] = false;
                    cambiarColor(4);
                    Vibration.VibratePredefined(1);
                    if(i == 3)
                    {
                        PararCuentaAtras();
                    }
                }
            }
        }
    }

    //4 es negro
    private void cambiarColor(int caso)
    {
        switch(caso)
        {
            case 0:
                    rayoRojo.color = Color.blue;
                    rayoAmarillo.color = amarillo;
                    rayoVerde.color = Color.red;
                    rayoAzul.color = verde;
                    break;
            case 1:
                    rayoRojo.color = Color.red;
                    rayoAmarillo.color = Color.blue;
                    rayoVerde.color = verde;
                    rayoAzul.color = amarillo;
                    break;
            case 2:
                    rayoRojo.color = Color.red;
                    rayoAmarillo.color = verde;
                    rayoVerde.color = amarillo;
                    rayoAzul.color = Color.blue;
                    break;
            case 3:
                    rayoRojo.color = Color.red;
                    rayoAmarillo.color = amarillo;
                    rayoVerde.color = verde;
                    rayoAzul.color = Color.blue;
                    break;
            case 4:
                    rayoRojo.color = Color.black;
                    rayoAmarillo.color = Color.black;
                    rayoVerde.color = Color.black;
                    rayoAzul.color = Color.black;
                    break;

        }
        
    }

    private bool EstaDentroDelRango(float zRotation, float minRange, float maxRange)
    {
        // Asegurarse de que los valores de rango estén en el rango de 0 a 360
        minRange = ClampAngle(minRange);
        maxRange = ClampAngle(maxRange);

        // Obtener el ángulo normalizado dentro del rango de 0 a 360
        zRotation = ClampAngle(zRotation);

        // Comprobar si el ángulo está dentro del rango especificado
        if (minRange <= maxRange)
        {
            return zRotation >= minRange && zRotation <= maxRange;
        }
        else
        {
            return zRotation >= minRange || zRotation <= maxRange;
        }
    }

    private float ClampAngle(float angle)
    {
        angle %= 360f;
        if (angle < 0f)
        {
            angle += 360f;
        }
        return angle;
    }

    private void ComenzarCuentaAtras()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        countdownCoroutine = StartCoroutine(CountdownCoroutine());
    }

    private void PararCuentaAtras()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }
    }

    private IEnumerator CountdownCoroutine()
    {
        float timer = countdownTime;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        if (timer <= 0f)
        {
            // El contador ha llegado a 0, llamar al método
            VictoriaRoyal();
        }
    }

    private void VictoriaRoyal()
    {
        gameOver = true;
        cartelVictoria.SetActive(true);
        botonContinuar.SetActive(true);
        Oscurecer.enabled = true;
    }

    public void Continuar()
    {
        Vibration.VibratePredefined(1);
        SceneManager.LoadScene("SelectorPuzles");
    }
    
}

[System.Serializable]
public class Range
{
    public float minRotation;
    public float maxRotation;
}

[System.Serializable]
public class Colorines
{
    public Color rojo;
    public Color amarillo;
    public Color verde;
    public Color azul;
}
