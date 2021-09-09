using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFall : MonoBehaviour
{

    [SerializeField] private LayerMask SimpsLayer;
    [SerializeField] private LayerMask enemy;

    [SerializeField] Transform Death0;
    [SerializeField] Vector2 boxZize0;

    [SerializeField] Transform Death1;            
    [SerializeField] Vector2 boxZize1;


    //    [SerializeField] Transform Death[];                   Para adicionar Outra caixa             
    //    [SerializeField] Vector2 boxZize[];                   Para adicionar Outra caixa

    public void FixedUpdate()
    {

        Collider2D[] isAPlayer0 = Physics2D.OverlapBoxAll(Death0.position, boxZize0, 0, SimpsLayer);
        Collider2D[] isAenemy0 = Physics2D.OverlapBoxAll(Death0.position, boxZize0, 0, enemy);

        Collider2D[] isAPlayer1 = Physics2D.OverlapBoxAll(Death1.position, boxZize1, 0, SimpsLayer);
        Collider2D[] isAenemy1 = Physics2D.OverlapBoxAll(Death1.position, boxZize1, 0, enemy);


        //        Collider2D[] isAPlayer[] = Physics2D.OverlapBoxAll(Death[].position, boxZize[], 0, SimpsLayer);                                                  Para adicionar Outra caixa 
        //        Collider2D[] isAenemy[] = Physics2D.OverlapBoxAll(Death[].position, boxZize[], 0, enemy);                                                        Para adicionar Outra caixa 


        foreach (Collider2D player in isAPlayer0)
        {
            player.GetComponent<PlayerHealth>().Die();
        }
        
        foreach (Collider2D enemy in isAenemy0)
        {
            enemy.GetComponent<Enemy>().Die();
        }

        foreach (Collider2D player in isAPlayer1) 
        {
            player.GetComponent<PlayerHealth>().Die();
        }

        foreach (Collider2D enemy in isAenemy1)
        {
            enemy.GetComponent<Enemy>().Die();
        }

        //        foreach (Collider2D player in isAPlayer[])                                                                                                     Para adicionar Outra caixa 
        //        {
        //            player.GetComponent<PlayerHealth>().Die();                                                                                               Para adicionar Outra caixa 
        //        }
        //
        //        foreach (Collider2D enemy in isAenemy[])                                                                                                       Para adicionar Outra caixa 
        //        {
        //            enemy.GetComponent<Enemy>().Die();                                                                                                       Para adicionar Outra caixa 
        //        }


    }

    void OnDrawGizmosSelected()
    {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireCube(Death0.position, boxZize0);

    Gizmos.color = Color.green;
    Gizmos.DrawWireCube(Death1.position, boxZize1);

        //        Gizmos.color = Color.[yellow];                                                                                                               Para adicionar Outra caixa 
        //        Gizmos.DrawWireCube(Death[].position, boxZize[]);
    }
}
