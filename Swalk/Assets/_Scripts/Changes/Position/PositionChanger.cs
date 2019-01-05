using UnityEngine;

public abstract class PositionChanger : Changer
{
    protected Transform transformLink;

    protected Vector3 startVector;
    protected Vector3 targetVector;


    private void Awake()
    {
        transformLink = gameObject.transform;
    }

    public void ChangeVector()
    {
        startVector = transformLink.position;
        StartCoroutine(ChangeOverSpeed());
    }

    public override bool CheckTargetRich()
    {
        return transformLink.position == targetVector;
    }
    public override void endSetUp()
    {
        transformLink.position = targetVector;
    }

    public void TestMoving(float seconds)
    {
        targetVector = transformLink.position;
        transformLink.position += new Vector3(0, 100, 0);
        ChangeVector();
    }
}