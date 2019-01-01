public class OpacityUp : OpacityChanger
{
    public override void Change()
    {
        targetAlpha = 1;
        base.Change();
    }
}