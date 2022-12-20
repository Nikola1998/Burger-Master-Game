using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera, highlightCamera;

    [SerializeField]
    private float minRotation, maxRotation, sensitivity;

    [SerializeField]
    private GameObject rotationPoint;
    [SerializeField]
    private GameObject[] UIToHide;


    public bool mainCameraActive;
    private float rotationY, rotationX;
    private DragAndDrop dragAndDrop;
    

    private void Start()
    {
        mainCameraActive = true;
        dragAndDrop = FindObjectOfType<DragAndDrop>();
    }

    private void Update()
    {
        
        if (!mainCameraActive && Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
            rotationY += mouseX;
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, minRotation, maxRotation);

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }

    public void ToggleCameras()
    {
        if (mainCameraActive)
        {
            mainCameraActive = false;
            mainCamera.gameObject.SetActive(false);
            highlightCamera.gameObject.SetActive(true);
            dragAndDrop.gameObject.SetActive(false);
            for (int i = 0; i < UIToHide.Length; i++)
                UIToHide[i].gameObject.SetActive(false);
        }
        else
        {
            mainCameraActive = true;
            mainCamera.gameObject.SetActive(true);
            highlightCamera.gameObject.SetActive(false);
            dragAndDrop.gameObject.SetActive(true);
            for (int i = 0; i < UIToHide.Length; i++)
                UIToHide[i].gameObject.SetActive(true);
        }
    }
}
