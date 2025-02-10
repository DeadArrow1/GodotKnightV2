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
    public AudioSource HitTakenAudioSource;

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

    [SerializeField]
    GameObject RightLowerLegIdle;
    [SerializeField]
    GameObject LeftLowerLeg;
    [SerializeField]
    GameObject LeftLowerFoot;
    [SerializeField]
    GameObject RightLowerLegActive;
    [SerializeField]
    GameObject RightLowerFoot_0;



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

        if (gameData.PlayerUpdateVisual)
        {
           

            //boots
            #region single texture parts

            GameObject Head = GameObject.Find("Head");
            if (Equipment.Helmet != null)
            {
                
                Sprite ItemImage = Resources.Load(Equipment.Helmet.imagePath, typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImage = Head.GetComponent<SpriteRenderer>();
                CurrentImage.sprite = ItemImage;
            
            }
            else 
            {
                Sprite ItemImage = Resources.Load("GameSIzeAssets/Head", typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImage = Head.GetComponent<SpriteRenderer>();
                CurrentImage.sprite = ItemImage;
            
            }


            GameObject Torso = GameObject.Find("Torso_0");
            if (Equipment.Chest != null)
            {

                Sprite ItemImage = Resources.Load(Equipment.Chest.imagePath, typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImage = Torso.GetComponent<SpriteRenderer>();
                CurrentImage.sprite = ItemImage;
              
            }
            else
            {
                Sprite ItemImage = Resources.Load("GameSIzeAssets/Torso", typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImage = Torso.GetComponent<SpriteRenderer>();
                CurrentImage.sprite = ItemImage;
                
            }
            #endregion



            #region shoulders
            GameObject RightUpperArm = GameObject.Find("RightUpperArm");
            GameObject LeftUpperArm = GameObject.Find("LeftUpperArm");
            if (Equipment.Shoulders != null)
            {
                
                //  GameSIzeAssets/ArmorSets/Cavalier/RightUpperArm
                string leftUpperArmPath = Equipment.Shoulders.imagePath.Replace("RightUpperArm", "LeftUpperArm");

                //right shoulder
                Sprite ItemImage = Resources.Load(Equipment.Shoulders.imagePath, typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImage = RightUpperArm.GetComponent<SpriteRenderer>();
                CurrentImage.sprite = ItemImage;

                //left shoulder
                Sprite ItemImageleft = Resources.Load(leftUpperArmPath, typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageleft = LeftUpperArm.GetComponent<SpriteRenderer>();
                CurrentImageleft.sprite = ItemImageleft;
            }
            else
            {
                Sprite ItemImage = Resources.Load("GameSIzeAssets/RightUpperArm", typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImage = RightUpperArm.GetComponent<SpriteRenderer>();
                CurrentImage.sprite = ItemImage;

                //left shoulder
                Sprite ItemImageleft = Resources.Load("GameSIzeAssets/LeftUpperArm", typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageleft = LeftUpperArm.GetComponent<SpriteRenderer>();
                CurrentImageleft.sprite = ItemImageleft;


            }
            #endregion

            #region Gauntlets
            //gauntlets
            GameObject RightLowerArm = GameObject.Find("RightLowerArm");
            GameObject LeftLowerArm = GameObject.Find("LeftLowerArm");
            if (Equipment.Gauntlets != null)
            {

                //  GameSIzeAssets/ArmorSets/Cavalier/RightUpperArm
                string leftlowerArmPath = Equipment.Gauntlets.imagePath.Replace("RightLowerArm", "LeftLowerArm");

                //right shoulder
                Sprite ItemImage = Resources.Load(Equipment.Gauntlets.imagePath, typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImage = RightLowerArm.GetComponent<SpriteRenderer>();
                CurrentImage.sprite = ItemImage;

                //left shoulder
                Sprite ItemImageleft = Resources.Load(leftlowerArmPath, typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageleft = LeftLowerArm.GetComponent<SpriteRenderer>();
                CurrentImageleft.sprite = ItemImageleft;
            }
            else
            {
                Sprite ItemImage = Resources.Load("GameSIzeAssets/RightLowerArm", typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImage = RightLowerArm.GetComponent<SpriteRenderer>();
                CurrentImage.sprite = ItemImage;

                //left shoulder
                Sprite ItemImageleft = Resources.Load("GameSIzeAssets/LeftLowerArm", typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageleft = LeftLowerArm.GetComponent<SpriteRenderer>();
                CurrentImageleft.sprite = ItemImageleft;


            }
            #endregion


            #region Leggins
            //Leggins
            GameObject RightUpperLeg = GameObject.Find("RightUpperLeg_0");
            GameObject LeftUpperLeg = GameObject.Find("LeftUpperLeg_0");
            if (Equipment.Leggins != null)
            {

                //  GameSIzeAssets/ArmorSets/Cavalier/RightUpperArm
                string leftupperArmPath = Equipment.Leggins.imagePath.Replace("RightUpperLeg", "LeftUpperLeg");

                //right shoulder
                Sprite ItemImage = Resources.Load(Equipment.Leggins.imagePath, typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImage = RightUpperLeg.GetComponent<SpriteRenderer>();
                CurrentImage.sprite = ItemImage;

                //left shoulder
                Sprite ItemImageleft = Resources.Load(leftupperArmPath, typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageleft = LeftUpperLeg.GetComponent<SpriteRenderer>();
                CurrentImageleft.sprite = ItemImageleft;
            }
            else
            {
                Sprite ItemImage = Resources.Load("GameSIzeAssets/RightUpperLeg", typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImage = RightUpperLeg.GetComponent<SpriteRenderer>();
                CurrentImage.sprite = ItemImage;

                //left shoulder
                Sprite ItemImageleft = Resources.Load("GameSIzeAssets/LeftUpperLeg", typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageleft = LeftUpperLeg.GetComponent<SpriteRenderer>();
                CurrentImageleft.sprite = ItemImageleft;


            }
            #endregion


            #region Boots
     
            
            
            
            if (Equipment.Boots != null)
            {
                //prepare all files from the given sprite
                //GameSIzeAssets/ArmorSets/Cavalier/RightLowerLeg
                string LeftLowerLegPath = Equipment.Boots.imagePath.Replace("RightLowerLeg", "LeftLowerLeg");
                string LeftLowerFootPath = Equipment.Boots.imagePath.Replace("RightLowerLeg", "LeftLowerFoot");

                string RightLowerLegActivePath = LeftLowerLegPath;

                string RightLowerFoot_0Path = LeftLowerFootPath;

                //right leg
                Sprite ItemImage = Resources.Load(Equipment.Boots.imagePath, typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImage = RightLowerLegIdle.GetComponent<SpriteRenderer>();
                CurrentImage.sprite = ItemImage;

                Sprite ItemImageLegActive = Resources.Load(RightLowerLegActivePath, typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageLegActive = RightLowerLegActive.GetComponent<SpriteRenderer>();
                CurrentImageLegActive.sprite = ItemImageLegActive;


                Sprite ItemImageFootActive = Resources.Load(RightLowerFoot_0Path, typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageFootActive = RightLowerFoot_0.GetComponent<SpriteRenderer>();
                CurrentImageFootActive.sprite = ItemImageFootActive;

                //left leg
                Sprite ItemImageleft = Resources.Load(LeftLowerLegPath, typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageleft = LeftLowerLeg.GetComponent<SpriteRenderer>();
                CurrentImageleft.sprite = ItemImageleft;

                Sprite ItemImageleftFoot = Resources.Load(LeftLowerFootPath, typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageleftFoot= LeftLowerFoot.GetComponent<SpriteRenderer>();
                CurrentImageleftFoot.sprite = ItemImageleftFoot;
            }
            else
            {
                Sprite ItemImage = Resources.Load("GameSIzeAssets/RightLowerLeg", typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImage = RightLowerLegIdle.GetComponent<SpriteRenderer>();
                CurrentImage.sprite = ItemImage;

                Sprite ItemImageLegActive = Resources.Load("GameSIzeAssets/LeftLowerLeg", typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageLegActive = RightLowerLegActive.GetComponent<SpriteRenderer>();
                CurrentImageLegActive.sprite = ItemImageLegActive;


                Sprite ItemImageFootActive = Resources.Load("GameSIzeAssets/LeftLowerFoot", typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageFootActive = RightLowerFoot_0.GetComponent<SpriteRenderer>();
                CurrentImageFootActive.sprite = ItemImageFootActive;

                //left leg
                Sprite ItemImageleft = Resources.Load("GameSIzeAssets/LeftLowerLeg", typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageleft = LeftLowerLeg.GetComponent<SpriteRenderer>();
                CurrentImageleft.sprite = ItemImageleft;

                Sprite ItemImageleftFoot = Resources.Load("GameSIzeAssets/LeftLowerFoot", typeof(Sprite)) as Sprite;
                SpriteRenderer CurrentImageleftFoot = LeftLowerFoot.GetComponent<SpriteRenderer>();
                CurrentImageleftFoot.sprite = ItemImageleftFoot;


            }
            #endregion
            gameData.PlayerUpdateVisual = false;

           


        }


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
        int baseHealingAmount = 50;

        //SKILL MODIFICATION
        double additionalHealing = baseHealingAmount * (0.25 * gameData.SkillTreeListSkillObtainedStatus[15] + 0.25 * gameData.SkillTreeListSkillObtainedStatus[22] + 0.25 * gameData.SkillTreeListSkillObtainedStatus[30] + 0.25 * gameData.SkillTreeListSkillObtainedStatus[38]);
        additionalHealing = additionalHealing + gameData.SkillTreeListSkillObtainedStatus[38] * 0.1 * gameData.MaxHealth;


        int healingAmount = (int)Mathf.Round((float)(baseHealingAmount + additionalHealing));

        //SKILL MODIFICATION END


        if (gameData.CurrentHealth+ healingAmount > gameData.MaxHealth)
        {
            gameData.CurrentHealth = gameData.MaxHealth;
        }
        else { 
            gameData.CurrentHealth = gameData.CurrentHealth + healingAmount; 
        }
            
    }
    public void TakeDamage(int damage)
    {
        int finalDamage = damage;
        //armor = 100

        //damage 101
        //implement armor

        int minimumDamage = (int)Mathf.Round((float)(damage * 0.1));
        int substractedDamage = damage - gameData.Armor;

        if (damage > gameData.Armor && minimumDamage < substractedDamage)
        {
            finalDamage = substractedDamage; //1 dmg


        }
        else 
        {
            finalDamage = minimumDamage;//10 dmg

        }


        HitTakenAudioSource.Play();
        gameData.CurrentHealth -= finalDamage;

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
