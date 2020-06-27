using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothUp : MonoBehaviour {

    private GameObject player;

    [SerializeField] private GameObject head;
    [SerializeField] private GameObject bodyArmor;


    private void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        ClothEquip();   
	}
	

    private void ClothEquip()
    {
        if (PlayerPrefs.GetString("Hat")!= null)
        {
            Debug.Log("fdsf");
            Hat[] hats = ItemsDatabase.Get().Hats().ToArray();
            foreach (Hat hat in hats)
            {
                if (hat.GetName() == PlayerPrefs.GetString("Hat"))
                {
                    GameObject spawnHat = Instantiate(hat.GetObject());
                    spawnHat.transform.parent = head.transform;
                    spawnHat.transform.localScale = hat.GetAttachedScale();
                    spawnHat.transform.localPosition= hat.GetAttachedPosition();
                }
            }
        }
        if (PlayerPrefs.GetString("Body") != null)
        {
            Body[] bodyes = ItemsDatabase.Get().Bodies().ToArray();
            foreach (Body body in bodyes)
            {
                if (body.GetName() == PlayerPrefs.GetString("Body"))
                {
                    GameObject spawnBody = Instantiate(body.GetObject());
                    spawnBody.transform.parent = bodyArmor.transform;
                    spawnBody.transform.localScale = body.GetAttachedScale();
                    spawnBody.transform.localPosition =body.GetAttachedPosition();

                }
            }
        }

    }
}
