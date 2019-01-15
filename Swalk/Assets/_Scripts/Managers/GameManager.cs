using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameState CURRENT_STATE;

    private void Start()
    {
        CURRENT_STATE = GameState.Starting;
    }
}