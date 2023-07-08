using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{
    [SerializeField] SpriteRenderer pelota;
    private Color[] colores = {Color.red, Color.yellow, Color.green, Color.blue};
    public int color = 0;
    public float fuerzaDeRebote = 5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobamos si la colisión ha ocurrido con otro objeto que tenga un Rigidbody2D.
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            // Obtenemos la normal de la colisión.
            Vector2 normal = collision.GetContact(0).normal;

            // Calculamos el vector de rebote utilizando la normal.
            Vector2 bounceDirection = Vector2.Reflect(collision.relativeVelocity, normal).normalized;

            // Aplicamos la fuerza de rebote al objeto que colisionó.
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(bounceDirection * fuerzaDeRebote, ForceMode2D.Impulse);
            pelota.color = colores[color];
        }
    }
}
