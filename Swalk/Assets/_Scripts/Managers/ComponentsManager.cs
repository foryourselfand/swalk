using System.Collections.Generic;
using UnityEngine;

public class ComponentsManager : MonoBehaviour
{
    public OpacityChanger ButtonIAP;

    private void Start()
    {
        ButtonIAP.TestFunc();
    }
}