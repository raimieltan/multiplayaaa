using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attacker : MonoBehaviourPun
{


 
    bool canAttack;
    
    private Animator animator;

    private void Awake()
    {

        animator = GetComponent<Animator>();
        canAttack = true;
    }
    private void Update()
    {
        	if( photonView.IsMine == false && PhotonNetwork.IsConnected == true )
	        {
	            return;
	        }

			// failSafe is missing Animator component on GameObject
	        if (!animator)
	        {
				return;
			}
        
        if(Input.GetButtonDown("Fire1") && canAttack) {
                StartCoroutine(attackMelee());
        }

    }

    IEnumerator attackMelee() {
        canAttack = false;

        animator.Play("Attack", 0, 0.25f);
        yield return new WaitForSeconds(1.3f);

        canAttack = true;

    }

}
