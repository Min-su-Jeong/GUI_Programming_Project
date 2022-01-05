using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private GameObject textDefeat; // �й� �ؽ�Ʈ ������Ʈ
    [SerializeField]
    private GameObject goMainBtn; // �������� ���� ��ư ������Ʈ
    public int MaxHP = 5;               // max ü��
    public GameObject enemy;            // �� ������Ʈ
    int currentHP;               // ���� ü��
    public Text hpText;                 // ü�� text
    public GameObject explosionFactory; // ���� ȿ��
    public AudioSource audioSource; // �й� ����� ����

    // Start is called before the first frame update
    void Start()
    {
        currentHP = MaxHP;
    }
    void Update()
    {
    }
    private void OnCollisionEnter(Collision other)
    {
        // 1. �ð�ȿ�� ����
        GameObject explosion = Instantiate(explosionFactory);
        // 2. �÷��̾� ��ġ�� ������ ����
        explosion.transform.position = transform.position;
        // ü�� ���̱�
        --currentHP;
        hpText.text = currentHP.ToString();
        // �ε�ģ �� ���ֱ�
        if (other.gameObject.name == "Enemy(Clone)")
            Destroy(other.gameObject);
        //scoreText.text = score.ToString();
        // ������ 0�� ��� �÷��̾� ���
        if (currentHP < 1)
        { 
            Destroy(gameObject);
            // �й� �ؽ�Ʈ Ȱ��ȭ
            textDefeat.SetActive(true);
            // �������� ���� ��ư Ȱ��ȭ
            goMainBtn.SetActive(true);
            // �й� ����� ���
            audioSource.Play();
        }
    }
    public int getCurrentHP()
    {
        return currentHP;
    }
    public void setCurrentHP(int currentHP)
    {
        this.currentHP = currentHP;
    }
}