using UnityEngine;

public class Clicker : MonoBehaviour
{
    public void ActionOnClick()
    {
        GetComponent<_Clickable>().ActionOnClick();
    }
}