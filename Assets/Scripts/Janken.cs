using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Janken : MonoBehaviour
{
    [SerializeField]
    Text myHandText;
    [SerializeField]
    Text enemyHandText;
    [SerializeField]
    Text judgeText;

    bool finished;

    // Use this for initialization
    void Start()
    {
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowMyHand(int myHandNo)
    {
        if (finished) return;

        myHandText.text = HandNameOf(myHandNo);//自分の手を表示

        //相手にも手を出させる
        int enemyHandNo = ShowEnemyHand();

        //勝利判定
        JudgeWinOrNot(myHandNo, enemyHandNo);
    }

    int ShowEnemyHand()
    {
        int handNo = Random.Range(0, 3);// 0~2の乱数値を取得(3は除かれる)
        enemyHandText.text = HandNameOf(handNo);//相手の手を表示
        return handNo;
    }

    string HandNameOf(int handNo)//手の番号からテキストを取得
    {
        string handString = "";

        switch (handNo)
        {
            case 0://グー
                handString = "グー";
                break;
            case 1://チョキ
                handString = "チョキ";
                break;
            case 2://パー
                handString = "パー";
                break;
        }

        return handString;
    }

    void JudgeWinOrNot(int myHandNo, int enemyHandNo)
    {
        int bid = myHandNo - enemyHandNo;

        if (bid == 0)
        {
            judgeText.text = "あいこで...";
            return;
        }

        if (bid == -1 || bid == 2)
        {
            judgeText.text = "勝利！";
        }
        else
        {
            judgeText.text = "敗北...";
        }
        finished = true;
    }

    public void ResetGame()
    {
        finished = false;
        myHandText.text = "自分の手";
        enemyHandText.text = "相手の手";
        judgeText.text = "じゃんけん...";
    }
}