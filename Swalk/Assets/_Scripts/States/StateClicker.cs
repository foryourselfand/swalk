using UnityEngine;

public class StateClicker : MonoBehaviour, _Clickable
{
    public void ActionOnClick()
    {
        switch (GameManager.CURRENT_STATE)
        {
            case GameState.Starting:
                Debug.Log("StateClicker Starting");

                break;

            case GameState.Menu:

                Debug.Log("StateClicker MENU");
                break;

            case GameState.Topic:

                Debug.Log("StateClicker TOPIC");
                break;

            case GameState.Play:

                Debug.Log("StateClicker PLAY");
                break;

            case GameState.Over:

                Debug.Log("StateClicker OVER");
                break;
        }
    }
}