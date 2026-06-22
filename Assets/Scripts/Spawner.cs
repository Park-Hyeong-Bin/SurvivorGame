using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 적 생성 위치들 (스포너+스폰포인트들)
    public Transform[] spawnPoint;
    // 누적 시간 변수
    private float timer;
    
    //설정 데이터들
    public SpawnData[] spawnData;
    //현재 난이도 게임 시간에 다른 변함
    public int difficulty;
    

    void Awake()
    {
        // 스포너 자신+자식 트랜스폼을 한번에 가져옴
        // GetComponentsInChildren 's' 복수형 이어야 자식 전부 가져옴 
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    
    void Update()
    {
        // 매 프레임마다 경과 시간 누적
        timer += Time.deltaTime;
        
        //난이도 상승 연산
        difficulty = (int)(GameManager.instance.gameTime / 10f);
        
        //난이도 데이터 개수를 넘지 않도록 제한(배열 범위를 초과 방지)
        if (difficulty >= spawnData.Length)
        {
            difficulty = spawnData.Length - 1;
        }
        
        // 0.2초마다 스폰 호출
        if (timer > spawnData[difficulty].spawnTime)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        // 현재 난이도 데이터가 지정한 종류의 프리팹을(spriteType) 풀에서 적을 꺼냄
        GameObject enemy = GameManager.instance.pool.Get(spawnData[difficulty].spriteType);
        
        // 스폰 포인트 중 하나에 배치 (랜덤으로, point들에서만 시작되도록 0제외)
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        
        //현재 난이도 데이터로 Enemy 능력치 초기화
        enemy.GetComponent<Enemy>().Init(spawnData[difficulty]);
    }
}