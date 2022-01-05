using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreRenew : MonoBehaviour
{
    private int gamescore;
    private Text[] scorelist = new Text[5];
    private string[] tag = { "rank1", "rank2", "rank3", "rank4", "rank5" };
    public static int[] _score = { 0, 0, 0, 0, 0, 0 };
    //[SerializeField]
    //private GameObject ScoreRenewBtn; // 점수 갱신 버튼 활성화
    // Start is called before the first frame update

    public void Renew()
    {
        //// 점수 갱신 버튼 활성화
        //ScoreRenewBtn.SetActive(true);
        gamescore = Bullet.score;
        for (int i=0;i<5;i++)
        {
            scorelist[i] = GameObject.FindWithTag(tag[i]).GetComponent<Text>();
        }
        // 텍스트를 배열에 삽입
        for (int i = 0; i < 6; i++)
        {
            if (i < 5)
            {
                if (_score[i] < (int.Parse(scorelist[i].text)))
                {
                    _score[i] = int.Parse(scorelist[i].text);
                }
            }
            else
            {
                if (_score[i] < gamescore)
                {
                    _score[i] = gamescore;
                }
            }
        }
        // 배열 정렬
        Array.Sort(_score);
        Array.Reverse(_score);

        // 점수 갱신
        for (int i = 0; i < 5; i++)
        {
            scorelist[i].text = _score[i].ToString();
        }
        //// 점수 갱신 버튼 비활성화
        //ScoreRenewBtn.SetActive(false);
        Bullet.score = 0;
    }
}
