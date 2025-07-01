using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private AudioSource blingSound;

    [Header("闪光粒子 Prefab")]
    public GameObject sparklePrefab;  // 拖你做好的粒子效果进来

    void Start()
    {
        // 获取挂在自己身上的 AudioSource
        blingSound = GetComponent<AudioSource>();
    }

    public void PickUp()
    {
        Debug.Log("盲盒被拿起了！");

        // 在拿起时播放 bling~bling~ 声音
        if (blingSound != null)
        {
            blingSound.Play();
        }

        // 在拿起时生成闪光粒子
        if (sparklePrefab != null)
        {
            Instantiate(sparklePrefab, transform.position, Quaternion.identity);
        }

        // 这里写你原本的“把盲盒拿起”的逻辑
    }
}
