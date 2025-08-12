using UnityEngine;

public class HiddenButton : MonoBehaviour
{
    public GameObject hiddenBoxPrefab;  // 你的隐藏款盲盒预制体
    public Transform spawnPoint;        // 掉落位置

    public void DropHiddenBox()
    {
        Instantiate(hiddenBoxPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("隐藏款盲盒掉落啦！");
    }
}
