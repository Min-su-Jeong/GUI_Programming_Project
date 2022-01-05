using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player: 플레이어의 키 입력에 따라 플레이어를 이동 구현 
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    public float speed = 5; // 속력

    // Update is called once per frame
    void Update()
    {
        // 1. 사용자의 키 입력에 따라(W, A, S, D)
        float h = Input.GetAxis("Horizontal"); // 수평
        float v = Input.GetAxis("Vertical"); // 수직
        
        // 2. 방향 만들기
        Vector3 dir = Vector3.right * h + Vector3.up * v; // right: [0, 0, 0] [1, 0, 0], [-1, 0, 0] / up: [0, 0, 0] [0, 1, 0], [0, -1, 0]
        dir.Normalize(); // 대각선 이동 시 움직임의 크기가 더 큼 -> 벡터 정규화 필요

        // 3. 해당 방향으로 플레이어를 이동
        // 이동공식 P = P0 + Vt(Vector: 크기와 방향을 가짐, DeltaTime: 화면을 한번 주사하는 데 걸리는 시간)
        // 다른 시스템 간의 동기화를 위해 반드시 이동, 회전, 크기 변환에 Time.deltaTime을 곱해준다.
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
