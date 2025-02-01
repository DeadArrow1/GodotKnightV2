using System.Collections;
using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private enum State { 
    Roaming
    }


    private GameObject player;
    public float speed;
    public float LoS;


    private float distance;


    private State state;
    private SkeletonPathfinding SkeletonPathfinding;

    private void Awake()
    {
        SkeletonPathfinding = GetComponent<SkeletonPathfinding>();
        state = State.Roaming;
        player=GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        //StartCoroutine(RoamingRoutine());
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        
        /*Vector2 direction = player.transform.position - transform.position;

        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;*/
  
        /*transform.rotation = Quaternion.Euler(Vector3.forward * angle);*/

        if(distance < LoS)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        }
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
