using UnityEngine;

public class PhoneScreenSwitcher : MonoBehaviour
{
    public Texture[] screenshots;
    private int currentIndex = 0;
    private Renderer screenRenderer;

    void Start()
    {
        screenRenderer = GetComponent<Renderer>();
        if (screenshots.Length > 0)
        {
            screenRenderer.material.mainTexture = screenshots[0];
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
    }
}
