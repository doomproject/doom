using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button_Cooldown : MonoBehaviour
{
    public Image imageToCooldown;

    public void Start()
    {
        //imageToCooldown.enabled = false;
    }

    public void _StartCooldown()
    {
        this.GetComponent<Button>().enabled = false;
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        imageToCooldown.enabled = true;

        float elapsedTime = 0;
        while (imageToCooldown.fillAmount > 0)
        {
            imageToCooldown.fillAmount = Mathf.Lerp(1, 0, (elapsedTime/3f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imageToCooldown.fillAmount = 1;
        imageToCooldown.enabled = false;
        this.GetComponent<Button>().enabled = true;
    }
}
