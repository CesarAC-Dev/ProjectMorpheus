using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reputation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int reputationLevel;
    [SerializeField] private Goal[] goals;
    private int goalToDo;
    void Start()
    {
        goals = GetComponents<Goal>();
        System.Array.Sort(goals,(obj1,obj2) => obj1.GetReputationLevelNecessary().CompareTo(obj2.GetReputationLevelNecessary()));
        goalToDo = -1;
        checkGoals();
    }
    public void checkGoals(){
        Goal goal;
        for(int i = 0;i<goals.Length;i++){
            goal = goals[i];
            if(goal.GetReputationLevelNecessary() <= reputationLevel){
                if(!goal.GetGoalDone()){
                    goalToDo = i;
                    break;
                }
            }else{
                break;
            }
        }
    }

    public void DoGoals(){
        if(goalToDo!=-1){
            goals[goalToDo].GoalTask();
        }
        checkGoals();
    }
}
