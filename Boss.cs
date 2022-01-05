using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public enum BossState { MoveToAppearPoint = 0,}
public class Boss : MonoBehaviour
{
    public GameObject explosionFactory;
    public AudioSource audioSource; // �¸� ����
    [SerializeField]
    private GameObject textVictory; // �¸� �ؽ�Ʈ ������Ʈ
    [SerializeField]
    private GameObject goMainBtn; // �������� ���� ��ư ������Ʈ
    private int BossHP = 50;
    private PlayerState state;

    private void OnCollisionEnter(Collision other)
    {
        // 1. �ð�ȿ�� ����
        GameObject explosion = Instantiate(explosionFactory);
        // 2. �÷��̾� ��ġ�� ������ ����
        explosion.transform.position = transform.position;
        if(other.gameObject.name == "Player")
        {
            int playerHP = state.getCurrentHP();
            state.setCurrentHP(playerHP);
        }
        BossHP--;
        // ���� ü���� 0�̸� ���� �ױ�
        if (BossHP == 0)
        {
            Destroy(gameObject);
            audioSource.Play();
            // �¸� �ؽ�Ʈ Ȱ��ȭ
            textVictory.SetActive(true);
            // �������� ���� ��ư Ȱ��ȭ
            goMainBtn.SetActive(true);
        }    
    }
}
