using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrastrar : MonoBehaviour
{
    private  float  deltaX, deltaY;
    private bool colliderTocado = false;
    private Rigidbody2D rb;
    public bool jugando = true;
    [SerializeField] public Vector3 posicionInicial;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    
    private void Update()
    {
        if(jugando)
        {
            if(Input.touchCount > 0)
            {
                Touch toque = Input.GetTouch(0);
                Vector3 toquePosicion = Camera.main.ScreenToWorldPoint(toque.position);
                switch(toque.phase)
                {
                    case TouchPhase.Began:
                        if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(toquePosicion))
                        {
                            colliderTocado = true;
                            rb.isKinematic = false;
                            deltaX = toquePosicion.x - transform.position.x;
                            deltaY = toquePosicion.y - transform.position.y;
                        }
                        break;
                    case TouchPhase.Moved:
                        if(colliderTocado)
                        {
                            rb.MovePosition(new Vector2(toquePosicion.x - deltaX, toquePosicion.y - deltaY));
                        }
                        break;
                    case TouchPhase.Ended:
                        colliderTocado = false;
                        rb.isKinematic = true;
                        break;
                }
            }
        }
        
    }
}
