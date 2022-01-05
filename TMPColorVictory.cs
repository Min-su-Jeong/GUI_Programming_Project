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
            // ������ �Ͼ�� -> ������
            yield return StartCoroutine(ColorLerp(Color.white, Color.green));
            // ������ ������ -> �Ͼ��
            yield return StartCoroutine(ColorLerp(Color.green, Color.white));
        }
    }
    private IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            // lerpTime �ð����� while() �ݺ��� ����
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            // Text - TextMeshPro�� ��Ʈ ������ startColor���� endColor�� ����
            textVictory.color = Color.Lerp(startColor, endColor, percent);

            yield return null;
        }
    }
}
