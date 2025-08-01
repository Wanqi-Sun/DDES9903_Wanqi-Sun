using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class SuccessEndingSimple : MonoBehaviour
{
    public Image whiteScreen;
    public TextMeshProUGUI successMessage;
    public float delayBeforeShow = 3f;

    void Start()
    {
        whiteScreen.gameObject.SetActive(false);
        successMessage.gameObject.SetActive(false);
    }

    public void TriggerSuccessEnding()
    {
        StartCoroutine(ShowEnding());
    }

    IEnumerator ShowEnding()
    {
        yield return new WaitForSeconds(delayBeforeShow);

        whiteScreen.gameObject.SetActive(true);
        successMessage.gameObject.SetActive(true);
    }
}
