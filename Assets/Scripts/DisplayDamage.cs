using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageCanvas = null;
    [SerializeField] [Range(0, 1)] float timeDamageIsShown = 0.2f;

    void Start()
    {
        damageCanvas.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowBloodSplatter());
    }

    IEnumerator ShowBloodSplatter()
    {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(timeDamageIsShown);
        damageCanvas.enabled = false;
    }

}
