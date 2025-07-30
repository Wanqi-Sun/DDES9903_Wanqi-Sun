using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 鼠标左键或中间点点击
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    Debug.Log("Cube clicked by ray!");
                    SceneManager.LoadScene("BlindBoxShop");
                }
            }
        }
    }
}
