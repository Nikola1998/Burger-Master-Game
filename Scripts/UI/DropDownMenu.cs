using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownMenu : MonoBehaviour
{
    [SerializeField]
    private float toggleDistance, toggleSpeed;
    [SerializeField]
    private GameObject menu;
    
    private float startPoint, endPoint;
    private bool show;

    private void Start()
    {
        startPoint = menu.transform.position.y;
        endPoint = startPoint - toggleDistance;
        show = true;
    }

    private void Update()
    {
        if (show && menu.transform.position.y < startPoint)
            menu.transform.position += Vector3.up * toggleSpeed * Time.deltaTime;
        else if (!show && menu.transform.position.y > endPoint)
            menu.transform.position += Vector3.down * toggleSpeed * Time.deltaTime;
    }

    public void ToggleMenu()
    {
        if (show)
            show = false;
        else
            show = true;
    }
}
