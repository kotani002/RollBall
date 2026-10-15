using TMPro;
using UnityEngine;

public class GoalPrefab : MonoBehaviour
{
    // SerializeField -> privateな変数をInspector上に表示
    [SerializeField]
    private TextMeshProUGUI goalText;

    // IsTriggerに反応があるか確認
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        // Canvasにゴールした情報を送る
        goalText.enabled = true;
    }
    //EX.壁を増やして迷路を作ろう
}
