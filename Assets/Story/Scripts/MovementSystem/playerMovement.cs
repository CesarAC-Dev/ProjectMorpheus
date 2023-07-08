using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 5.0f;
 
 
    public Vector2 move;

    [SerializeField]private LayerMask obstacle;
    [SerializeField]private LayerMask stairs;
    

    public Vector2 targetMovePoint;

    private Animator animator;

    private Boolean moving;
    public Joystick joystick;
    public bool inPause = false;
    

    public Vector2 offSet = new Vector2(0,0);
    
    // Start is called before the first frame update
    void Start()
    {
        // if(GameObject.Find("StatsDream") != null){
        //     GameObject.Find("StatsDream").GetComponent<StatsDream>().getPlayer();
        // }
        // animator = GetComponent<Animator>();
        DataGame.OnPauseWorldChange += UpdatePause;
        GameData gameData = DataSerializer.LoadGameData();
        if(gameData != null){
            transform.position = gameData.playerPosition;
        }
        animator = GetComponent<Animator>();
        targetMovePoint = transform.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!inPause){
            if(moving){
                transform.position = Vector2.MoveTowards(transform.position, targetMovePoint, 7.5f * Time.deltaTime);
                if(Vector2.Distance(transform.position, targetMovePoint) == 0){
                    moving = false;
                    animator.SetBool("Moving", false);
                }
            }

            if (!moving && (Math.Abs(joystick.Horizontal) >= 0.2 || Math.Abs(joystick.Vertical) >= 0.2)){
                if(Math.Abs(joystick.Horizontal) >= Math.Abs(joystick.Vertical)){
                    move.x = joystick.Horizontal * speed;
                    move.y = 0;
                }else {
                    move.x = 0;
                    move.y = joystick.Vertical * speed;
                }
            
                Vector2 tryPoint = new Vector2(transform.position.x, transform.position.y) + new Vector2(move.normalized.x, move.normalized.y);
                animator.SetFloat("Horizontal", move.normalized.x);
                animator.SetFloat("Vertical", move.normalized.y);
                if(!Physics2D.OverlapCircle(tryPoint, 0.4f, obstacle)|| (move.x != 0 && offSet.y != 0)){
                    if(!Physics2D.OverlapCircle(tryPoint, 0.4f, obstacle+stairs)){
                        offSet.y = 0;
                    }
                    moving = true;
                    animator.SetBool("Moving", true);
                    tryPoint = tryPoint + move.normalized.x * offSet.normalized;
                    targetMovePoint = tryPoint;
                }
            }
        }
        
    }
    void UpdatePause(bool newValue){
        inPause = newValue;
    }
    public int MoveMod(int result, int quantity){
        if(quantity > 1){
            return  result + MoveMod(result, quantity-1);
        }else{
            return result;
        }
    }
}
