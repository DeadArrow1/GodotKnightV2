using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : Singleton<PlayerController>
{
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Transform weaponCollider;
    [SerializeField] private GameData gameData;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;

    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    
    private bool facingLeft = false;

    public GameManager gameManager;



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
        gameData.DetectLevelUp();

        if (gameData.CurrentHealth <= 0 && !gameData.isDead)
        {
            gameData.isDead = true;
            gameManager.gameOver();
        }

    }

    private void FixedUpdate()
    {
        
            AdjustPlayerFacingDirection();
            Move();
        
    }

    private void Attack()
    {
        myAnimator.SetTrigger("Attack");
        weaponCollider.gameObject.SetActive(true);
        
    }

    public void DoneAttackingAnimEvent()
    {
        weaponCollider.gameObject.SetActive(false);
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
    //CALLED AS EVENT IN ANIMATIONS

    private void PlayerInput()
    {
      
       myAnimator.SetFloat("moveX", movement.x);
       myAnimator.SetFloat("moveY", movement.y);
       movement = playerControls.Movement.Move.ReadValue<Vector2>();

       playerControls.Combat.Attack.started += _ => Attack();
    }

    private void Move()
    {
        if (myAnimator.GetBool("IsAttacking") == true)
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

    private void TakeDamage(int damage)
    {
        gameData.CurrentHealth -= damage;

    }
}
