using UnityEngine;
using UnityEngine.UI;

public class QuitGameButton : MonoBehaviour
{
    void Start()
    {
        // ボタンコンポーネントを取得してクリックイベントを登録
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(QuitGame);
        }
    }

    public void QuitGame()
    {
        // 1. デバッグログ（動いているか確認用）
        Debug.Log("ゲームを終了します");

        // 2. 実際にアプリを終了させる処理
        Application.Quit();

        // 3. Unityエディタ上で再生を停止させる（エディタ専用の処理）
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}