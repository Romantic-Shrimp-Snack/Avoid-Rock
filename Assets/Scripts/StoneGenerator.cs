using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGenerator : MonoBehaviour
{
    // 생성할 돌 오브젝트 프리팹
    public GameObject stonePrefab;
    // 최소 생성 주기
    public float spawnRateMin;
    // 최대 생성 주기
    public float spawnRateMax;
    // 다음 스테이지로 넘어가는데 버텨야할 시간
    public float nextStageTime;

    // 오브젝트 생성 개수
    private int spawnCount;
    // 오브젝트 최대 생성 개수
    public int spawnCountMax;

    // 생성 후 경과 시간
    private float spawnAfterTime;
    // 생성 주기
    private float spawnRate;

    // 현재 시간
    private float currentTime;

    private bool isGameOver;
    

    // Start is called before the first frame update
    void Start()
    {
        // 생성 후 경과 시간 초기화
        spawnAfterTime = 0.0f;
        // 현재 시간 초기화
        currentTime = 0.0f;
        // 오브젝트 생성 간격을 spawnRateMin과 spawnRateMax 사이에서 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // 오브젝트 생성 개수를 1과 spawnCount 사이에서 랜덤 지정
        spawnCount = Random.Range(1, spawnCountMax);
        spawnCount += 1;

        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;

        // 생성 후 경과 시간 누적
        spawnAfterTime += Time.deltaTime;
        // 현재 시간 누적
        currentTime += Time.deltaTime;

        // 생성 후 경과 시간이 오브젝트 생성 주기보다 넘어갈 경우
        if (spawnAfterTime >= spawnRate)
        {
            // 생성 후 경과 시간 초기화
            spawnAfterTime = 0.0f;

            // 랜덤 개수 생성
            for(int i = 1; i <= spawnCount; i++)
            {
                // rock 게임 오브젝트 생성
                GameObject rock = Instantiate(stonePrefab, new Vector3(Random.Range(-11, 11), 5, 0), transform.rotation);
            }
        
            // 생성 주기를 spawnRateMin과 spawnRateMax 사이에서 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            // 오브젝트 생성 개수를 1과 spawnCount 사이에서 랜덤 지정
            spawnCount = Random.Range(1, spawnCountMax);
            spawnCount += 1;
        }

        // 현재 시간이 다음 스테이지로 넘어갈 시간이 되는 경우
        if(currentTime >= nextStageTime && spawnRateMax > spawnRateMin)
        {
            // 오브젝트 최대 생성 주기를 0.5초 단축
            spawnRateMax -= 0.2f;
            // 현재 시간 초기화
            currentTime = 0.0f;
        }

        Debug.Log("현재 시간 : " + currentTime);
        Debug.Log("현재 오브젝트 최대 생성 주기 : " + spawnRateMax);
        Debug.Log("생성 개수 : " + spawnCount);
    }

    public void EndGame()
    {
        isGameOver = true;
    }

}
