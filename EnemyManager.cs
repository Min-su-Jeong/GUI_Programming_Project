using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// EnemyManager: ���� �ð����� ���� �����ؼ� �÷��̾� ��ġ�� ������ ����
public class EnemyManager : MonoBehaviour
{
    public GameObject enemyFactory; // �� ����
    float currentTime;              // ���� �ð�
    public float createTime = 1;    // ���� �ð�
    [SerializeField]
    private int maxEnemyCount;      // ���� �ִ� ��
    static int currentEnemyCnt;     // ���� ���� ��
    [SerializeField]
    private GameObject textBossWarning; // ���� ���� �ؽ�Ʈ ������Ʈ
    [SerializeField]
    private GameObject textVictory; // �¸� �ؽ�Ʈ ������Ʈ
    [SerializeField]
    private GameObject textDefeat; // �й� �ؽ�Ʈ ������Ʈ
    [SerializeField]
    private GameObject goMainBtn; // �������� ���� ��ư ������Ʈ
    [SerializeField]
    private GameObject boss; // ���� ������Ʈ
    int flag = 0;
    // Start is called before the first frame update
    void Start()
    {
        // ���� ���� �ؽ�Ʈ ��Ȱ��ȭ
        textBossWarning.SetActive(false);
        // �¸� �ؽ�Ʈ ������Ʈ ��Ȱ��ȭ
        textVictory.SetActive(false);
        // �й� �ؽ�Ʈ ������Ʈ ��Ȱ��ȭ
        textDefeat.SetActive(false);
        // �������� ���� ��ư ��Ȱ��ȭ
        goMainBtn.SetActive(false);
        // ���� ������Ʈ ��Ȱ��ȭ
        boss.SetActive(false);
        currentEnemyCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 1. ����ð� ����ȭ
        currentTime += Time.deltaTime;
        // 2. ����ð��� �����ð��� �Ǵ� ���
        if (currentTime > createTime)
        {
            if (currentEnemyCnt < maxEnemyCount)
            {
                // 3. �� ����
                GameObject enemy = Instantiate(enemyFactory);
                // 4. �÷��̾� ��ġ�� ������ ����
                enemy.transform.position = transform.position;
                // 5. ���� ���� ���� ����
                currentEnemyCnt++;
            }
            else if(currentEnemyCnt == maxEnemyCount)
            {
                if(flag == 0)
                    StartCoroutine("SpawnBoss");
                flag = 1;
            }
            // 6. ����ð��� 0���� �ʱ�ȭ
            currentTime = 0;
        }
    }
    private IEnumerator SpawnBoss()
    {
        // ���� ���� �ؽ�Ʈ Ȱ��ȭ
        textBossWarning.SetActive(true);
        // 3�� ���
        yield return new WaitForSeconds(3.0f);
        // ���� ���� �ؽ�Ʈ ��Ȱ��ȭ
        textBossWarning.SetActive(false);
        // 1�� ���
        yield return new WaitForSeconds(1.0f);
        // ���� ������Ʈ Ȱ��ȭ
        boss.SetActive(true);
    }
}
