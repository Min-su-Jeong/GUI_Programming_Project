using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private GameObject textDefeat; // 패배 텍스트 오브젝트
    [SerializeField]
    private GameObject goMainBtn; // 메인으로 가기 버튼 오브젝트
    public int MaxHP = 5;               // max 체력
    public GameObject enemy;            // 적 오브젝트
    int currentHP;               // 현재 체력
    public Text hpText;                 // 체력 text
    public GameObject explosionFactory; // 폭발 효과
    public AudioSource audioSource; // 패배 오디오 사운드

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
        // 1. 시각효과 생성
        GameObject explosion = Instantiate(explosionFactory);
        // 2. 플레이어 위치에 가져다 놓기
        explosion.transform.position = transform.position;
        // 체력 줄이기
        --currentHP;
        hpText.text = currentHP.ToString();
        // 부딪친 적 없애기
        if (other.gameObject.name == "Enemy(Clone)")
            Destroy(other.gameObject);
        //scoreText.text = score.ToString();
        // 생명이 0인 경우 플레이어 사망
        if (currentHP < 1)
        { 
            Destroy(gameObject);
            // 패배 텍스트 활성화
            textDefeat.SetActive(true);
            // 메인으로 가기 버튼 활성화
            goMainBtn.SetActive(true);
            // 패배 오디오 재생
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