using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hitpoints = 1;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] float minPitch = -1;
    [SerializeField] float maxPitch = 2;

    public void TakeDamage(int damage){
        hitpoints -= damage;
        AudioRandomPitch(hitSFX);
        if (hitpoints <= 0){
            Die();
        }
    }

    private void Die(){
        anim.SetTrigger("die");
        AudioRandomPitch(deathSFX);
        GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 1f);
    }

    private void AudioRandomPitch(AudioClip clip){
        sfx.pitch = Random.Range(minPitch, maxPitch);
        sfx.PlayOneShot(clip);
    }

}
