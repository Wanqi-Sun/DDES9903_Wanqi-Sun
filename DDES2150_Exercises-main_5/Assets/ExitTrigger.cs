using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ExitTrigger : MonoBehaviour
{
    public Image blackScreen;                // 黑屏 UI
    public TextMeshProUGUI messageText;                 // 显示文本
    public string failMessage = "You didn’t help the little girl, so you cannot unlock the hidden blind box...";
    public float fadeDuration = 1.5f;
    public float messageDuration = 3f;

    public AudioSource failEndingAudio;      // 失败音效

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(FailEndingSequence());
        }
    }

    IEnumerator FailEndingSequence()
    {
        // 播放音效
        if (failEndingAudio != null) failEndingAudio.Play();

        // 黑屏淡入
        blackScreen.gameObject.SetActive(true);
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            blackScreen.color = new Color(0, 0, 0, t / fadeDuration);
            yield return null;
        }
        blackScreen.color = Color.black;

        // 显示失败文字
        messageText.text = failMessage;
        messageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(messageDuration);

        // 可加上跳转或结束逻辑
        Debug.Log("Fail ending complete.");

        SceneManager.LoadScene("EndScene");

    }
}
