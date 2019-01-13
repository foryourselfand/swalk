using UnityEngine;

public class ComponentsManager : MonoBehaviour
{
    public OpacityChanger startButtonsGroup;
    public PositionChanger middleButton;

    private PositionChanger[] startButtons;

    private void Awake()
    {
        var parent = startButtonsGroup.transform;
        startButtons = new PositionChanger[parent.childCount];
        for (var i = 0; i < parent.childCount; i++)
            startButtons[i] = parent.GetChild(i).GetComponent<PositionChanger>();
    }

    private void Start()
    {
        //DeActivate ALL UI
        startButtonsGroup.gameObject.SetActive(false);

        StartAction();
    }

    private void StartAction()
    {
        startButtonsGroup.gameObject.SetActive(true);
        startButtonsGroup.SetOpacityTarget(1);


        middleButton.SetVectorTarget(new Vector2(0, 2), true);


        startButtons[0].SetVectorTarget(new Vector2(-1, 0), true);

        var temp = Random.Range(0, 2) == 0 ? 1 : -1;
        for (var i = 1; i < startButtons.Length - 1; i++)
        {
            startButtons[i].SetVectorTarget(new Vector2(0, temp), true);
            temp *= -1;
        }

        startButtons[startButtons.Length - 1].SetVectorTarget(new Vector2(1, 0), true);

        Invoke("TestFunc", 3F);
    }

    public void TestFunc()
    {
        middleButton.SetClockwiseTarget();
        startButtons[0].SetClockwiseTarget();

        startButtons[startButtons.Length - 1].SetClockwiseTarget();
        startButtonsGroup.SetOpacityTarget(0);
    }
}
