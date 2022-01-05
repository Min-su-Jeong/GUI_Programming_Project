using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    private Vector3 dir;
    private float delta = 6.0f;
    public float speed = 5; // ¼Ó·Â
                            
    // Update is called once per frame
    void Start()
    {
        dir = transform.position;
    }
    void Update()
    {
        Vector3 v = dir;
        v.x += delta * Mathf.Sin(Time.time * speed / 2);
        v.y += delta * Mathf.Cos(Time.time * speed / 4);
        
        transform.position = v;
        //transform.position += (dir * speed * Time.deltaTime);
    }

    private IEnumerator MovePattern()
    {
        while (true)
        {
            dir = Vector3.right * speed;
            dir.Normalize();
            yield return new WaitForSeconds(3.0f);
            dir = Vector3.left * speed;
            dir.Normalize();
            yield return new WaitForSeconds(3.0f);
        }
    }
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }
}
