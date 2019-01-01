using UnityEngine;

public class StateClicker : MonoBehaviour, _Clickable
{
    public void ActionOnClick()
    {
        switch (StateHolder.CURRENT_STATE)
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