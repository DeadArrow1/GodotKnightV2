using UnityEngine;

public class HealingPotionDrop : MonoBehaviour
{
    public GameData gameData;

    public AudioSource audioSource;

    public AudioClip dropSound;
    
    public AudioClip pickupSound;

    private Animator myAnimator;

    private bool pickedUp=false;



    protected void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && pickedUp==false)
        {
            pickedUp = true;
            gameData.HealingPotionsCount = gameData.HealingPotionsCount + 1 + 1 * gameData.SkillTreeListSkillObtainedStatus[45];
            myAnimator.SetTrigger("PickedUp");
        }
    }

    public void PlayDropSound()
    {
        audioSource.clip = dropSound;
        audioSource.Play();
    }

    public void PlayPickupSound()
    {
        audioSource.clip = pickupSound;
        audioSource.Play();
    }

    public void DeleteSelf()
    {
        Destroy(gameObject);
    }

}
