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
        startButtonsGroup.gameObject.SetActive(false);

        StartAction();
    }

    private void StartAction()
    {
        startButtonsGroup.gameObject.SetActive(true);
        startButtonsGroup.SetOpacityTarget(1);

        for (var i = 0; i < startButtons.Length; i++)
        {
            startButtons[i].SetVectorTarget(new Vector2(0, 1));
        }

        middleButton.SetVectorTarget(new Vector2(0, 1));
    }
}