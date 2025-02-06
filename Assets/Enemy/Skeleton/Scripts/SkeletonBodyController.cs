using UnityEngine;

public class SkeletonBodyController : MonoBehaviour
{

    [SerializeField]
    public AudioSource DeathSoundSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DeathSoundSource.Play();
    }

    
}
