using System.Collections;
using UnityEngine;
using TMPro;

public class TMPColorVictory : MonoBehaviour
{
    [SerializeField]
    private float lerpTime = 0.1f;
    private TextMeshProUGUI textVictory;

    private void Awake()
    {
        textVictory = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        StartCoroutine("ColorLerpLoop");
    }
    private IEnumerator ColorLerpLoop()
    {
        while(true)
        {
            // 색상을 하얀색 -> 빨간색
            yield return StartCoroutine(ColorLerp(Color.white, Color.green));
            // 색상을 빨간색 -> 하얀색
            yield return StartCoroutine(ColorLerp(Color.green, Color.white));
        }
    }
    private IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            // lerpTime 시간동안 while() 반복문 실행
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            // Text - TextMeshPro의 폰트 색상을 startColor에서 endColor로 변경
            textVictory.color = Color.Lerp(startColor, endColor, percent);

            yield return null;
        }
    }
}
