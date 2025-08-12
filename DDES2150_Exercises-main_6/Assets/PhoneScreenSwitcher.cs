using UnityEngine;

public class PhoneScreenSwitcher : MonoBehaviour
{
    public Texture[] screenshots;
    private int currentIndex = 0;
    private Renderer screenRenderer;

    [Header("提示文字对象")]
    public GameObject tipTextObject;  // 在 Inspector 拖进去你的提示文字

    void Start()
    {
        screenRenderer = GetComponent<Renderer>();
        if (screenshots.Length > 0)
        {
            screenRenderer.material.mainTexture = screenshots[0];
        }

        // 一开始隐藏提示文字
        if (tipTextObject != null)
        {
            tipTextObject.SetActive(false);
        }
    }

    public void AdvanceImage()
    {
        if (screenshots.Length == 0) return;

        currentIndex++;
        if (currentIndex >= screenshots.Length)
        {
            currentIndex = screenshots.Length - 1; // 停在最后一张
        }

        screenRenderer.material.mainTexture = screenshots[currentIndex];

        // 切到第三张（索引2）时显示提示文字
        if (currentIndex == 2 && tipTextObject != null)
        {
            tipTextObject.SetActive(true);
        }
    }
}
