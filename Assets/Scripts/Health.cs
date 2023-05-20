using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hitpoints = 1;
    [SerializeField] Animator anim;

    public void TakeDamage(int damage){
        hitpoints -= damage;

        if (hitpoints <= 0){
            Die();
        }
    }

    private void Die(){
        anim.SetTrigger("die");
        GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 1f);
    }

}
