using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RDG;

public class Cable : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite on;
    [SerializeField]
    private Sprite off;
    private bool activado = false;
    private float[] angulos = {0, 90, 180, 270};
    public bool esValido = true;
    public float anguloCorrecto;
    public float anguloCorrecto2;
    public bool posicionCorrecta = false;
    public SolucionCables solucionCables;
    public float[] angulosCorrectos;
    public bool interactuable = true;

    private void Start()
    {
        int random = Random.Range(0, angulos.Length);
        transform.Rotate(new Vector3(0,0, angulos[random]));
        if(esValido)
        {
            if(transform.eulerAngles.z <= anguloCorrecto +1 &&  transform.eulerAngles.z >= anguloCorrecto -1 || transform.eulerAngles.z <= anguloCorrecto2 +1 &&  transform.eulerAngles.z >= anguloCorrecto2 -1 )
            {
                posicionCorrecta = true;
                solucionCables.ComprobarPosiciones();
            }
            else
            {
                posicionCorrecta = false;
            }
        }
    }

    private void Update()
    {
        if(interactuable)
        {
            if (Input.touchCount > 0)
            {
                Touch toque = Input.GetTouch(0);
 
                if (toque.phase == TouchPhase.Began)
                {
                    Vector3 posicionDelToque = Camera.main.ScreenToWorldPoint(toque.position);
                    Vector2 posicionDelToque2D = new Vector2(posicionDelToque.x, posicionDelToque.y);

                    if (GetComponent<Collider2D>().OverlapPoint(posicionDelToque2D))
                    {
                        Vibration.VibratePredefined(1);
                        transform.Rotate(new Vector3(0, 0, 90));
                        if(esValido)
                        {
                            if(transform.eulerAngles.z <= anguloCorrecto +1 &&  transform.eulerAngles.z >= anguloCorrecto -1 ||
                                transform.eulerAngles.z <= anguloCorrecto2 +1 &&  transform.eulerAngles.z >= anguloCorrecto2 -1 )
                            {
                                posicionCorrecta = true;
                                solucionCables.ComprobarPosiciones();
                            }
                            else
                            {
                                posicionCorrecta = false;
                            }
                        }
                    }
                }
            }
        }
        
    }
    public void Activar()
    {
        spriteRenderer.sprite = on;
    }
    public void Desactivar()
    {
        spriteRenderer.sprite = off;
    }
}
