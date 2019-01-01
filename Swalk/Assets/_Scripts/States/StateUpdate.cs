using UnityEngine;

public class StateUpdate : MonoBehaviour
{
    public Manipulator manipulator;
    
    private void Start()
    {
        StateHolder.CURRENT_STATE = GameState.STARTING;
        manipulator.StartingRestart();
    }

    private void Update()
    {
        manipulator.UpdateChangers();
        switch (StateHolder.CURRENT_STATE)
        {
            case GameState.STARTING:
                
                break;
        }
    }
}