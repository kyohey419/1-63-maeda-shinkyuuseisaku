using UnityEngine;

public class KeyItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // データマネージャーの鍵の数を増やす
            GameDataManager.instance.keyCount++;
            Debug.Log("鍵をゲット！ 現在の数: " + GameDataManager.instance.keyCount);

            // 鍵を消す
            Destroy(gameObject);
        }
    }
}