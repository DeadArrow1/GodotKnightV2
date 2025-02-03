using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    private Animator myAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void playAnimation()
    {
        myAnimator.SetTrigger("LevelUP");
    }
     
}
