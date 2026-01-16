using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform target; // プレイヤーのTransform

    void Update()
    {
        if (target != null)
        {
            // プレイヤーの方向を向く
            transform.LookAt(target);

            // Y軸のみ回転させる
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180, 0);
        }
    }
}