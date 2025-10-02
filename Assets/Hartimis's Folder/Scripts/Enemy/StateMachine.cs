using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public PatrolState patrolState;

    public void Initialized()
    {
        patrolState = new PatrolState();
        ChangeState(patrolState);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.Preformed();
        }
    }

    public void ChangeState(BaseState newState)
    {
        // Check to see if the active state is != Null
        if(activeState != null)
            {
            // Run Clean up on the Active State.
            activeState.Exit();
            }
        // Changes to new state.
        activeState = newState;

        // fail-safe null check to make sure the new state is not null
        if (activeState != null)
        {
            // Setup new state.
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
