using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerFire: 사용자가 마우스 왼쪽버튼을 누르면 총알 발사 구현
public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; // 총알 생성
    public GameObject firePosition;  // 총구 위치
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 사용자가 마우스 왼쪽버튼 클릭 시
        if (Input.GetButtonDown("Fire1"))
        {
            // 2. 총알 생성
            GameObject bullet = Instantiate(bulletFactory);

            // 3. 총구 위치로 이동
            bullet.transform.position = firePosition.transform.position;
        }
    }
}