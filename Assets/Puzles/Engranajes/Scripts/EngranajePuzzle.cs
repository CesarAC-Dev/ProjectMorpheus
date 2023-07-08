using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngranajePuzzle : MonoBehaviour
{

    [SerializeField]
    private GameObject engranaje1;
    [SerializeField]
    private GameObject engranaje2;
    [SerializeField]
    private GameObject puertaIzqGO;
    [SerializeField]
    private GameObject puertaDerGO;
    private Animator puertaDer;
    private Animator puertaIzq;

    public int izqCorrecto;
    public int derCorrecto;
    public int izqActual;
    public int derActual;

    private bool MovimientoActivo = true;


    // Start is called before the first frame update
    void Start()
    {
        puertaDer = puertaDerGO.GetComponent<Animator>();
        puertaIzq = puertaIzqGO.GetComponent<Animator>();
        izqCorrecto = Random.Range(1,5);
        derCorrecto = Random.Range(2,5);
        izqActual = 1;
        derActual = 1;
    }

    void Comprobar()
    {
        if(izqActual == izqCorrecto && derActual == derCorrecto)
        {
            MovimientoActivo = false;
            puertaDer.SetBool("Abierto", true);
            puertaIzq.SetBool("Abierto", true);
            //QUE SE TIENE QUE HACER CUANDO GANAS
        }
    }

    // Update is called once per frame
    void Update()
    {    
        if(Input.GetKeyDown(KeyCode.A) && MovimientoActivo)
        {
            engranaje1.transform.Rotate(0,0,90,0); if(izqActual > 1) izqActual--; else izqActual = 4;
            Comprobar();
            //engranaje2.transform.Rotate(0,0,-180,0);
        }
        if(Input.GetKeyDown(KeyCode.D) && MovimientoActivo)
        {
            engranaje1.transform.Rotate(0,0,-90,0); if(izqActual < 4) izqActual++; else izqActual = 1;
            Comprobar();
            //engranaje2.transform.Rotate(0,0,270,0);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && MovimientoActivo)
        {
            engranaje2.transform.Rotate(0,0,90,0); if(derActual > 1) derActual--; else derActual = 4;
            Comprobar();
            //engranaje1.transform.Rotate(0,0,180,0);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && MovimientoActivo)
        {
            engranaje2.transform.Rotate(0,0,-90,0); if(derActual < 4) derActual++; else derActual = 1;
            Comprobar();
            //engranaje1.transform.Rotate(0,0,0,0);
        }
    }
}
