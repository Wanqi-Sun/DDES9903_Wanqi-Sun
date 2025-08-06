using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;


public class NpcBoxTrigger : MonoBehaviour
{
    [Header("Tag 设置")]
    public string correctBoxTag = "CorrectBox";     // 正确盲盒Tag
    public string wrongBoxTag = "BlindBox";         // 错误盲盒Tag

    [Header("互动反馈组件")]
    public GameObject hiddenButton;                 // 解锁按钮
    public GameObject guidingArrows;                // 地面箭头
    public AudioSource tipSound;                    // 正确盲盒提示音效

    [Header("对话提示 UI")]
    public Canvas dialogCanvas;                     // 字幕Canvas
    public TextMeshProUGUI dialogText;              // 字幕Text

    [Header("音效：错误音 & 失败音")]
    public AudioSource wrongBoxSound;               // 错误盲盒时的音效
    public AudioSource failEndingSound;             // 黑屏失败音效

    [Header("失败结局 UI")]
    public GameObject failureOverlay;               // 黑屏背景 Panel
    public TextMeshProUGUI failureText;             // 黑屏文字字幕

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag(correctBoxTag))
        {
            Debug.Log("✅ 正确盲盒放对啦！");
            hasTriggered = true;

            // 解锁隐藏按钮
            if (hiddenButton != null)
                hiddenButton.SetActive(true);

            // 出现地面引导箭头
            if (guidingArrows != null)
                guidingArrows.SetActive(true);

            // 播放提示音
            if (tipSound != null)
                tipSound.Play();

            // 显示对话文字
            if (dialogCanvas != null && dialogText != null)
            {
                dialogCanvas.gameObject.SetActive(true);
                dialogText.text = "Wow! This is true blind box!";
                StartCoroutine(HideDialogAfterSeconds(3f));
            }
        }
        else if (other.CompareTag(wrongBoxTag))
        {
            Debug.Log("❌ 错误盲盒放入");

            // 显示失望字幕
            if (dialogCanvas != null && dialogText != null)
            {
                dialogCanvas.gameObject.SetActive(true);
                dialogText.text = "Oh no, this isn't the blind box I wanted.";

                if (wrongBoxSound != null)
                    wrongBoxSound.Play(); // 播放 NPC 的“叹气”或“失望”音效

                StartCoroutine(TriggerFailureEndingAfterDelay(3f));
            }
        }
    }

    // 自动隐藏字幕 Canvas
    IEnumerator HideDialogAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (dialogCanvas != null)
            dialogCanvas.gameObject.SetActive(false);
    }

    // 延迟黑屏 + 显示失败字幕 + 播放失败音效
    IEnumerator TriggerFailureEndingAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);

    if (dialogCanvas != null)
        dialogCanvas.gameObject.SetActive(false);

    if (failureOverlay != null)
        failureOverlay.SetActive(true);

    if (failureText != null)
    {
        failureText.text =
            "Since you didn't give the little girl the correct blind box,\n" +
            "you cannot unlock the hidden blind box...";
    }

    if (failEndingSound != null)
        failEndingSound.Play();

    // ⏳ 再等待几秒，让用户有时间看到文字（可选）
    yield return new WaitForSeconds(5f);

    // ✅ 跳转到 EndScene
    SceneManager.LoadScene("EndScene");
}

}

