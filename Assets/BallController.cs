using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject scoreText;

    //得点
    private int score = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のscoreTextオブジェクトを取得（追加）
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //トリガーモードで他のオブジェクトと接触した場合の処理
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag" || other.gameObject.tag == "SmallCloudTag")
        {
            // スコアを加算
            this.score += 10;

            //ScoreTextに獲得した点数を表示
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
        }

        if (other.gameObject.tag == "LargeCloudTag" || other.gameObject.tag == "LargeStarTag")
        {
            // スコアを加算
            this.score += 20;

            //ScoreTextに獲得した点数を表示
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
        }
    }
}