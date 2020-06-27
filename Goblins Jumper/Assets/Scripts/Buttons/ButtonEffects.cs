using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffects : MonoBehaviour
{
    public static bool animIsPlayed = false;
    private AudioSource clickSound;
 

    private void Start()
    {
        clickSound = GetComponent<AudioSource>();
    }
    public void OnButtonDown()
    {
        transform.localScale = new Vector2(0.7f,0.7f);
        clickSound.Play();
    }
    public void OnButtonUp()
    {
        transform.localScale = new Vector2(1f, 1f);
        animIsPlayed = true;
    }
}
