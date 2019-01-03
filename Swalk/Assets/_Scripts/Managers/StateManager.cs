using UnityEngine;

public class StateManager : MonoBehaviour, _Clickable
{
    public enum GameState
    {
        STARTING,
        MENU,
        TOPIC,
        PLAY,
        ADS,
        OVER,
        ENDING
    }

    public ComponentsManager ComponentsManager;
    public static GameState CURRENT_STATE;
    
    private void Start()
    {
        CURRENT_STATE = GameState.STARTING;
    }

    private void Update()
    {
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