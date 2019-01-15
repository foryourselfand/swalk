using UnityEngine;

public class ComponentsManager : MonoBehaviour
{
    #region UI Groups

    [SerializeField] private OpacityChanger _startButtonsGroup;

    #endregion

    [SerializeField] private PositionChanger _camera;

    private PositionChanger[] _startButtons;

    private void Awake()
    {
        var parent = _startButtonsGroup.transform;
        _startButtons = new PositionChanger[parent.childCount];
        for (var i = 0; i < parent.childCount; i++)
            _startButtons[i] = parent.GetChild(i).GetComponent<PositionChanger>();
    }

    private void Start()
    {
        //DEACTIVATE ALL UI
        _startButtonsGroup.gameObject.SetActive(false);

        StartAction();
    }

    private void StartAction()
    {
        _startButtonsGroup.gameObject.SetActive(true);
        _startButtonsGroup.SetOpacityTarget(1);


        _camera.SetTargetFromStart(new Vector2(1, 0));


        _startButtons[0].SetTargetFromStart(new Vector2(-1, 0));

        var temp = Random.Range(0, 2) == 0 ? 1 : -1;
        for (var i = 1; i < _startButtons.Length - 1; i++)
        {
            _startButtons[i].SetTargetFromStart(new Vector2(0, temp));
            temp *= -1;
        }

        _startButtons[_startButtons.Length - 1].SetTargetFromStart(new Vector2(1, 0));

        Invoke("TestFunc", 3);
    }

    public void TestFunc()
    {
        _camera.SetTargetFromCurrent(new Vector2(0, 1));


        _startButtons[0].SetPreviousTarget();

        for (var i = 1; i < _startButtons.Length - 1; i++)
            _startButtons[i].SetContinuingTarget();

        _startButtons[_startButtons.Length - 1].SetPreviousTarget();


        _startButtonsGroup.SetOpacityTarget(0);
    }
}