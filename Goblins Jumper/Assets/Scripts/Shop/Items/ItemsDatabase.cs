using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDatabase : MonoBehaviour {

    private static ItemsDatabase itemDatabase=new ItemsDatabase();
    private ItemsDatabase() { }

    [SerializeField] private GameObject[] hatsObj;
    private List<Hat> hats = new List<Hat>();

    [SerializeField] private GameObject[] bodiesObj;
    private List<Body> bodies = new List<Body>();



    private void Start () {
        itemDatabase = GetComponent<ItemsDatabase>();
        hats.Add(new Hat("Creeper Hat", 53, hatsObj[0],new Vector2(0,0.1f),new Vector2(1, 1)));
        hats.Add(new Hat("Darth Vaider Hat", 35, hatsObj[1], new Vector2(0.1f, 0.1f), new Vector2(1, 1)));
        hats.Add(new Hat("New Year Hat", 3, hatsObj[2], new Vector2(0, 0.35f), new Vector2(1, 1)));

        bodies.Add(new Body("Metal Body",105,bodiesObj[0], new Vector2(0, 0f), new Vector2(0.8f, 0.8f)));
        bodies.Add(new Body("Cloth Body", 105, bodiesObj[1], new Vector2(0, -0.1f), new Vector2(0.7f, 0.7f)));
        bodies.Add(new Body("Upgrade Cloth Body", 105, bodiesObj[2], new Vector2(0, 0f), new Vector2(0.7f, 0.7f)));
    }

    public static ItemsDatabase Get()
    {
        return itemDatabase;
    }

    public List<Hat> Hats()
    {
        return hats;
    }
    public List<Body> Bodies()
    {
        return bodies;
    }
}
