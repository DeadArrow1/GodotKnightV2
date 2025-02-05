using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : Singleton<PlayerController>
{
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Transform weaponCollider;
    [SerializeField] private GameData gameData;

    [SerializeField] private SpriteAnimation Sprites;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;

    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    
    private bool facingLeft = false;

    public GameManager gameManager;
    [SerializeField]
    public AudioSource AttackSoundSource;


    [SerializeField]
    public AudioSource RunSoundSource;

    [SerializeField]
    public AudioSource LevelUpSoundSource;

    [SerializeField]
    public AudioClip Attack1;

    [SerializeField]
    public AudioClip Attack2;

    [SerializeField]
    public AudioClip Attack3;

    [SerializeField]
    public AudioClip Run;

    private bool IsDrinking;



    protected override void Awake() 
    {
        base.Awake();

        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();

        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();


   
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
        DetectLevelUp();

        if (gameData.CurrentHealth <= 0 && !gameData.isDead)
        {
            gameData.isDead = true;
            gameManager.gameOver();
        }

        if (Input.GetKeyDown(KeyCode.R) && IsDrinking == false && gameData.HealingPotionsCount>0)
        {
            IsDrinking = true;
            myAnimator.SetTrigger("Drink");
        }

    }
    public void SetIsDrinkingFalse()
    {
        IsDrinking = false;

    }

    public void DetectLevelUp()
    {
        if (gameData.CurrentXP >= gameData.NeededXP)
        {
            gameData.CurrentXP = gameData.CurrentXP - gameData.NeededXP;
            gameData.NeededXP = gameData.NeededXP * 2;
            gameData.SkillpointCount = gameData.SkillpointCount + 1;
            gameData.PlayerLevel += 1;
            gameData.CurrentHealth = gameData.MaxHealth;

            LevelUpSoundSource.Play();
            Sprites.playAnimation();
        }
    }

    private void FixedUpdate()
    {
        
            AdjustPlayerFacingDirection();
            Move();
        
    }

    private void Attack()
    {
        if (myAnimator.GetBool("IsAttacking"))
        {
            myAnimator.SetBool("AttackContinues", true);
        }
        else
        {
            myAnimator.SetTrigger("Attack");
        }
    }



    public void AttackHitboxStartAnimEvent()
    {
        weaponCollider.gameObject.SetActive(true);
    }
    public void DoneAttackingAnimEvent()
    {
        weaponCollider.gameObject.SetActive(false);
    }

    //CALLED AS EVENT IN ANIMATIONS

    public void SetAttackContinuesFalse()
    {
        myAnimator.SetBool("AttackContinues", false);

    }
    private void SetIsAttackingBoolTrue()
    {
        myAnimator.SetBool("IsAttacking", true);
    }
    private void SetIsAttackingBoolFalse()
    {
        myAnimator.SetBool("IsAttacking", false);
    }
    //CALLED AS EVENT IN ANIMATIONS

    private void PlayerInput()
    {
      
       myAnimator.SetFloat("moveX", movement.x);
       myAnimator.SetFloat("moveY", movement.y);

        if (IsDrinking == false)
        {
            movement = playerControls.Movement.Move.ReadValue<Vector2>();
        }
        else 
        {
            movement = new Vector2(0, 0);
        }
       playerControls.Combat.Attack.started += _ => Attack();
    }

    private void Move()
    {
        if (myAnimator.GetBool("IsAttacking") == true || IsDrinking == true)
        {
            movement = new Vector2(0,0);
        }
        
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
            weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0);
            facingLeft = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
            facingLeft = false;
        }
    }

    public void DrankHealingPotion()
    {
        gameData.HealingPotionsCount = gameData.HealingPotionsCount -1;

        if(gameData.CurrentHealth+50 > gameData.MaxHealth)
        {
            gameData.CurrentHealth = gameData.MaxHealth;
        }
        else { 
            gameData.CurrentHealth = gameData.CurrentHealth + 50; 
        }
            
    }
    private void TakeDamage(int damage)
    {
        gameData.CurrentHealth -= damage;

    }

    public void playAttackSound(int clipID)
    {
        if (clipID == 1)
        {
            AttackSoundSource.clip = Attack1;
            AttackSoundSource.Play();
        }
        else if (clipID == 2)
        {
            AttackSoundSource.clip = Attack2;
            AttackSoundSource.Play();
        }
        else if (clipID == 3)
        {
            AttackSoundSource.clip = Attack3;
            AttackSoundSource.Play();
        }

    }

    public void playRunSound()
    {
        RunSoundSource.Play();
    }
    public void StopRunSound()
    {
        RunSoundSource.Stop();
    }
}
