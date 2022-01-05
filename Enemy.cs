using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy: �� ����
public class Enemy : MonoBehaviour
{
    Vector3 dir;            // ����
    public float speed = 5; // �ӷ�


    // Start is called before the first frame update
    void Start()
    {
        // �¾ �� 50% Ȯ���� �÷��̾� ����, ������ Ȯ���� �Ʒ��������� ���ϱ�
        int result = UnityEngine.Random.Range(0, 10);
        if (result < 5)
        {
            // �÷��̾� ����
            GameObject target = GameObject.Find("Player");
            // dir: Ÿ���� ��ġ�� �÷��̾��� ��ġ�� ������ �Ÿ�
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            // �Ʒ�����
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ��ư��鼭 �ش� �������� �̵�
        transform.position += (dir * speed * Time.deltaTime);
    }

    public GameObject explosionFactory;


    private void OnCollisionEnter(Collision other)
    {
        // 1. �ð�ȿ�� ����
        GameObject explosion = Instantiate(explosionFactory);
        // 2. �÷��̾� ��ġ�� ������ ����
        explosion.transform.position = transform.position;
        // �� �ױ�
        Destroy(gameObject);
    }
}

