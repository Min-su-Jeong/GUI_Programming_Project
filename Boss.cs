using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public enum BossState { MoveToAppearPoint = 0,}
public class Boss : MonoBehaviour
{
    public GameObject explosionFactory;
    public AudioSource audioSource; // 승리 사운드
    [SerializeField]
    private GameObject textVictory; // 승리 텍스트 오브젝트
    [SerializeField]
    private GameObject goMainBtn; // 메인으로 가기 버튼 오브젝트
    private int BossHP = 50;
    private PlayerState state;

    private void OnCollisionEnter(Collision other)
    {
        // 1. 시각효과 생성
        GameObject explosion = Instantiate(explosionFactory);
        // 2. 플레이어 위치에 가져다 놓기
        explosion.transform.position = transform.position;
        if(other.gameObject.name == "Player")
        {
            int playerHP = state.getCurrentHP();
            state.setCurrentHP(playerHP);
        }
        BossHP--;
        // 보스 체력이 0이면 보스 죽기
        if (BossHP == 0)
        {
            Destroy(gameObject);
            audioSource.Play();
            // 승리 텍스트 활성화
            textVictory.SetActive(true);
            // 메인으로 가기 버튼 활성화
            goMainBtn.SetActive(true);
        }    
    }
}
