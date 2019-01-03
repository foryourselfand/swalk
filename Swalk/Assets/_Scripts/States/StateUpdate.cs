using UnityEngine;

public class StateUpdate : MonoBehaviour
{
    private void Update()
    {
        switch (GameManager.CURRENT_STATE)
        {
            case GameState.STARTING:

                break;
        }
    }
}