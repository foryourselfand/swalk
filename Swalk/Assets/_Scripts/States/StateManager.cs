using UnityEngine;

public class StateManager : MonoBehaviour, _Clickable
{
    public Manipulator manipulator;
    public static GameState CURRENT_STATE;

    private void Start()
    {
        CURRENT_STATE = GameState.STARTING;
        manipulator.StartingRestart();
    }

    private void Update()
    {
        manipulator.UpdateChangers();
        switch (CURRENT_STATE)
        {
            case GameState.STARTING:

                break;
        }
    }

    public void ActionOnClick()
    {
        switch (CURRENT_STATE)
        {
            case GameState.STARTING:
                Debug.Log("StateClicker Starting");

                break;

            case GameState.MENU:

                Debug.Log("StateClicker MENU");
                break;

            case GameState.TOPIC:

                Debug.Log("StateClicker TOPIC");
                break;

            case GameState.PLAY:

                Debug.Log("StateClicker PLAY");
                break;

            case GameState.OVER:

                Debug.Log("StateClicker OVER");
                break;
        }
    }
}