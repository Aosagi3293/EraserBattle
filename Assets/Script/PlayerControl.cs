using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    // プレイヤー
    private GameObject player;

    // フリックの座標
    private Vector2 flickStartPos;
    private Vector2 flickEndPos;

    private void Start()
    {
        player = this.gameObject;
    }

    private void Update()
    {
        // マウスの左クリックの開始を検知
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            flickStartPos = Mouse.current.position.ReadValue();
        }

        // マウスの左クリックの終わりを検知
        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            flickEndPos = Mouse.current.position.ReadValue();
            Flick();
        }
    }

    private void Flick()
    {
        // フリックの強さと方向の計算
        Vector2 flickVector = flickEndPos - flickStartPos;
        float flickStrength = flickVector.magnitude;
        Vector2 flickDirection = flickVector.normalized;

        // フリックの強さの制限
        float flickForce = Mathf.Clamp(flickStrength, 1f, 1000f);

        // フリックの方向とは逆方向にプレイヤーを移動させる
        player.transform.position += new Vector3(-flickDirection.x, 0, -flickDirection.y) * flickForce * Time.deltaTime;
    }
}
