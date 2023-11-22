using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Stone : MonoBehaviour
{
    // 게임 오브젝트의 Transform 컴포넌트
    Transform transform;

    private void Start()
    {
        // Transform 컴포넌트 할당
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 오브젝트가 일정 범위 밖으로 이동할 경우
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
