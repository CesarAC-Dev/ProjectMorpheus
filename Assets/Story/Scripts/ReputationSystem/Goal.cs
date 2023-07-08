using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Goal: MonoBehaviour
{
    [SerializeField] private int reputationLevelNecessary;
    [SerializeField] private bool goalDone;
    [SerializeField] private bool persistantGoal;
    public abstract void GoalTask();

    public int GetReputationLevelNecessary(){
        return reputationLevelNecessary;
    }
    public bool GetGoalDone(){
        return goalDone;
    }
    public bool GetPersistantGoal(){
        return persistantGoal;
    }
    public void SetReputationLevelNecessary(int level){
        reputationLevelNecessary = level;
    }
    public void SetGoalDone(bool done){
        goalDone = done;
    }

    public void SetPersistantGoal(bool persistant){
        persistantGoal = persistant;
    }
}
