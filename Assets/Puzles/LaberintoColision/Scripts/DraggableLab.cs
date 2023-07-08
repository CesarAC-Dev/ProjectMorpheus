using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableLab : MonoBehaviour
{
   public bool IsDragging;
   private Collider2D _collider;
   private DragControllerLab _dragController;
   private System.Nullable<Vector3> _movementDestination;

   private void Start()
   {
      _collider = GetComponent<Collider2D>();
      _dragController = FindObjectOfType<DragControllerLab>();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {  
      if(other.CompareTag("DropInvalid"))
      {
         _dragController.GameOver(true);
      }
      if(other.CompareTag("DropValid"))
      {
         _dragController.GameOver(false);
      }
      
   }
}
