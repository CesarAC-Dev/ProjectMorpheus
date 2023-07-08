using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RDG;
using TMPro;
public class Spawner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI piezasRemainig;
    [SerializeField] private TextMeshProUGUI vidaRemaining;
    [SerializeField] private GameObject botonReintentar;
    [SerializeField] private GameObject botonContinuar;
    [SerializeField] private GameObject cartelVictoria;
    [SerializeField] private GameObject cartelDerrota;
    [SerializeField] private Image Oscurecer;
    [SerializeField] private GameObject[] objetosMalos;
    [SerializeField] private GameObject[] objetosBuenos;
    private Vector3 zona1 = new Vector3(-6,0);
    private Vector3 zona2 = new Vector3(0,0);
    private Vector3 zona3 = new Vector3(6,0);
    public int vidas = 3;
    [SerializeField] private int llaves = 0;
    private int victoria = 0;
    public bool gameOver = false;

    void Start()
    {
        vidaRemaining.text = vidas.ToString();
        piezasRemainig.text = victoria.ToString() + "/9";
        botonContinuar.SetActive(false);
        botonReintentar.SetActive(false);
        cartelDerrota.SetActive(false);
        cartelVictoria.SetActive(false);
        Oscurecer.enabled = false;
        EmpezarJuego();
    }

    private void EmpezarJuego()
    {
        GameObject elemento1 = Instantiate(objetosBuenos[0], GenerarVector(zona1), Quaternion.identity);
        GameObject elemento2 = Instantiate(objetosBuenos[0], GenerarVector(zona2), Quaternion.identity);
        GameObject elemento3 = Instantiate(objetosBuenos[0], GenerarVector(zona3), Quaternion.identity);
        llaves = 3;
    }

    private Vector3 GenerarVector(Vector3 vector)
    {
        return vector = new Vector3(Random.Range(vector.x - 2, vector.x + 2),0);
    }

    public void EliminarYRecolocar(GameObject objeto, bool llave)
    {
        Vector3 origen = objeto.transform.position;
        if(llave) llaves--;
        Destroy(objeto);
        if(!gameOver){GenerarNuevoElemento(DevolverZonaSpawn(origen));}
    }

    private void GenerarNuevoElemento(Vector3 posicionSpawn)
    {
        int random = Random.Range(1,4);
        if((random == 1 || random == 2) && llaves < 9)
        {
            Instantiate(objetosBuenos[0], posicionSpawn, Quaternion.identity);
            llaves++;
        }
        else
        {
            Instantiate(objetosMalos[0], posicionSpawn, Quaternion.identity);
        }
    }

    private Vector3 DevolverZonaSpawn(Vector3 zonaOrigen)
    {
        float v1 = Vector3.Distance(zonaOrigen, zona1);
        float v2 = Vector3.Distance(zonaOrigen, zona2);
        float v3 = Vector3.Distance(zonaOrigen, zona3);
            
        if(v1 < v2 && v1 < v3)
        {
            return GenerarVector(zona1);
        }
        else if(v2 < v1 && v2 < v3)
        {
            return GenerarVector(zona2);
        }
        else
        {
            return GenerarVector(zona3);
        }
    }

    public void TocarYComprobar(GameObject objeto, bool correcto)
    {
        if(!gameOver)
        {
            if(objeto != null)
            {
                Vector3 origen = objeto.transform.position;
                Destroy(objeto);
                if(correcto)
                {
                    victoria++;
                    piezasRemainig.text = victoria.ToString() + "/9";
                }
                else
                {
                    vidas--;
                    vidaRemaining.text = vidas.ToString();
                }
                GenerarNuevoElemento(DevolverZonaSpawn(origen));
            }
            else
            {
              vidas--;
              vidaRemaining.text = vidas.ToString();
            }

            if(victoria >= 9)
            {
                GameOver(false);
            }
            if(vidas <= 0)
            {
                GameOver(true);
            }
        }
        
    }

    public void GameOver(bool perdiste)
    {
        if(perdiste)
        {
            Debug.Log("PERDISTE");
            gameOver = true;
            Derrota();
        }
        else
        {
            Debug.Log("GANASTE");
            gameOver = true;
            VictoriaRoyal();
        }
    }

    private void VictoriaRoyal()
    {
        cartelVictoria.SetActive(true);
        botonContinuar.SetActive(true);
        Oscurecer.enabled = true;
        Debug.Log("SUPER VICTORIA ROYAL");
    }
    private void Derrota()
    {
        cartelDerrota.SetActive(true);
        botonReintentar.SetActive(true);
        Oscurecer.enabled = true;
        Debug.Log("MANCOOOOOOOOOOOOO");
    }

    public void Reintentar()
    {
        Vibration.VibratePredefined(1);
        SceneManager.LoadScene("PruebaHabilidad");
    }
    public void Continuar()
    {
        Vibration.VibratePredefined(1);
        SceneManager.LoadScene("SelectorPuzles");
    }
}
