using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    // ���� �ð�
    float surviveTime;
    // ���� ���� ����
    bool isGameover;

    // �÷��� �ð� �ؽ�Ʈ
    public Text playTimeText;
    // ���ӿ��� �ؽ�Ʈ
    public GameObject gameOverText;
    // ��� �ؽ�Ʈ
    public Text recordText;

    

    // Start is called before the first frame update
    void Start()
    {
        // ���� �ð� �ʱ�ȭ
        surviveTime = 0.0f;
        // ���� ���� ���� �ʱ�ȭ
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���� ���� ���� ����
        if (!isGameover)
        {
            // ���� �ð� ����
            surviveTime += Time.deltaTime;
            // ���� �ð� ȭ�� ǥ��
            playTimeText.text = "Time : " + (int)surviveTime;
        } 
        // ���� ���� �� ���
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // ���� �� �ε�
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    // ���� ���� ��
    public void EndGame()
    {
        // ���ӿ��� ���ӿ��� ���� ��ȯ
        isGameover = true;

        // BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (surviveTime > bestTime)
        {
            // �ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviveTime;
            // ����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // �ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        recordText.text = "Best Time : " + (int)bestTime + " | " + "Your Time : " + (int)surviveTime;

        // ���ӿ��� �ؽ�Ʈ ���
        gameOverText.SetActive(true);
        recordText.gameObject.SetActive(true);
        playTimeText.gameObject.SetActive(false);

        //playTimeText.rectTransform.anchoredPosition = new Vector2(0, -40);
        //playTimeText.fontSize = 20;
        //playTimeText.alignment = TextAnchor.MiddleCenter;
        //playTimeText.text = "Your Time : " + (int)surviveTime;

        StoneGenerator stoneGenerator = FindObjectOfType<StoneGenerator>();
        if (stoneGenerator != null)
        {
            stoneGenerator.EndGame();
        }
    }
}
