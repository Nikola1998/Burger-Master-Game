using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerMenu : MonoBehaviour
{
    public static DebuggerMenu instance;

    public bool hasTimeLimit;
    [Range(10f, 60f)]
    public float timeLimit = 15f;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleTimeLimit()
    {
        if (hasTimeLimit)
            hasTimeLimit = false;
        else
            hasTimeLimit = true;
    }

    public void SetTimeLimit(float seconds)
    {
        timeLimit = seconds;
    }
}
