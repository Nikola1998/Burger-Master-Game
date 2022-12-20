using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeLimitMode : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeCounter;
    [SerializeField]
    private GameObject[] UIToHideAfterEnd;
    [SerializeField]
    private GameObject[] UIToShowAfterEnd;

    private CameraControl cameraControl;
    private DebuggerMenu debugger;
    private float currentTime;

    private void Start()
    {
        debugger = FindObjectOfType<DebuggerMenu>();
        if (!debugger.hasTimeLimit)
        {
            timeCounter.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        currentTime = debugger.timeLimit;
        cameraControl = FindObjectOfType<CameraControl>();
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timeCounter.SetText(currentTime.ToString("0"));

        if (currentTime < 0)
            EndGameSession();
    }

    private void EndGameSession()
    {
        if (cameraControl.mainCameraActive)
            cameraControl.ToggleCameras();
        for (int i = 0; i < UIToHideAfterEnd.Length; i++)
            UIToHideAfterEnd[i].SetActive(false);
        for (int i = 0; i < UIToShowAfterEnd.Length; i++)
            UIToShowAfterEnd[i].SetActive(true);
    }
}
