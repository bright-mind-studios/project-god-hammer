using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateController : MonoBehaviour
{
    public State currentState;

    [HideInInspector] public bool stateBoolVariable; // Allows to convert an State from Moore FSM to Mealy FSM
    [HideInInspector] public float stateTimeElapsed; // Internal timer for state's personnal use

    private struct PendingPushTransition
    {
        public State demandState;
        public State pushedState;

        public PendingPushTransition(State demandState, State pushedState)
        {
            this.demandState = demandState;
            this.pushedState = pushedState;
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
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != null && nextState != currentState) // Think only first check is needed
        {
            currentState = nextState;
            OnExitState();
        }
    }

    public void FromStatePushTransitionToState(State demandState, State pushedState, bool disposable)
    {
        if (demandState == currentState && pushedState != null)
        {
            currentState = pushedState;
            OnExitState();
        }
        else if (!disposable && pushedState != null)
        {
            pendingPushTransitions.Add(new PendingPushTransition(demandState, pushedState));
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
        List<int> completedPushTransitions =  new List<int>();

        for (int i = 0; i < pendingPushTransitions.Count; i++)
        {
            PendingPushTransition transition = pendingPushTransitions[i];
            if (transition.demandState == currentState)
            {
                completedPushTransitions.Add(i);
                TransitionToState(transition.pushedState);
                currentState.UpdateState(this);
            }
        }

        foreach (var transitionIdx in completedPushTransitions)
        {
            pendingPushTransitions.RemoveAt(transitionIdx);
        }
    }

    private void OnExitState()
    {
        stateBoolVariable = false;
        stateTimeElapsed = 0;
    }

    //Possible OnDrawGizmos 23:55
}
