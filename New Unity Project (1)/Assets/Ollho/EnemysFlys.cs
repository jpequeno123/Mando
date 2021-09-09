using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemysFlys : MonoBehaviour
{
    public Animator animator;

    public Transform target;

    [SerializeField] Vector2 boxSize1;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] Transform playerCheck;

    public float speed = 800f;
    public float nextWaypointDistance = 3f;

    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    private bool isAPlayer;
    private int fc;
    public HealthBar healthBar;

    Seeker seeker;
    Rigidbody2D rb;

    public int maxHealth = 40;
    public int currentHealth;

    private float natk;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        fc = 0;
        currentHealth = maxHealth;
        InvokeRepeating("UpdatePath", 0f, .5f);
        InvokeRepeating("CheckPlayer", 0f, 0.01f);
        
    }

    void CheckPlayer()
    {
        isAPlayer = Physics2D.OverlapBox(playerCheck.position, boxSize1, 0, playerLayer);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (isAPlayer||fc==1)
        {
            animator.SetBool("Player", true);
            fc = 1;
            if (path == null)
                return;

            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }

            if (rb.velocity.x >= 0.01f)
            {
                enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (rb.velocity.x <= -0.01f)
            {
                enemyGFX.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        natk += 0.5f;
        if (currentHealth <= 0)
        {
            animator.SetBool("Dead", true);
            animator.SetTrigger("IsDead");
                    Debug.Log("Enemy died!");
            
            rb.gravityScale = 1;
            
            this.enabled = false;
        }
        //        else if ((natk % 2f == 0) && natk != 0)
        //        {
        //
        //            animator.SetBool("IsJumpingAt", true);
        //
        //        }
        else
        {
            animator.SetTrigger("Hurt");
        }

        healthBar.SetHealth(currentHealth);



        //healthBar.SetHealth(currentHealth);                                                                           // HEALTHBAR
    }

//    public void Die()
//    {
//        Debug.Log("Enemy died!");
//
//        rb.gravityScale = 1;
//
//        gameObject.SetActive(false);
//
//        this.enabled = false;
//    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(playerCheck.position, boxSize1);
    }
}