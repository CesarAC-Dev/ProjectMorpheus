using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
   [SerializeField]
   public int id = 0;
   public bool IsDragging;
   public Vector3 LastPosition;
   private Collider2D _collider;
   private DragController _dragController;
   private ComprobarSolucion comprobarSolucion;
   private float _movementTime = 15f;
   private System.Nullable<Vector3> _movementDestination;
   private bool Tablero = false;

   private void Start()
   {
      LastPosition = transform.position;
      _collider = GetComponent<Collider2D>();
      _dragController = FindObjectOfType<DragController>();
      comprobarSolucion = FindAnyObjectByType<ComprobarSolucion>();
   }

   private void FixedUpdate()
   {
      if(_movementDestination.HasValue)
      {
         if(IsDragging)
         {
            _movementDestination = null;
            return;
         }

         if(transform.position == _movementDestination)
         {
            _movementDestination = null;
            if(!Tablero)
            {
               gameObject.layer = Layer.Default;
            }
            else
            {
               gameObject.layer = Layer.Colocado;
               comprobarSolucion.Comprobar(transform.position,id);
            }
            
         }
         else
         {
            transform.position = Vector3.MoveTowards(transform.position, _movementDestination.Value, _movementTime * Time.deltaTime);
         }
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {  
      if(other.CompareTag("DropValid"))
      {
         Debug.Log("Es valido" + gameObject.name);
         Tablero = true;
         _movementDestination = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
      }
      else if(other.CompareTag("DropInvalid") && _dragController.LastDragged.gameObject == gameObject)
      {
          Debug.Log("INVALIDO PLS DATE CUENTA" + gameObject.name);
         _movementDestination = LastPosition;
         comprobarSolucion.ToFalse(id);
      }
      
   }
}
