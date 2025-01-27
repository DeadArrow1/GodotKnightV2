using System.Collections;
using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private enum State { 
    Roaming
    }

    private State state;
    private SkeletonPathfinding SkeletonPathfinding;

    private void Awake()
    {
        SkeletonPathfinding = GetComponent<SkeletonPathfinding>();
        state = State.Roaming;
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            SkeletonPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);
        }
    
    }

    private Vector2 GetRoamingPosition() 
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        //return new Vector2(0, 0).normalized;
    }
}
