using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy: 적 생성
public class Enemy : MonoBehaviour
{
    Vector3 dir;            // 방향
    public float speed = 5; // 속력


    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 50% 확률로 플레이어 방향, 나머지 확률로 아래방향으로 정하기
        int result = UnityEngine.Random.Range(0, 10);
        if (result < 5)
        {
            // 플레이어 방향
            GameObject target = GameObject.Find("Player");
            // dir: 타켓의 위치와 플레이어의 위치의 떨어진 거리
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            // 아래방향
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 살아가면서 해당 방향으로 이동
        transform.position += (dir * speed * Time.deltaTime);
    }

    public GameObject explosionFactory;


    private void OnCollisionEnter(Collision other)
    {
        // 1. 시각효과 생성
        GameObject explosion = Instantiate(explosionFactory);
        // 2. 플레이어 위치에 가져다 놓기
        explosion.transform.position = transform.position;
        // 적 죽기
        Destroy(gameObject);
    }
}

