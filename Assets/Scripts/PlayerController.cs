using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    // 플레이어의 트랜스폼 컴포넌트
    Transform transform;
    // 플레이어의 Sprite Renderer
    SpriteRenderer spriteRenderer;

    // 플레이어의 이동속도
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

    // 플레이어 이동 메서드
    void Move()
    {
        // 유저의 수평 입력값 저장
        float xInput = Input.GetAxisRaw("Horizontal");

        // 오브젝트 이동
        transform.Translate(Vector3.right * xInput * moveSpeed * Time.deltaTime);      

        // 방향키 입력에 따라 이미지 반전
        if(xInput == -1)
        {
            spriteRenderer.flipX = true;
        }
        else if(xInput == 1)
        {
            spriteRenderer.flipX = false;
        }
    }

    // 오브젝트 간 충돌감지 메서드
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딪힌 오브젝트가 Poop 오브젝트일 경우
        if (collision.gameObject.tag == "Poop")
        {
            // 게임오버 처리
            gameObject.SetActive(false);

            // GameManager 오브젝트 찾기
            GameManager gameManager = FindObjectOfType<GameManager>();

            // EndGame 메서드 실행
            gameManager.EndGame();
        }
    }
}
