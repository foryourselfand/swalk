using UnityEngine;

public abstract class PositionChanger : Changer
{
    protected Vector2 _targetVector;

    protected Vector2 _positionLink;

    public Vector2 PositionLink
    {
        private get { return _positionLink; }
        set
        {
            _positionLink = value;
            setLink(_positionLink);
        }
    }

    private float lastX, lastY;

    private bool fromSlow;

    public void SetVectorTarget(Vector2 targetVector, bool needToMove)
    {
        changing = true;
        lastX = targetVector.x;
        lastY = targetVector.y;
        _targetVector = PositionLink + targetVector;
        if (!needToMove) return;
        _targetVector -= targetVector;
        PositionLink += targetVector;
    }

    public void SetVectorTarget(Vector2 targetVector)
    {
        SetVectorTarget(targetVector, false);
    }

    public void SetClockwiseTarget()
    {
        SetVectorTarget(new Vector2(lastX, lastY));
    }

    protected abstract void setLink(Vector2 value);


    protected override void ActionOnEnd()
    {
        Debug.Log(string.Format("///{0} position///", name));
        PositionLink = _targetVector;
        fromSlow = true;
        elapsedTime = 0;
    }


    protected override bool CheckWithTolerance()
    {
        return Vector2.SqrMagnitude(PositionLink - _targetVector) > Vector2.kEpsilon;
    }

    private Vector2 velocity = Vector2.zero;

    private float elapsedTime;


    protected override void Change(float t)
    {
//        PositionLink = Vector2.SmoothDamp(PositionLink, _targetVector, ref velocity, 0.1f * speed);

        if (!fromSlow)
        {
            PositionLink = Vector2.Lerp(PositionLink, _targetVector, Time.deltaTime * speed);
        }
        else
        {
            elapsedTime += Time.deltaTime / speed;
            PositionLink = Vector2.Lerp(PositionLink, _targetVector, elapsedTime);
        }
    }
}
