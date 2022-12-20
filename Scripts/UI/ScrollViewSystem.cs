using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewSystem : MonoBehaviour
{
    private ScrollRect scrollRect;
    [SerializeField]
    private ScrollButton leftButton, rightButton;
    [SerializeField]
    private float scrollSpeed;

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    private void Update()
    {
        if (leftButton.isDown)
        {
            ScrollLeft();
        }
        if (rightButton.isDown)
        {
            ScrollRight();
        }
    }

    private void ScrollLeft()
    {
        if (scrollRect.horizontalNormalizedPosition >= 0f)
        {
            scrollRect.horizontalNormalizedPosition -= scrollSpeed * Time.deltaTime;
        }
    }

    private void ScrollRight()
    {
        if (scrollRect.horizontalNormalizedPosition <= 1f)
        {
            scrollRect.horizontalNormalizedPosition += scrollSpeed * Time.deltaTime;
        }
    }
}
