using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    CharacterController characterController;
    Animator animator; // Character animator (MainAnimator)

    public float speed;         // current speed
    public float sprintSpeed;   // default sprinting speed
    public float defaultSpeed;  // default walking speed
    public float jumpSpeed;     // how high can jump
    public float gravity;       // how fast it will land / gravity pull

    // Move direction vector and animator inputs
    private Vector3 moveDirection = Vector3.zero;
    float InputX = 0.0f;
    float InputY = 0.0f;

    //Etc
    public ParticleSystem dust;

    //COLLIDERS
    public bool hasSword;
    public Collider attackCollider;
    public Collider meleeCollider;

    void Start()
    {
        // Get Character Controller
        characterController = GetComponent<CharacterController>();
        // Get Animator
        animator = this.gameObject.GetComponent<Animator>();
        if(hasSword == false)
        {
            attackCollider = meleeCollider;
        }
        attackCollider.enabled = false;
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (characterController.isGrounded)
        {
           
            // Move character if it is grounded

            // Zero the InputX/Y parameters in animator
            animator.SetFloat("InputX", 0f);
            animator.SetFloat("InputY", 0f);
            // new direction of moving with speed
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
            moveDirection *= speed;
            
            // Move left
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f+90f, 0f);
                InputX = Input.GetAxis("Horizontal");
                animator.SetFloat("InputX", InputX);
            }
            // Move right
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 180f+90f, 0f);
                InputX = Input.GetAxis("Horizontal");
                animator.SetFloat("InputX", InputX);
            }
            // Move down (Crouch)
            if (Input.GetAxis("Vertical") < 0)
            {
                InputY = Input.GetAxis("Vertical");
                animator.SetFloat("InputY", InputY);

                characterController.height = 1f;
                characterController.center = new Vector3(0f, 0.5f, 0f);
            }
            else
            {
                characterController.height = 2f;
                characterController.center = new Vector3(0f, 1f, 0f);
            }
            // Move up
            // Now nothing
            // Later camera tilt up 
            if(Input.GetAxis("Vertical") > 0)
            {
                return;
            }

            //attack
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetBool("Attack01", true);
            }
            else
            {
                animator.SetBool("Attack01", false);

            }

            // Jump when jump is pressed.
            if (Input.GetButton("Jump"))
            {
                animator.SetBool("Jump", true);
                StartDust();
                moveDirection.y = jumpSpeed;
            }
            else
            {
                animator.SetBool("Jump", false);
            }


            // Sprint when sprint is pressed 
            // and increase the speed to sprint speed
            if (Input.GetButton("Sprint"))
            {
                speed = sprintSpeed;
                animator.SetBool("Sprint", true);
                StartDust();
            }
            // If sprint is not enabled default speed.
            else
            {
                speed = defaultSpeed;
                animator.SetBool("Sprint", false);
            }

        }


        //CHEATS
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            GetComponent<PlayerHealth>().IncreaseHealth();
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            GetComponent<PlayerHealth>().TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            GetComponent<PlayerHealth>().PlayerInvincible(10);
        }
        if (Input.GetKeyDown(KeyCode.KeypadDivide))
        {
            GetComponent<PlayerHealth>().FullHeal();
        }





        // If the player is not grounded

        // Move the player up
        // and take down with gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move character while jumping in direction(left/right)
        // !!!! Cant change directions yet while jumping  !!!!
        characterController.Move(moveDirection * Time.deltaTime);

    }
    void StartDust()
    {
        dust.Play();
    }
    public void EnableAttack()
    {
        gameObject.GetComponent<Knockback>().knockBackEnabled = false;
        attackCollider.enabled = true;
    }
    public void DisableAttack()
    {
        gameObject.GetComponent<Knockback>().knockBackEnabled = true;
        attackCollider.enabled = false;
    }

}