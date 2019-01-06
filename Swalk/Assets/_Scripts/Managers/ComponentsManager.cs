using UnityEngine;

public class ComponentsManager : MonoBehaviour
{
//    public OpacityChanger startButtonsGroup;

//    private PositionSmooth[] startButtons;

    public PositionTransformChanger button;

    private void Awake()
    {
//        Transform parent = startButtonsGroup.transform;
//        startButtons = new PositionSmooth[parent.childCount];
//        for (int i = 0; i < parent.childCount; i++)
//            startButtons[i] = parent.GetChild(i).GetComponent<PositionSmooth>();
    }

    private void Start()
    {
//        startButtonsGroup.gameObject.SetActive(false);

//        StartAction();
        button.TestMoving();
    }

    private void StartAction()
    {
//        startButtonsGroup.gameObject.SetActive(true);

//        foreach (var startButton in startButtons)
//        {
//            startButton.TestMoving();
//        }
    }
}