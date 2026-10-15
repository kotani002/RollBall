// ライブラリの宣言 -> これからこの機能を使うよ
using UnityEngine;
using UnityEngine.InputSystem;

public class StageMove : MonoBehaviour
{
    // 変数、関数
    // 変数 -> int,string 値を格納するための箱
    // アクセス修飾子 ＋ データ型(int,string,InputAction) ＋ 変数名(num,name)
    private InputAction moveInput;

    // 関数 -> 処理をまとめて実行するための箱

    // 目的(抽象的課題)：ステージを回転させること
    // 手段（具体的課題）：ActionMapを使用してプレイヤーの入力を受け取る
    //                   受け取った入力を元にステージのRotationを変更する


    
    // Start -> シーンのロード時(ゲームの開始時)に自動的に実行される関数
    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
    }

    public float threshold = 0.2f;
    // Update -> マイフレーム毎(0.1~0.3f刻み)に自動で実行される関数
    void Update()
    {
        Vector3 rotation;

        rotation = new Vector3(
            moveInput.ReadValue<Vector2>().y*threshold ,
            0 ,
            moveInput.ReadValue<Vector2>().x*threshold);

        //this.transform.Rotate(rotation);
        // オイラー角に変換
        Quaternion tilt = Quaternion.Euler(rotation.x, 0f, rotation.z);
        this.gameObject.GetComponent<Rigidbody>().MoveRotation(
            this.gameObject.GetComponent<Rigidbody>().transform.rotation * tilt
            );
    }
}
