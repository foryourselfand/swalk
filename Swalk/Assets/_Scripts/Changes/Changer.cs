using System.Collections;
using UnityEngine;

public class Changer : MonoBehaviour
{
    public bool isDone;

    public void StartMagic(IEnumerator routine)
    {
        StartCoroutine(routine);
    }
}