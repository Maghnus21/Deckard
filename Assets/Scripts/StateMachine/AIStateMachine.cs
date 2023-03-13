using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine
{
    public AIState[] states;
    public AIAgent agent;
    public AIStateID currentState;

    public AIStateMachine(AIAgent agent)
    {
        this.agent = agent;

        int numStates = System.Enum.GetNames(typeof(AIStateID)).Length;
        states = new AIState[numStates];
    }

    public void RegisterState(AIState state)
    {
        int index = (int)state.getID();
        states[index] = state;
    }

    public AIState getState(AIStateID stateID)
    {
        int index = (int)stateID;
        return states[index];
    }

    public void Update()
    {
        getState(currentState)?.Update(agent);
    }

    public void ChangeState(AIStateID newState)
    {
        getState(currentState)?.Exit(agent);
        currentState = newState;
        getState(currentState)?.Enter(agent);
    }
}
