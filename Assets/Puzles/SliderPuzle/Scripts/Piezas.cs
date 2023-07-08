using UnityEngine;

public class Piezas : MonoBehaviour
{
    public Vector3 posicionDestino;
    private Vector3 posicionCorrecta;
    public int numero;
    public bool correcto;
    public bool jugando = true;
    private void Awake()
    {
        posicionDestino = transform.position;
        posicionCorrecta = posicionDestino;
    }

    // Update is called once per frame
    private void Update()
    {
        if(jugando)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionDestino, 0.5f);
            if(posicionDestino == posicionCorrecta)
            {
                correcto = true;
            }
            else
            {
                correcto = false;
            }
        }
    }
}
