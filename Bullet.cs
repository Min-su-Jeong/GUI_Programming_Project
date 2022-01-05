using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Bullet: ���� �̵� ������ ����
public class Bullet : MonoBehaviour
{
    public float speed = 10;  // �ӷ�
    private Text scoreText;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter()
    {
        score += 100;
        scoreText.text = score.ToString();
        Destroy(this.gameObject);
    }
}
