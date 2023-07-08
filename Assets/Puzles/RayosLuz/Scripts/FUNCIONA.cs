using UnityEngine;

public class FUNCIONA : MonoBehaviour
{
    private Vector2 initialTouchPosition;
    private Quaternion initialRotation;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    initialTouchPosition = touch.position;
                    initialRotation = transform.rotation;
                    RotateObject(touch.position);
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    break;
            }
        }
    }

    private void RotateObject(Vector2 currentTouchPosition)
    {
        float screenWidth = Screen.width;
        float rotationAmount = 0f;

        if (currentTouchPosition.x < screenWidth / 2) // Parte izquierda de la pantalla
        {
            rotationAmount = 25f;
        }
        else // Parte derecha de la pantalla
        {
            rotationAmount = -25f;
        }

        Quaternion rotation = Quaternion.Euler(0f, 0f, rotationAmount);
        transform.rotation = initialRotation * rotation;
    }
}
