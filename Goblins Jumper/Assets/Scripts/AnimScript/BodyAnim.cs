using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAnim : MonoBehaviour {

    private Animator anim;
	void Start () {
        anim = GetComponent<Animator>();
	}
	

	void Update () {
		if(PlayerController.isGrounded==false)
        {
            anim.SetBool("isGrounded", false);
        }
        if (PlayerController.isGrounded == true)
        {
            anim.SetBool("isGrounded", true);
        }
    }
}
