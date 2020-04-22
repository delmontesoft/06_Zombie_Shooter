using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    bool isZoomed = false;

    public void ToggleZoom (float weaponZoomRange)
    {
        if (!isZoomed)
        {
            Camera.main.fieldOfView -= weaponZoomRange;
        }
        else
        {
            Camera.main.fieldOfView += weaponZoomRange;
        }
        isZoomed = !isZoomed;
    }
}
