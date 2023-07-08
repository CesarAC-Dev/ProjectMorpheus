using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{

    float deltaX, deltaY;
    float speed = 0.1f;
    bool moveAllowed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;

                        moveAllowed = true;
                        //Debug.Log(moveAllowed);
                    }
                    break;    
                case TouchPhase.Moved:
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && moveAllowed)
                    {
                         transform.Rotate(0f, 0f, (-touch.deltaPosition.x + -touch.deltaPosition.y) * speed);
                         Debug.Log("POSICION X: " + -touch.deltaPosition.x);
                         Debug.Log("POSICION Y: " + -touch.deltaPosition.y); 
                         Debug.Log("SUMA POS: " + (-touch.deltaPosition.x + -touch.deltaPosition.y));
                    }
                    break;
                case TouchPhase.Ended:
                    moveAllowed = false;
                    //Debug.Log(moveAllowed);
                break;
            }
            
            
            
        }
    }
}
