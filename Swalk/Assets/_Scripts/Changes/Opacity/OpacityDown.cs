public class OpacityDown : OpacityChanger
{
    public override void Change()
    {
        targetAlpha = 0;
        base.Change();
    }
}