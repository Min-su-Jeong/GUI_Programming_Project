using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// EnemyManager: 일정 시간마다 적을 생성해서 플레이어 위치에 가져다 놓기
public class EnemyManager : MonoBehaviour
{
    public GameObject enemyFactory; // 적 생성
    float currentTime;              // 현재 시간
    public float createTime = 1;    // 생성 시간
    [SerializeField]
    private int maxEnemyCount;      // 적의 최대 수
    static int currentEnemyCnt;     // 현재 적의 수
    [SerializeField]
    private GameObject textBossWarning; // 보스 등장 텍스트 오브젝트
    [SerializeField]
    private GameObject textVictory; // 승리 텍스트 오브젝트
    [SerializeField]
    private GameObject textDefeat; // 패배 텍스트 오브젝트
    [SerializeField]
    private GameObject goMainBtn; // 메인으로 가기 버튼 오브젝트
    [SerializeField]
    private GameObject boss; // 보스 오브젝트
    int flag = 0;
    // Start is called before the first frame update
    void Start()
    {
        // 보스 등장 텍스트 비활성화
        textBossWarning.SetActive(false);
        // 승리 텍스트 오브젝트 비활성화
        textVictory.SetActive(false);
        // 패배 텍스트 오브젝트 비활성화
        textDefeat.SetActive(false);
        // 메인으로 가기 버튼 비활성화
        goMainBtn.SetActive(false);
        // 보스 오브젝트 비활성화
        boss.SetActive(false);
        currentEnemyCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 현재시간 동기화
        currentTime += Time.deltaTime;
        // 2. 현재시간이 생성시간이 되는 경우
        if (currentTime > createTime)
        {
            if (currentEnemyCnt < maxEnemyCount)
            {
                // 3. 적 생성
                GameObject enemy = Instantiate(enemyFactory);
                // 4. 플레이어 위치에 가져다 놓기
                enemy.transform.position = transform.position;
                // 5. 적이 생성 숫자 증가
                currentEnemyCnt++;
            }
            else if(currentEnemyCnt == maxEnemyCount)
            {
                if(flag == 0)
                    StartCoroutine("SpawnBoss");
                flag = 1;
            }
            // 6. 현재시간을 0으로 초기화
            currentTime = 0;
        }
    }
    private IEnumerator SpawnBoss()
    {
        // 보스 등장 텍스트 활성화
        textBossWarning.SetActive(true);
        // 3초 대기
        yield return new WaitForSeconds(3.0f);
        // 보스 등장 텍스트 비활성화
        textBossWarning.SetActive(false);
        // 1초 대기
        yield return new WaitForSeconds(1.0f);
        // 보스 오브젝트 활성화
        boss.SetActive(true);
    }
}
