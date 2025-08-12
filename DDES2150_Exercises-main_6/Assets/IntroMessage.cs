using UnityEngine;
using TMPro;

public class IntroMessage : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public float displayTime = 4f; // 显示几秒

    void Start()
    {
        if (introText != null)
        {
            introText.gameObject.SetActive(true);
            Invoke("HideText", displayTime);
        }
    }

    void HideText()
    {
        introText.gameObject.SetActive(false);
    }
}
