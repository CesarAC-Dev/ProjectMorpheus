using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius;
    [SerializeField] private LayerMask _interactableMask;
    private readonly Collider2D[] _colliders = new Collider2D[3];
    [SerializeField] private int _numFound;
    private IInteractable _interactable;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _numFound = Physics2D.OverlapCircleNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
    }

    public void startInteraction(){
        if (_numFound > 0){
            _interactable = _colliders[0].GetComponent<IInteractable>();
            if(_interactable != null){
                _interactable.Interact(this);
            }
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position,_interactionPointRadius);
    }
}
