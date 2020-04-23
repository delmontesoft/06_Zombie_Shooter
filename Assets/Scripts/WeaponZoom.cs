using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    //TODO define weapon zoom sensitivity with a formula or a value that is weapon dependant
    [SerializeField] float zoomedOutSensitivity = 2f;
    [SerializeField] float zoomedInSensitivity = 1.5f;

    bool isZoomed = false;
    RigidbodyFirstPersonController fpsController = null;

    private void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    public void ToggleZoom (float weaponZoomRange)
    {
        if (!isZoomed)
        {
            Camera.main.fieldOfView -= weaponZoomRange;
            fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
            fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
        }
        else
        {
            Camera.main.fieldOfView += weaponZoomRange;
            fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
            fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
        }
        isZoomed = !isZoomed;
    }
}
