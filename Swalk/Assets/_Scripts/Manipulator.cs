using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    public Changer test;

    private List<Changer> objectsToChange;

    private void Start()
    {
        objectsToChange = new List<Changer>();
    }

    public void StartingRestart()
    {
        objectsToChange.Add(test.GetComponent<OpacityUp>());
    }

    public void UpdateChangers()
    {
        foreach (var changable in objectsToChange)
            changable.Change();
    }
}