using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkylandMove : MonoBehaviour {

    enum MoveStates {NoMove,Left,Right }
    private MoveStates state;
    private Rigidbody2D platformRigibody;
    private float speed;
    private GameObject player;
    private bool isFirstTime = true;

	private void Start () {
        platformRigibody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        ChangeState();
        speed = SpeedController.GetSpeed();
        StartCoroutine(DeleteAfterTime(4));
	}
	private void Update () {
        if(state==MoveStates.NoMove)
        {
            transform.Translate(-0, 0, 0);
        }
        if (state == MoveStates.Left)
        {
            platformRigibody.velocity = new Vector2(-speed,0);
        }
        if (state == MoveStates.Right)
        {
            platformRigibody.velocity = new Vector2(speed, 0);
        }
        DestroyOnPlayerDie();
    }

    private void ChangeState()
    {
        Vector2 direction = player.transform.position - transform.position;
        if (direction.x > 0)
        {
            state = MoveStates.Right;
        }
        else if (direction.x < 0)
        {
            state = MoveStates.Left;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if (isFirstTime)
            {

                SpawnerController.isFirstTime = true;
                isFirstTime = false;
                Score.AddOne();
            }
        }
    }
    private IEnumerator DeleteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
    private void DestroyOnPlayerDie()
    {
        if (PlayerController.isAlive == false)
        {
            Destroy(this.gameObject);
        }
    }
  
}
