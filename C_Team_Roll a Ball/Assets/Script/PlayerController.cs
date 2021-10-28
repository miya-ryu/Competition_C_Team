using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed; // 動く速さ
    public Text scoreText; // スコアの UI
    public Text ClearText; // リザルトの UI
    private Rigidbody rb; // Rididbody
    public int score; // スコア
    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();
        // UI を初期化
        score = 0;
        SetCountText();
        ClearText.text = "";
    }
    void FixedUpdate()
    {
        // カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        // カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);
        // Ridigbody に力を与えて玉を動かす
        rb.AddForce(movement * speed);
    }
    // 玉が他のオブジェクトにぶつかった時に呼び出される
    void OnTriggerEnter(Collider other)
    {
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Item"))
        {
            // その収集アイテムを非表示にします
            other.gameObject.SetActive(false);
            // スコアを加算します
            score = score + 1;
            // UI の表示を更新します
            SetCountText();
        }
    }
    // UI の表示を更新する
    void SetCountText()
    {
        // スコアの表示を更新
        scoreText.text = score.ToString() + "/12 ";
        // すべての収集アイテムを獲得した場合
        if (score >= 1)
        {
            Time.timeScale = 0f;
            // リザルトの表示を更新
            ClearText.text = "GAME CLEAR!";
        }
        //void Update()
        {
            // if (Time.timeScale == 0 && score > 1) { Time.timeScale = 1; }
        }
    }
}