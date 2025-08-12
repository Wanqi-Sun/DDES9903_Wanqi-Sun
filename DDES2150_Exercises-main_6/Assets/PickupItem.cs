using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private AudioSource blingSound;

    [Header("闪光粒子 Prefab")]
    public GameObject sparklePrefab;

    [Header("结局控制器")]
    public SuccessEndingSimple successManager;

    void Start()
    {
        blingSound = GetComponent<AudioSource>();
    }

    public void PickUp()
    {
        Debug.Log("盲盒被拿起了！");

        if (blingSound != null)
        {
            blingSound.Play();
        }

        if (sparklePrefab != null)
        {
            Instantiate(sparklePrefab, transform.position, Quaternion.identity);
        }

        // ✅ 触发结局
        if (successManager != null)
        {
            successManager.TriggerSuccessEnding();
        }
    }
}
