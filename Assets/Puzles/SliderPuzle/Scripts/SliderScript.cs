using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RDG;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Transform espacioVacio;
    private Camera camara;
    private int posicionEspacioVacio = 15;
    [SerializeField] private Piezas[] piezas;
    private bool gameOver;
    [SerializeField] private GameObject botonReintentar;
    [SerializeField] private GameObject botonContinuar;
    [SerializeField] private GameObject cartelVictoria;
    [SerializeField] private Image Oscurecer;
    [SerializeField] private Piezas[] piezasScript;

    private void Start()
    {
        DesactivarUI(true);
        camara = Camera.main;
        Reordenar();
    }

    private void DesactivarUI(bool activo)
    {
        Oscurecer.enabled = !activo;
        botonContinuar.SetActive(!activo);
        botonReintentar.SetActive(activo);
        cartelVictoria.SetActive(!activo);
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = camara.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if(hit)
                {
                    if(Vector2.Distance(espacioVacio.position, hit.transform.position) < 2.5)
                    {
                        Vibration.VibratePredefined(1);
                        Vector2 lastPositionEspacioVacio = espacioVacio.position;
                        Piezas pieza = hit.transform.GetComponent<Piezas>();
                        espacioVacio.position = pieza.posicionDestino;
                        pieza.posicionDestino = lastPositionEspacioVacio;
                        int piezaIndice = ComprobarIndice(pieza);
                        piezas[posicionEspacioVacio] = piezas[piezaIndice];
                        piezas[piezaIndice] = null;
                        posicionEspacioVacio = piezaIndice;
                        ComprobarSolucion();
                    }
                }
            }
        }
        if(!gameOver)
        {
            ComprobarSolucion();
            gameOver = true;
        }
    }

    private void Reordenar()
    {   
        if(posicionEspacioVacio != 15)
        {
            Vector3 piezaEn15Posicion = piezas[15].posicionDestino;
            piezas[15].posicionDestino = espacioVacio.position;
            espacioVacio.position = piezaEn15Posicion;
            piezas[posicionEspacioVacio] = piezas[15];
            piezas[15] = null;
            posicionEspacioVacio = 15;
        }
        int inversion;
        do
        {
            for(int i = 0; i <= 14; i++)
            {
                Vector3 ultimaPos = piezas[i].posicionDestino;
                int random = Random.Range(0, 14);
                piezas[i].posicionDestino = piezas[random].posicionDestino;
                piezas[random].posicionDestino = ultimaPos;
                var pieza = piezas[i];
                piezas[i] = piezas[random];
                piezas[random] = pieza;
            }
            inversion = Inversion();
        }while(inversion % 2 != 0);
    }
    public int ComprobarIndice(Piezas pieza)
    {
        for(int i = 0; i < piezas.Length; i++)
        {
            if(piezas[i] != null)
            {
                if(piezas[i] == pieza)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    private int Inversion()
    {
        int inversionSuma = 0;
        for(int i = 0; i < piezas.Length; i++)
        {
            int inversionPieza = 0;
            for(int j = i; j < piezas.Length; j++)
            {
                if(piezas[j] != null)
                {
                    if(piezas[i].numero > piezas[j].numero)
                    {
                        inversionPieza++;
                    }
                }
            }
            inversionSuma += inversionPieza;
        }
        return inversionSuma;
    }

    private void ComprobarSolucion()
    {
        int piezasCorrectas = 0;
        foreach(var a in piezas)
        {
            if(a != null)
            {
                if(a.correcto)
                {
                    piezasCorrectas++;
                }
            }
        }
        if(piezasCorrectas == piezas.Length - 1)
        {
            VictoriaRoyal();
        }
    }

    private void VictoriaRoyal()
    {
        for(int i = 0; i < piezasScript.Length; i++)
        {
            piezasScript[i].jugando = false;
        }
        DesactivarUI(false);
    }

    public void Reintentar()
    {
        Vibration.VibratePredefined(1);
        SceneManager.LoadScene("SliderPuzle");
    }

    public void Continuar()
    {
        Vibration.VibratePredefined(1);
        SceneManager.LoadScene("SelectorPuzles");
    }
}
