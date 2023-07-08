using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RDG;

public class MovimientoMarcador : MonoBehaviour
{
    private Spawner spawner;
    private Collider2D _collider;
    private float speed = 10;
    private Vector3 origen = new Vector3(-8,0);
    private Vector3 final = new Vector3(8,0);
    private Vector3 destino = new Vector3(8,0);
    private bool dentro = false;
    private bool correcto = false;
    private GameObject colisionado;
    bool touchedLastFrame = false;

    // Start is called before the first frame update
    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(touchedLastFrame && Input.touchCount == 0)
        {
            touchedLastFrame = false;
        }
        else if(!touchedLastFrame && Input.touchCount > 0)
        {
            Click();
            touchedLastFrame = true;
        }
        if(!spawner.gameOver){
            transform.position = Vector3.MoveTowards(transform.position, destino, speed * Time.deltaTime);
            if (transform.position == final)
            {
                destino = origen;
            } 
            if (transform.position == origen)
            {
                destino = final;
            }
        } 
    }

    private void Click()
    {
        Vibration.VibratePredefined(1);
        if(!spawner.gameOver)
        {
            if(dentro)
            {
                if(correcto)
                {
                    spawner.TocarYComprobar(colisionado, true);
                }
                else
                {
                    spawner.TocarYComprobar(colisionado, false);
                }
            }
            else
            {
                spawner.TocarYComprobar(null, false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        colisionado = other.gameObject;
        dentro = true;
        if(other.gameObject.tag == "Bueno")
        {
            correcto = true;
        }
        else
        {
            correcto = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        colisionado = null;
        dentro = false;
    }

    public void Reintentar()
    {
        Debug.Log("GOIWEFHWEUI");
        SceneManager.LoadScene("PruebaHabilidad");
    }
}
