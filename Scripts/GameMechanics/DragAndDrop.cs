using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject dragAndDropCursor, UIDeleteObject;
    [SerializeField] private GameObject[] UIElementsToHide;
    [SerializeField]
    private float dragHeight;

    private GameObject selectedObject;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        dragAndDropCursor.SetActive(false);
        UIDeleteObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit = CastRay();
            if (hit.collider != null && hit.collider.CompareTag("Draggable"))
            {
                DragObject(hit.transform.gameObject);
            }
        }

        if (selectedObject != null)
        {
            selectedObject.transform.position = new Vector3(dragAndDropCursor.transform.position.x, dragHeight, dragAndDropCursor.transform.position.z);
            if (Input.GetMouseButtonUp(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    selectedObject.GetComponent<Rigidbody>().useGravity = true;
                    selectedObject = null;
                    dragAndDropCursor.SetActive(false);
                    UIDeleteObject.SetActive(false);
                }
                else
                    DeleteObject();
                ShowUIElements();
            }
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);
        return hit;
    }

    public void DragObject(GameObject gameObject)
    {
        selectedObject = gameObject;
        dragAndDropCursor.SetActive(true);
        UIDeleteObject.SetActive(true);
        selectedObject.GetComponent<Rigidbody>().useGravity = false;
        selectedObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        audioManager.PlaySFX(selectedObject.GetComponent<SpecifiedSounds>().pickupSound);
        HideUIElements();
    }

    private void HideUIElements()
    {
        for (int i = 0; i < UIElementsToHide.Length; i++)
        {
            UIElementsToHide[i].gameObject.SetActive(false);
        }
    }

    private void ShowUIElements()
    {
        for (int i = 0; i < UIElementsToHide.Length; i++)
        {
            UIElementsToHide[i].gameObject.SetActive(true);
        }
    }

    public void DeleteObject()
    {
        Destroy(selectedObject.gameObject);
        selectedObject = null;
        dragAndDropCursor.SetActive(false);
        UIDeleteObject.SetActive(false);
    }
}
