using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RDG;
using UnityEngine.SceneManagement;

public class DragControllerLab : MonoBehaviour
{
    [SerializeField]
    private GameObject botonReintentar;
    [SerializeField]
    private GameObject cartelVictoria;
    [SerializeField]
    private GameObject cartelDerrota;
    [SerializeField]
    private Image Oscurecer;
    public DraggableLab LastDragged => _lastDragged;
    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private DraggableLab _lastDragged;
    private  SpriteRenderer sprite;
    private float _movementTime = 15f;
    private bool gameOver = false;

    private void Start()
    {
        botonReintentar.SetActive(false);
        cartelDerrota.SetActive(false);
        cartelVictoria.SetActive(false);
        Oscurecer.enabled = false;
    }
    private void Awake()
    {
        DragControllerLab[] controllers = FindObjectsOfType<DragControllerLab>();
        if(controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(!gameOver)
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
                DraggableLab draggable = hit.transform.gameObject.GetComponent<DraggableLab>();
                
                if(draggable != null)
                {
                   sprite = hit.transform.gameObject.GetComponent<SpriteRenderer>();
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }
        }
    }


    private void InitDrag()
    {
        sprite.sortingOrder = 10;
        UpdateDragStatus(true);
    }

    private void Drag()
    {
        _lastDragged.transform.position = Vector3.Lerp(_lastDragged.transform.position, new Vector2(_worldPosition.x, _worldPosition.y), _movementTime * Time.fixedDeltaTime);
    }

    private void Drop()
    {
        sprite.sortingOrder = 0;
        UpdateDragStatus(false);
        GameOver(true);
    }

    private void UpdateDragStatus(bool IsDragging)
    {
        _isDragActive = _lastDragged.IsDragging = IsDragging;
    }

    private void VictoriaRoyal()
    {
        cartelVictoria.SetActive(true);
        botonReintentar.SetActive(true);
        Oscurecer.enabled = true;
        Debug.Log("SUPER VICTORIA ROYAL");
    }
    private void Derrota()
    {
        cartelDerrota.SetActive(true);
        botonReintentar.SetActive(true);
        Oscurecer.enabled = true;
        Debug.Log("MANCOOOOOOOOOOOOO");
    }
    public void Reintentar()
    {
        SceneManager.LoadScene("LaberintoColision");
    }
    public void GameOver(bool perdiste)
    {
        if(perdiste)
        {
            Debug.Log("PERDISTE");
            gameOver = true;
            Derrota();
        }
        else
        {
            Debug.Log("GANASTE");
            gameOver = true;
            VictoriaRoyal();
        }
    }
}
