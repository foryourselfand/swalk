using System;
using UnityEngine;

public abstract class PositionChanger : MonoBehaviour
{
    public float speed;

    protected Transform _transformLink;

    protected Vector3 _targetVector;

    private const float Tolerance = 0.1f;

    private bool _changing;

    private void Awake()
    {
        _transformLink = gameObject.transform;
    }

    public abstract void Change(float t);

    private void Update()
    {
        if (!_changing) return;
        if (Vector3.SqrMagnitude(_transformLink.position - _targetVector) > Tolerance)
        {
            Change(speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("End");
            _changing = false;
            _transformLink.position = _targetVector;
        }
    }

    public void TestMoving()
    {
        _changing = true;
        _targetVector = _transformLink.position;
        _transformLink.position += new Vector3(0, 100, 0);
    }
}