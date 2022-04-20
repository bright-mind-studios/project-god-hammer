using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    private GameObject _id;
    public GameObject Id { get { return _id; } private set { _id = value; } }

    public Status(){}
    public Status(GameObject id)
    {
        Id = id;
    }
}


public class BaseStateController : MonoBehaviour
{
    public State currentState;

    [HideInInspector] public bool stateBoolVariable; // Allows to convert an State from Moore FSM to Mealy FSM
    [HideInInspector] public float stateTimeElapsed; // Internal timer for state's personnal use
    [HideInInspector] public Status activeStatus;

    private struct PendingPushTransition
    {
        public State demandState;
        public State pushedState;
        public Status status;

        public PendingPushTransition(State demandState, State pushedState, Status status)
        {
            this.demandState = demandState;
            this.pushedState = pushedState;
            this.status = status;
        }
    }
    private bool _isActive;
    private List<PendingPushTransition> pendingPushTransitions;


    private void Update()
    {
        if (!_isActive) return;
        OnPendingPushTransitions();
        currentState.UpdateState(this);
    }

    public virtual void InitializeStateMachine(bool activate)
    {
        _isActive = activate;
        pendingPushTransitions = new List<PendingPushTransition>();
        OnExitState();
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != null && nextState != currentState) // Think only first check is needed
        {
            currentState = nextState;
            OnExitState();
        }
    }

    public void FromStatePushTransitionToState(State demandState, State pushedState, bool disposable, Status status = null)
    {
        if (demandState == currentState && pushedState != null)
        {
            currentState = pushedState;
            activeStatus = status;
            OnExitState();
        }
        else if (!disposable && pushedState != null)
        {
            pendingPushTransitions.Add(new PendingPushTransition(demandState, pushedState, status));
        }
    }

    public bool HasTimeElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;

        if (stateTimeElapsed >= duration)
        {
            stateTimeElapsed = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnPendingPushTransitions()
    {
        List<PendingPushTransition> nonCompleted = new List<PendingPushTransition>();

        for (int i = 0; i < pendingPushTransitions.Count; i++)
        {
            PendingPushTransition transition = pendingPushTransitions[i];
            if (transition.demandState == currentState)
            {
                TransitionToState(transition.pushedState);
                activeStatus = transition.status;
                currentState.UpdateState(this);
            } else
            {
                nonCompleted.Add(transition);
            }
        }

        pendingPushTransitions = nonCompleted;
    }

    protected virtual void OnExitState()
    {
        stateBoolVariable = false;
        stateTimeElapsed = 0;
    }

    //Possible OnDrawGizmos 23:55
}
