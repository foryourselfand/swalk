using UnityEngine;

public class ComponentsManager : MonoBehaviour
{
    #region UI Groups

    [SerializeField] private OpacityChanger startButtonsGroup;

    #endregion

    [SerializeField] private PositionChanger camera;

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
        //DEACTIVATE ALL UI
        startButtonsGroup.gameObject.SetActive(false);

        StartAction();
    }

    private void StartAction()
    {
        startButtonsGroup.gameObject.SetActive(true);
        startButtonsGroup.SetOpacityTarget(1);


        camera.SetTargetFromStart(new Vector2(0, 1f));


        startButtons[0].SetTargetFromStart(new Vector2(-1, 0));

        var temp = Random.Range(0, 2) == 0 ? 1 : -1;
        for (var i = 1; i < startButtons.Length - 1; i++)
        {
            startButtons[i].SetTargetFromStart(new Vector2(0, temp));
            temp *= -1;
        }

        startButtons[startButtons.Length - 1].SetTargetFromStart(new Vector2(1, 0));

        Invoke("TestFunc", 3);
    }

    public void TestFunc()
    {
        camera.SetPreviousTarget();


        startButtons[0].SetPreviousTarget();

        for (var i = 1; i < startButtons.Length - 1; i++)
            startButtons[i].SetContinuingTarget();

        startButtons[startButtons.Length - 1].SetPreviousTarget();


        startButtonsGroup.SetOpacityTarget(0);
    }
}