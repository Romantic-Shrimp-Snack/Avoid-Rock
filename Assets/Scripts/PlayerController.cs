using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    // �÷��̾��� Ʈ������ ������Ʈ
    Transform transform;
    // �÷��̾��� Sprite Renderer
    SpriteRenderer spriteRenderer;

    // �÷��̾��� �̵��ӵ�
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    // �÷��̾� �̵� �޼���
    void Move()
    {
        // ������ ���� �Է°� ����
        float xInput = Input.GetAxisRaw("Horizontal");

        // ������Ʈ �̵�
        transform.Translate(Vector3.right * xInput * moveSpeed * Time.deltaTime);      

        // ����Ű �Է¿� ���� �̹��� ����
        if(xInput == -1)
        {
            spriteRenderer.flipX = true;
        }
        else if(xInput == 1)
        {
            spriteRenderer.flipX = false;
        }
    }

    // ������Ʈ �� �浹���� �޼���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ε��� ������Ʈ�� Poop ������Ʈ�� ���
        if (collision.gameObject.tag == "Poop")
        {
            // ���ӿ��� ó��
            gameObject.SetActive(false);

            // GameManager ������Ʈ ã��
            GameManager gameManager = FindObjectOfType<GameManager>();

            // EndGame �޼��� ����
            gameManager.EndGame();
        }
    }
}
