using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Background: ����� �����̵��� ����(Y�������� ��ũ��)
public class Background : MonoBehaviour
{
    public float speed = 0.1f; // �ӷ�
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        //MashRenderer > Material > OffsetY
        // �¾ �� MeshRenderer�� ������ ����Ǿ� �ִ� Material�� ���
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        mat = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        // ��ư��鼭 Material�� OffsetY���� ����
        mat.mainTextureOffset += (Vector2.up * speed * Time.deltaTime);
    }
}
