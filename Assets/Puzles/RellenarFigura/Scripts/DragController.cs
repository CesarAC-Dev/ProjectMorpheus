using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public Draggable LastDragged => _lastDragged;
    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private Draggable _lastDragged;
    private  SpriteRenderer sprite;
    private float _movementTime = 15f;
    private ComprobarSolucion comprobarSolucion;
    
    private void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();
        if(controllers.Length > 1)
        {
            Destroy(gameObject);
        }
        comprobarSolucion = FindAnyObjectByType<ComprobarSolucion>();
    }

    private void Update()
    {
        if(_isDragActive)
        {
            if((Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
            {
                Drop();
                return;
            }
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if(Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }
        
        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if(_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                
                if(draggable != null)
                {
                   sprite = hit.transform.gameObject.GetComponent<SpriteRenderer>();
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }


    private void InitDrag()
    {
        //_lastDragged.LastPosition = _lastDragged.transform.position;
        sprite.sortingOrder = 10;
        UpdateDragStatus(true);
        comprobarSolucion.ToFalse(_lastDragged.id);

    }

    private void Drag()
    {
        //transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.fixedDeltaTime);
        //_lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
        _lastDragged.transform.position = Vector3.Lerp(_lastDragged.transform.position, new Vector2(_worldPosition.x, _worldPosition.y), _movementTime * Time.fixedDeltaTime);
    }

    private void Drop()
    {
        sprite.sortingOrder = 0;
        UpdateDragStatus(false);
    }

    private void UpdateDragStatus(bool IsDragging)
    {
        _isDragActive = _lastDragged.IsDragging = IsDragging;
        _lastDragged.gameObject.layer = IsDragging ? Layer.Dragging : Layer.Default;
    }
}
