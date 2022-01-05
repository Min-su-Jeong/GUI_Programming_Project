using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Background: 배경을 움직이도록 구현(Y방향으로 스크롤)
public class Background : MonoBehaviour
{
    public float speed = 0.1f; // 속력
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        //MashRenderer > Material > OffsetY
        // 태어날 때 MeshRenderer을 가져와 내장되어 있는 Material을 기억
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        mat = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        // 살아가면서 Material의 OffsetY값을 증가
        mat.mainTextureOffset += (Vector2.up * speed * Time.deltaTime);
    }
}
