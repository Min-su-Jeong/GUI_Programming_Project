using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DestroyZone: �����浹 ����
public class DestroyZone : MonoBehaviour
{
    // �����浹 �Լ�
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
