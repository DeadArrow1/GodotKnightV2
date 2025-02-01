using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private Animator myAnimator;


    private void Awake()
    {
        myAnimator = transform.parent.GetComponent<Animator>();       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Hitbox") && other.transform.parent.gameObject.tag.Equals("Player"))
        {
            myAnimator.SetTrigger("Attack");
        }
    }

   
}
