using UnityEngine;

public class DragRotate : MonoBehaviour
{
    private bool estaRotando = false;
    private Quaternion rotacionInicial;
    private float cantidadDeRotacion = 0f;
    private Luces luces;

    [SerializeField] private float velocidadDeRotacion = 10f;

    private void Start()
    {
        luces = FindObjectOfType<Luces>();
    }
    private void Update()
    {
        if(!luces.gameOver)
        {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            switch (toque.phase)
            {
                case TouchPhase.Began:
                    Vector2 posicionToque = toque.position;
                    if (TocaLaMitadIzquierda(posicionToque))
                    {
                        estaRotando = true;
                        rotacionInicial = transform.rotation;
                        cantidadDeRotacion = 8f;
                    }
                    else
                    {
                        estaRotando = true;
                        rotacionInicial = transform.rotation;
                        cantidadDeRotacion = -8f;
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    estaRotando = false;
                    break;
            }
        }

        if (estaRotando)
        {
            RotarObjeto();
        }
        }
    }

    private void RotarObjeto()
    {
        float rotacion = cantidadDeRotacion * velocidadDeRotacion * Time.deltaTime;
        transform.Rotate(0f, 0f, rotacion);
    }

    private bool TocaLaMitadIzquierda(Vector2 posicionToque)
    {
        float anchoPantalla = Screen.width;
        return posicionToque.x < anchoPantalla / 2f;
    }
}
