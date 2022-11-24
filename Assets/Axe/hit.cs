using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class hit : MonoBehaviourPun

{
    public float health;
    public float damage;
    public AudioSource damageSound;
    public AudioSource deathSound;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.transform.root);
        Debug.Log(transform);
        if (other.gameObject.tag == "Weapon" && other.gameObject.transform.root != transform.root) {
    
            Damage();
        }

    }

    private void Damage() {
        health -= damage;
        damageSound.Play();
        if(health <= 0) {
            deathSound.Play();
            Destroy(this.gameObject);
        }
        Debug.Log(health);
    }
}
