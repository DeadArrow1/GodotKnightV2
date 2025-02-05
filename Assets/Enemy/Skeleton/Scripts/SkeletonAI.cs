using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonAI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private enum State { 
    Roaming
    }


 
    private Animator myAnimator;
    private GameObject player;
    public float speed;
    public float LoS;

    [SerializeField] private Transform weaponCollider;
    [SerializeField] private Transform playerDetector;

    [SerializeField] private Transform DamageDoneRect;

    private float distance;


    private State state;
    private SkeletonPathfinding SkeletonPathfinding;

    private void Awake()
    {

        myAnimator = GetComponent<Animator>();
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

        if(distance < LoS && myAnimator.GetBool("IsAttacking") != true)
            
        {
            Vector2 movement = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.position = movement;
            myAnimator.SetFloat("moveX", movement.x);
            myAnimator.SetFloat("moveY", movement.y);

             Vector2 direction = player.transform.position - transform.position;
            if (direction.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
                
                
                DamageDoneRect.rotation = Quaternion.Euler(0, 0, 0);
            

                weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0);
                playerDetector.transform.rotation = Quaternion.Euler(0, -180, 0);

            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                
                
                DamageDoneRect.rotation = Quaternion.Euler(0, 0, 0);
                
                
                
                weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
                playerDetector.transform.rotation = Quaternion.Euler(0, 0, 0);

            }


        }
        else 
        {
            myAnimator.SetFloat("moveX", 0);
            myAnimator.SetFloat("moveY", 0);
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

    //CALLED AS EVENT IN ANIMATIONS
    private void SetIsAttackingBoolTrue()
    {
        myAnimator.SetBool("IsAttacking", true);
    }
    private void SetIsAttackingBoolFalse()
    {
        myAnimator.SetBool("IsAttacking", false);

    }

    private void AttackHitboxActive()
    {
        weaponCollider.gameObject.SetActive(true);
    }

    private void SetIsHurtFalse()
    {
        myAnimator.SetBool("IsHurt", false);
    }

    private void AttackHitboxDeactive()
    {
        weaponCollider.gameObject.SetActive(false);
    }
    //CALLED AS EVENT IN ANIMATIONS

}
