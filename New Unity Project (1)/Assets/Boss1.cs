using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss1 : MonoBehaviour
{


    [SerializeField] Transform groundCheck;
    [SerializeField] Transform wallCheck;
    [SerializeField] Transform dstairCheck;
    [SerializeField] Transform ustairCheck;
    [SerializeField] Transform playerCheck;
    [SerializeField] Transform cliffCheck;


    [SerializeField] private Collider2D m_Capsule1;
    [SerializeField] private Collider2D m_Capsule2;
    [SerializeField] private Collider2D m_Box0;

    [SerializeField] float Circleradius;



    [SerializeField] Transform player;

    [SerializeField] private LayerMask SimpsLayer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask cliffLayer;
    [SerializeField] float jumpheight;
    [SerializeField] Vector2 boxSize;
    [SerializeField] Vector2 boxSize1;
    [SerializeField] float speed;
    [SerializeField] float speedj;
    [SerializeField] float attackforce;

    [SerializeField] float attackRange;





    private bool isAPlayer;
    private bool isGrounded;
    private bool wallinf;
    private bool nGroundinf;
    private bool stairinf;
    //private bool facingright;
    private bool acliff;


    public int maxHealth = 200;
    public int currentHealth;


    public HealthBar healthBar;
    //public BossFlip boss;
    public Animator animator;
    private int Fc;
    //private float MoveDirection;
    //private int cont;
    Rigidbody2D rb;
    //private bool bump;
    private float natk;
    private bool flipped;
    private bool IsAttacking;
    public int isFlipped;





    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        natk = 0f;
        Fc = 0;
        //MoveDirection = -1f;
        //cont = 0;

        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        IsAttacking = false;
        //facingright = false;
        isFlipped = -1;
    }





    public void Die()
    {
        //Debug.Log("Enemy died!");

        animator.SetBool("IsDead", true);

    
        m_Capsule1.enabled = false;
        m_Capsule2.enabled = false;
        m_Box0.enabled = false;


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
                animator.SetBool("Player", true);

                //Debug.Log("Atacarrrrrrrrrrrr");
                Fc = 1;

//                    if (acliff)
//                    {
//                        Fc = 0;
//                        if (cont % 2 == 0)
//                        {
//                            FLIP_Petrol();
//                            cont += 1;
//                        }
//
//
//                    }
                    LookAtPlayer();
                    Vector2 target = new Vector2(player.position.x, rb.position.y);
                    Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
                    rb.MovePosition(newPos);
                    if ((Vector2.Distance(player.position, rb.position) <= (3.44418f)) && IsAttacking == false)
                    {
                        animator.SetTrigger("Attack");

                    }
            }
//            else if ((isAPlayer == fa lse || Fc == 0) && isGrounded == true)
//            {
//                animator.SetBool("IsJumping", false);
//                animator.SetBool("IsRunning", true);
//                Debug.Log("Modo Patrulha Pata");
//                //Petrol();                                           //check
//            }

        }

        //Debug.Log(isFlipped);
    }
//    void FLIP_Petrol()
//    {
//
//        //        cont += 1;
//        //        if(cont%2!=0)
//        //        {
//        //            isFlipped = 1;
//        //        }
//        //        if (cont % 2 == 0)
//        //        {
//        //            isFlipped = -1;
//        //        }
//        isFlipped *= -1;
//        MoveDirection *= -1;
//        facingright = !facingright;
//        transform.Rotate(0, 180, 0);
//    }

//    void Petrol()
//    {
//        if ((!nGroundinf || wallinf) && isGrounded)
//        {
//            cont += 1;
//            if (facingright)
//            {
//                FLIP_Petrol();
//            }
//            else if (!facingright)
//            {
//                FLIP_Petrol();
//            }
//        }
//
//        rb.velocity = new Vector2(speed * MoveDirection, rb.velocity.y);
//    }


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
    public void JumpAttack()
    {

        //boss.LookAtPlayer();                                                           PARA VIR A IMGEM DIRANTE O SALTO

        float distanceFromPLayer = player.position.x - rb.position.x;
        //Debug.Log(distanceFromPLayer);
        rb.AddForce(new Vector2(distanceFromPLayer, jumpheight*1.4f), ForceMode2D.Impulse);
    }
    public void bruhJumpAttack()
    {
        


        //Vector2 targetj = new Vector2(player.position.x, player.position.y);
        //Vector2 newPosj = Vector2.MoveTowards(rb.position, targetj, speedj * Time.fixedDeltaTime);
        //rb.MovePosition(newPosj);


        //boss.LookAtPlayer();
        rb.velocity = new Vector2(0, 0);                                                       //PARA VIR A IMGEM DIRANTE O SALTO
        float distanceFromPLayer = player.position.x - rb.position.x;
        
        rb.AddForce(new Vector2(distanceFromPLayer*7.5f, attackforce), ForceMode2D.Impulse);
    }
    public void TakeDamage(int damage)
    {
        flipped = animator.GetBool("Iflipped");
        currentHealth -= damage;
        natk += 1f;
        //Debug.Log(natk+"numero");
        if (currentHealth <= 0)
        {
            animator.SetTrigger("IsDead");
        }
        else if ((natk % 8f == 0) && natk != 0)
        {

            //natk = 0;
            animator.SetBool("IsJumpingAt", true);

        }
        else
        {
            animator.SetTrigger("Hurt");
        }



        healthBar.SetHealth(currentHealth);
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
