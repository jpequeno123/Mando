using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaHeal : MonoBehaviour
{

    [SerializeField] public int Heal;

    public GameObject bruh;

    public Vector3 HealOffset;
    public float HealRange = 1f;
    public LayerMask attackMask;
    int Fc;
    void start()
    {
        Fc = 0;
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos += transform.right * HealOffset.x;
        pos += transform.up * HealOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, HealRange, attackMask);
        if (colInfo != null && Fc == 0)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(Heal);
            Fc = 1;
            bruh.SetActive(false);
        }

    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * HealOffset.x;
        pos += transform.up * HealOffset.y;

        Gizmos.DrawWireSphere(pos, HealRange);
    }
}
