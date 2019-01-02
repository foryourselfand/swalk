using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    public OpacityChanger test;

    private List<Changer> objectsToChange;

    private void Start()
    {
        objectsToChange = new List<Changer>();
        test.TestFunc();
    }

    public void StartingRestart()
    {
//        objectsToChange.Add(test.GetComponent<OpacityDown>());
    }

    public void UpdateChangers()
    {
        foreach (var changable in objectsToChange)
            changable.Change();
    }
}