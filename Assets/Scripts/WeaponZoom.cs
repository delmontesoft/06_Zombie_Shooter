using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    //TODO define weapon zoom sensitivity with a formula or a value that is weapon dependant
    [SerializeField] float zoomedOutSensitivity = 2f;
    [SerializeField] float zoomedInSensitivity = 1.5f;
    [SerializeField] float zoomedOutFOV = 60f;

    RigidbodyFirstPersonController fpsController = null;

    private void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    public void ToggleZoom(bool toggleZoom, float weaponZoomRange)
    {
        if (toggleZoom)
        {
            ZoomIn(weaponZoomRange);
        }
        else
        {
            ZoomOut();
        }
    }

    private void ZoomIn(float weaponZoomRange)
    {
        Camera.main.fieldOfView -= weaponZoomRange;
        fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
    }

    private void ZoomOut()
    {
        Camera.main.fieldOfView = zoomedOutFOV;
        fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }
}

