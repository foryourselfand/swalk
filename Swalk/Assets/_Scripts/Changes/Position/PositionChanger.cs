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
        elapsedTime = 0;
    }

    protected override bool CheckWithTolerance()
    {
        return Vector2.SqrMagnitude(PositionLink - _targetVector) > Vector2.kEpsilon;
    }

    protected override void Change(float t)
    {
        PositionLink = Vector2.MoveTowards(PositionLink, _targetVector, t);
    }

//    var value = (speed * (elapsedTime) - 1);
    private float elapsedTime;

    protected override void ChangeSpeed()
    {
        elapsedTime += Time.deltaTime;
        var qqq = speed * elapsedTime;
        var www = Vector2.SqrMagnitude(PositionLink - _targetVector);
        var eee = www / qqq;
//        speed -= value;
        Debug.Log(string.Format("{0}\t{1}\t{2}", qqq.ToString(), www.ToString(), eee.ToString()));

        if (Vector2.SqrMagnitude(PositionLink - _targetVector) < 0.25)
        {
            speed -= eee;
        }
    }
}
