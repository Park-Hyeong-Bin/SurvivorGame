using System;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange; //스캔 범위 (원의 반지름)
    public LayerMask targetLayer;//스캔 대상 레이어(Enemy)
    public RaycastHit2D[] targets; // 범위 내 검색된 대상들
    public Transform nearestTraget; // 가장 가까운 타겟

    private void FixedUpdate()
    {
        //CircleCastAll - 원을 쏘면서 경로에 닿는 콜라이더를 전부 배열로 반환
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0,targetLayer);

        nearestTraget = GetNearestTraget();
    }

    //검색된 대상들(targets) 중 가장 가까운  Transform 을 반환
    Transform GetNearestTraget()
    {
        Transform result = null; // 최근접 대상(없을땐 null)
        float diff = 100;//최소 거리

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.point;
            float curDiff =  Vector3.Distance(myPos, targetPos);//스캐너와 탐지된 객체와의 거리 측정

            if (curDiff < diff) // 측정된 거리가 현재 거리보다 더 가까운 경우
            {
                diff = curDiff;//최소 거리 계산
                result = target.transform;
            }
        }
        
        return result;
    }
}
