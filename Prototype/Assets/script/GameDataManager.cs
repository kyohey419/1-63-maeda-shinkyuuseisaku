using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;

    // 拾った鍵の数
    public int keyCount = 0;
    // 必要な鍵の総数
    public int totalKeysRequired = 3;

    void Awake()
    {
        // シーンをまたいでもこのオブジェクトを破壊しない設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}