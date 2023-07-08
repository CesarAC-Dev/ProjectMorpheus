using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            //Debug.Log("Holi");
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("Holi");
                if(hit.transform.tag == "Engranaje")
                {
                    Debug.Log("Holi");
                    var objectScript = hit.collider.GetComponent<DragAndRotateEngranaje>();
                    objectScript.isActive = !objectScript.isActive;
                }
            }
        }
    }
}
