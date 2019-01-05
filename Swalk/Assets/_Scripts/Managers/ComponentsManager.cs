using UnityEngine;

public class ComponentsManager : MonoBehaviour
{
    public OpacityChanger startButtonsGroup;

//    private PositionSmooth[] startButtons;
//    private void Awake()
//    {
//        Transform parent = startButtonsGroup.transform;
//        startButtons = new PositionSmooth[parent.childCount];
//        for (int i = 0; i < parent.childCount; i++)
//        {
//            Debug.Log(parent.GetChild(i).name);
//            startButtons[i] = parent.GetChild(i).GetComponent<PositionSmooth>();
//        }
//    }

    private void Start()
    {
        startButtonsGroup.SetTarget(0);
//        foreach (var startButton in startButtons)
//        {
//            startButton.TestMoving(10f);
//        }
    }
}