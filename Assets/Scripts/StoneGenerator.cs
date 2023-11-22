using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGenerator : MonoBehaviour
{
    // ������ �� ������Ʈ ������
    public GameObject stonePrefab;
    // �ּ� ���� �ֱ�
    public float spawnRateMin;
    // �ִ� ���� �ֱ�
    public float spawnRateMax;
    // ���� ���������� �Ѿ�µ� ���߾��� �ð�
    public float nextStageTime;

    // ������Ʈ ���� ����
    private int spawnCount;
    // ������Ʈ �ִ� ���� ����
    public int spawnCountMax;

    // ���� �� ��� �ð�
    private float spawnAfterTime;
    // ���� �ֱ�
    private float spawnRate;

    // ���� �ð�
    private float currentTime;

    private bool isGameOver;
    

    // Start is called before the first frame update
    void Start()
    {
        // ���� �� ��� �ð� �ʱ�ȭ
        spawnAfterTime = 0.0f;
        // ���� �ð� �ʱ�ȭ
        currentTime = 0.0f;
        // ������Ʈ ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // ������Ʈ ���� ������ 1�� spawnCount ���̿��� ���� ����
        spawnCount = Random.Range(1, spawnCountMax);
        spawnCount += 1;

        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;

        // ���� �� ��� �ð� ����
        spawnAfterTime += Time.deltaTime;
        // ���� �ð� ����
        currentTime += Time.deltaTime;

        // ���� �� ��� �ð��� ������Ʈ ���� �ֱ⺸�� �Ѿ ���
        if (spawnAfterTime >= spawnRate)
        {
            // ���� �� ��� �ð� �ʱ�ȭ
            spawnAfterTime = 0.0f;

            // ���� ���� ����
            for(int i = 1; i <= spawnCount; i++)
            {
                // rock ���� ������Ʈ ����
                GameObject rock = Instantiate(stonePrefab, new Vector3(Random.Range(-11, 11), 5, 0), transform.rotation);
            }
        
            // ���� �ֱ⸦ spawnRateMin�� spawnRateMax ���̿��� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            // ������Ʈ ���� ������ 1�� spawnCount ���̿��� ���� ����
            spawnCount = Random.Range(1, spawnCountMax);
            spawnCount += 1;
        }

        // ���� �ð��� ���� ���������� �Ѿ �ð��� �Ǵ� ���
        if(currentTime >= nextStageTime && spawnRateMax > spawnRateMin)
        {
            // ������Ʈ �ִ� ���� �ֱ⸦ 0.5�� ����
            spawnRateMax -= 0.2f;
            // ���� �ð� �ʱ�ȭ
            currentTime = 0.0f;
        }

        Debug.Log("���� �ð� : " + currentTime);
        Debug.Log("���� ������Ʈ �ִ� ���� �ֱ� : " + spawnRateMax);
        Debug.Log("���� ���� : " + spawnCount);
    }

    public void EndGame()
    {
        isGameOver = true;
    }

}
