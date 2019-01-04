using UnityEngine;

public class ComponentsManager : MonoBehaviour
{
    public OpacityChanger ButtonIAP;

    private void Start()
    {
        ButtonIAP.ChangeAlphaOverSeconds(5, 0);
    }
}