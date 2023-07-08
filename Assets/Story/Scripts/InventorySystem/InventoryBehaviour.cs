using UnityEngine;

public class InventoryBehaviour : MonoBehaviour
{
    GameObject[] inventorySlots;
    Vector3[] inventorySlotsPosition;
    public int inventoryUsedSlot;
    Touch touch;
    float idTouch;
    float touchPositionX;
    bool moved = false;
    Vector3 auxVec;
    // Start is called before the first frame update
    void Start()
    {
        inventorySlots = new GameObject[this.transform.childCount];
        inventorySlotsPosition = new Vector3[this.transform.childCount];
        for(int i = 0; i < this.transform.childCount;i++){
            inventorySlots[i] = this.transform.GetChild(i).gameObject;
            inventorySlotsPosition[i] = this.transform.GetChild(i).gameObject.GetComponent<RectTransform>().position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(moved){
            if (inventorySlots[0].transform.position != inventorySlotsPosition[0])
            {
                for(int i = 0; i < inventorySlots.Length; i++){
                inventorySlots[i].GetComponent<RectTransform>().position = Vector3.MoveTowards(inventorySlots[i].GetComponent<RectTransform>().position, inventorySlotsPosition[i], 2000 * Time.deltaTime);
                }
            }else{
                moved = false;
            }
            
        }
    }
    public int GetUsedSlot(){
        return inventoryUsedSlot;
    }
    public GameObject[] GetInventorySlots(){
        return inventorySlots;
    }
    public void InitMove(){
        touch = Input.GetTouch(Input.touchCount-1);
        
        idTouch = touch.fingerId;
        touchPositionX = Camera.main.ScreenToWorldPoint(touch.position).x;
    }
     public void EndMove(){
        
        FindTouch();
        float direction = touchPositionX - Camera.main.ScreenToWorldPoint(touch.position).x;
        ChangeSlots(direction);
        
    }
    void FindTouch(){
        for(int i = Input.touchCount-1; i >-1;i--){
            if (Input.GetTouch(i).fingerId == idTouch)
            {
                touch = Input.GetTouch(i);
                break;
            }
        }
    }
    public void ChangeSlots(float dir){
        if(dir > 0){
            if(inventoryUsedSlot == inventorySlotsPosition.Length-1){
                inventoryUsedSlot = 0;
            }else{
                inventoryUsedSlot++;
            }
            Debug.Log("Entra en el if direction > 0");
            auxVec = inventorySlotsPosition[inventorySlotsPosition.Length-1];
            for(int i = inventorySlots.Length - 1; i > 0; i--){
                inventorySlotsPosition[i] = inventorySlotsPosition[i-1];
            }
            inventorySlotsPosition[0] = auxVec;

        }else{
            if(inventoryUsedSlot == 0){
                inventoryUsedSlot = inventorySlotsPosition.Length-1;
            }else{
                inventoryUsedSlot--;
            }
            Debug.Log("Entra en el if direction < 0");
            auxVec = inventorySlotsPosition[0];
             for(int i = 0; i < inventorySlotsPosition.Length-1; i++){
                inventorySlotsPosition[i] = inventorySlotsPosition[i+1];
            }
            inventorySlotsPosition[inventorySlotsPosition.Length-1] = auxVec;
            
            
        }
        moved = true;
    }
}
