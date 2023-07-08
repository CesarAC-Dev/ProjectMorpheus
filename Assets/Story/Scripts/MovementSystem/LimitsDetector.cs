using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitsDetector : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] limits;
    [SerializeField] private string layerChange;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == GameObject.FindGameObjectWithTag("Player")){
            other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = layerChange;
            foreach (var limit in limits)
            {
                limit.SetActive(!limit.activeSelf);
            }
        }
    }
    void Start()
    {
        limits = new GameObject[this.transform.childCount];
        for(int i = 0; i < this.transform.childCount;i++){
            limits[i] = this.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
