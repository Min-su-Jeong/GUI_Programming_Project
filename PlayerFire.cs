using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerFire: ����ڰ� ���콺 ���ʹ�ư�� ������ �Ѿ� �߻� ����
public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; // �Ѿ� ����
    public GameObject firePosition;  // �ѱ� ��ġ
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. ����ڰ� ���콺 ���ʹ�ư Ŭ�� ��
        if (Input.GetButtonDown("Fire1"))
        {
            // 2. �Ѿ� ����
            GameObject bullet = Instantiate(bulletFactory);

            // 3. �ѱ� ��ġ�� �̵�
            bullet.transform.position = firePosition.transform.position;
        }
    }
}