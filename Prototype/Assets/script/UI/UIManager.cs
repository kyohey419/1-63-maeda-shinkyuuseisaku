using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    [Header("設定")]
    public GameObject objectToHide; // 隠したいもの
    public GameObject objectToShow; // 出したいもの

    void Start()
    {
        // ボタンコンポーネントを取得して、クリック時のイベントを自動登録
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(Switch);
        }
    }

    public void Switch()
    {
        if (objectToHide != null) objectToHide.SetActive(false);
        if (objectToShow != null) objectToShow.SetActive(true);
    }
}