using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSort : MonoBehaviour
{
    List<int> list = new List<int>();
    int gameScore; // ���� ���ھ�
    GameObject obj;
    private Text rank1_score;

    public void SetRanking() // ���ھ ���� ������� ������������ �����ϴ� �Լ�
    {
        gameScore = Bullet.score;
        obj = GameObject.FindWithTag("table");
        Debug.Log(obj);
        rank1_score = scorelist.rank1.getcomponent<text>();
        debug.log(rank1_score.text);
        rank1_score = scorelist.rank1;
        debug.log(rank1_score);
        for (int i = 0; i < 5; i++)
        {
            debug.log(scorelist.scorelist[i]);
        }

        list.sort(delegate (int a, int b)
        {
            if (a < b) return 1;
            else if (a > b) return -1;
            return 0; //������ ���� ���
        });
        for (int i = 0; i < 5; i++)
        {
            scorelist[i].text = (list.indexof(i)).tostring();
        }
    }
}
