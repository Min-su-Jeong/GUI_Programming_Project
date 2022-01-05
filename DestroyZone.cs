using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DestroyZone: 감지충돌 구현
public class DestroyZone : MonoBehaviour
{
    // 감지충돌 함수
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
