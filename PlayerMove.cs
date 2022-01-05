using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player: �÷��̾��� Ű �Է¿� ���� �÷��̾ �̵� ���� 
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    public float speed = 5; // �ӷ�

    // Update is called once per frame
    void Update()
    {
        // 1. ������� Ű �Է¿� ����(W, A, S, D)
        float h = Input.GetAxis("Horizontal"); // ����
        float v = Input.GetAxis("Vertical"); // ����
        
        // 2. ���� �����
        Vector3 dir = Vector3.right * h + Vector3.up * v; // right: [0, 0, 0] [1, 0, 0], [-1, 0, 0] / up: [0, 0, 0] [0, 1, 0], [0, -1, 0]
        dir.Normalize(); // �밢�� �̵� �� �������� ũ�Ⱑ �� ŭ -> ���� ����ȭ �ʿ�

        // 3. �ش� �������� �÷��̾ �̵�
        // �̵����� P = P0 + Vt(Vector: ũ��� ������ ����, DeltaTime: ȭ���� �ѹ� �ֻ��ϴ� �� �ɸ��� �ð�)
        // �ٸ� �ý��� ���� ����ȭ�� ���� �ݵ�� �̵�, ȸ��, ũ�� ��ȯ�� Time.deltaTime�� �����ش�.
        transform.position += (dir * speed * Time.deltaTime);  
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
