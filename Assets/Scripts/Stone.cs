using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Stone : MonoBehaviour
{
    // ���� ������Ʈ�� Transform ������Ʈ
    Transform transform;

    private void Start()
    {
        // Transform ������Ʈ �Ҵ�
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ������Ʈ�� ���� ���� ������ �̵��� ���
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
