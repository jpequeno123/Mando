using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{


    [SerializeField] Transform groundCheck;
    [SerializeField] Transform wallCheck;
    [SerializeField] Transform dstairCheck;
    [SerializeField] Transform ustairCheck;
    [SerializeField] Transform playerCheck;
    [SerializeField] Transform cliffCheck;

    [SerializeField] float Circleradius;



    [SerializeField] Transform player;

    [SerializeField] private LayerMask SimpsLayer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask cliffLayer;
    [SerializeField] float jumpheight;
    [SerializeField] Vector2 boxSize;
    [SerializeField] Vector2 boxSize1;
    [SerializeField] float speed;
    [SerializeField] float attackRange;





    private bool isAPlayer;
    private bool isGrounded;
    private bool wallinf;
    private bool nGroundinf;
    private bool stairinf;
    private bool facingright;
    private bool acliff;


    public int maxHealth = 200;
    public int currentHealth;


    public HealthBar healthBar;                                                                            //HEALTHBAR
    //public BossFlip boss;                                                                                     FLIP
    public Animator animator;
    private int Fc;
    private float MoveDirection;
    private int cont;
    Rigidbody2D rb;
    //private bool bump;
    private float natk;
    private bool flipped;
    private bool IsAttacking;
    public int isFlipped;
    private bool dead;





    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        natk = 0f;
        Fc = 0;
        MoveDirection = -1f;
        cont = 0;

        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);                                                                           // HEALTHBAR
        IsAttacking = false;
        facingright = false;
        isFlipped = -1;
        dead = false;
    }





    public void Die()
    {
        //Debug.Log("Enemy died!");

        animator.SetBool("IsDead", true);

        GetComponent<CircleCollider2D>().enabled = false;

        this.enabled = false;
    }

    public void FixedUpdate()
    {
        IsAttacking = animator.GetBool("IsJumpingAt");
        isAPlayer = Physics2D.OverlapBox(wallCheck.position, boxSize1, 0, SimpsLayer);
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        nGroundinf = Physics2D.OverlapCircle(dstairCheck.position, Circleradius, groundLayer);
        wallinf = Physics2D.OverlapCircle(wallCheck.position, Circleradius, groundLayer);
        acliff = Physics2D.OverlapCircle(cliffCheck.position, Circleradius, cliffLayer);

        if (isGrounded == false)                                                                    //certo
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsRunning", false);
        }
        else if (isGrounded == true && IsAttacking == false)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsRunning", true);                                //certo
            if (isAPlayer == true || Fc == 1)
            {

                //Debug.Log("Atacarrrrrrrrrrrr");
                Fc = 1;
                {

                    if (acliff)
                    {
                        Fc = 0;
                        if (cont % 2 == 0)
                        {
                            FLIP_Petrol();
                            cont += 1;
                        }


                    }
                    LookAtPlayer();
                    Vector2 target = new Vector2(player.position.x, rb.position.y);
                    Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
                    rb.MovePosition(newPos);
                    if (Vector2.Distance(player.position, rb.position) <= (1.9f*1.5f) && IsAttacking == false)
                    {
                        animator.SetTrigger("Attack");
                        //Debug.Log("Attack");

                    }





                }
            }
            else if ((isAPlayer == false || Fc == 0) && isGrounded == true)
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsRunning", true);
                //Debug.Log("Modo Patrulha Pata");
                Petrol();                                           //check
                                                                    //Debug.Log("ESTRNHo");
            }

        }

        //Debug.Log(isFlipped);
        //Debug.Log(rb.velocity.x);
    }
    void FLIP_Petrol()
    {

        //        cont += 1;
        //        if(cont%2!=0)
        //        {
        //            isFlipped = 1;
        //        }
        //        if (cont % 2 == 0)
        //        {
        //            isFlipped = -1;
        //        }
        isFlipped *= -1;
        MoveDirection *= -1;
        facingright = !facingright;
        transform.Rotate(0, 180, 0);
    }

    void Petrol()
    {
        if ((!nGroundinf || wallinf) && isGrounded)
        {
            cont += 1;
            if (facingright)
            {
                FLIP_Petrol();
            }
            else if (!facingright)
            {
                FLIP_Petrol();
            }
        }

        rb.velocity = new Vector2(speed * MoveDirection, rb.velocity.y);
    }


    public void LookAtPlayer()
    {                                                                           ///Check
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x > player.position.x && isFlipped == 1)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped *= -1;

        }
        else if (transform.position.x < player.position.x && isFlipped == -1)
        {


            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped *= -1;

        }
    }
//    public void JumpAttack()
//    {
//
//        //boss.LookAtPlayer();                                                           PARA VIR A IMGEM DIRANTE O SALTO
//
//        float distanceFromPLayer = player.position.x - rb.position.x;
//
//        rb.AddForce(new Vector2(distanceFromPLayer, jumpheight), ForceMode2D.Impulse);
//    }
//    public void bruhJumpAttack()
//    {
//        //boss.LookAtPlayer();                                                           PARA VIR A IMGEM DIRANTE O SALTO
//        float distanceFromPLayer = player.position.x - rb.position.x;
//        rb.AddForce(new Vector2(distanceFromPLayer, -20f), ForceMode2D.Impulse);
//    }
    public void TakeDamage(int damage)
    {
        flipped = animator.GetBool("Iflipped");
        currentHealth -= damage;
        natk += 0.5f;
        if (!dead)
        {
            animator.SetTrigger("Hurt");
        }
        if (currentHealth <= 0)
        {
            dead = true;
            animator.SetBool("IsDead", true);
            Die();

        }
            

//        else if ((natk % 2f == 0) && natk != 0)
//        {
//
//            animator.SetBool("IsJumpingAt", true);
//
//        }




        healthBar.SetHealth(currentHealth);                                                                           // HEALTHBAR
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundCheck.position, boxSize);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(playerCheck.position, boxSize1);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(wallCheck.position, Circleradius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(dstairCheck.position, Circleradius);
    }

}

