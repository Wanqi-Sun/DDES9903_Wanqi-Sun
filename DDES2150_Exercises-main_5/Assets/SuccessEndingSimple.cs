using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // ⭐️ 别忘了添加这个
using System.Collections;

public class SuccessEndingSimple : MonoBehaviour
{
    public Image whiteScreen;
    public TextMeshProUGUI successMessage;
    public float delayBeforeShow = 3f;
    public float delayBeforeSceneChange = 3f; // ⭐️ 新增：显示完后再等几秒跳转场景

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
        yield return new WaitForSeconds(delayBeforeSceneChange); // ⭐️ 等待一段时间再切换

        SceneManager.LoadScene("EndScene"); // ⭐️ 加载下一个场景


    }
}
