using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D playerRigibody;
    private float jumpPower=550f;
    public static bool isGrounded= false;
    public static bool isAlive = true;
    public static bool firstJump = false;

    private bool isColliderUnderPlayer = false;
    private CircleCollider2D groundChecker;
    private Vector2 corner1, corner2;
    private Vector3 max, min;
    private Collider2D hit;

    private AudioSource jumpAudio;


    private Ray2D ray;
    private RaycastHit2D rayHit;
    private Ray2D ray2;
    private RaycastHit2D rayHit2;

    [SerializeField] private GameObject point;
    [SerializeField] private GameObject rayPoint;
    [SerializeField] private GameObject rayPoint2;

    [SerializeField] private GameObject groundBorder;

    private float lastX;

    void Start () {
        playerRigibody = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<CircleCollider2D>();
        jumpAudio=GetComponent<AudioSource>();
        lastX = transform.position.x;
        groundBorder.gameObject.SetActive(false);
    }
	

	void Update ()
    {
        isGrounded = GroundedCheck();
        isColliderUnderPlayer=CheckColliderUnderPlayer();
        if (isColliderUnderPlayer && isGrounded == false)
        {
            playerRigibody.AddForce(new Vector2(300f, 0));
        }
        if (Input.GetMouseButtonDown(0) && isGrounded && isAlive && ButtonsManager.isGameStart && StartDelayTimer.canClick)
        {
            playerRigibody.AddForce(new Vector2(0, jumpPower));
            jumpAudio.Play();
            firstJump = true;
        }
        ChangePolarity();
        CheckAlive();
        if(Score.Get()>=1)
        {
            groundBorder.gameObject.SetActive(true);
        }
      
    }
    private bool GroundedCheck()
    {
        isGrounded = false;
        max = groundChecker.bounds.max;
        min = groundChecker.bounds.min;
        corner1 = new Vector2(max.x, min.y - .1f);
        corner2 = new Vector2(min.x, min.y - .1f);
        hit = Physics2D.OverlapArea(corner1, corner2);
        if (hit != null)
        {
            isGrounded = true;
        }
        return isGrounded;
    }
    private bool CheckColliderUnderPlayer()
    {
        float checkDistance = 0.05f;
        bool isCollider = false;
        ray.direction = Vector2.down;
        ray.origin = rayPoint.transform.position;
        rayHit = Physics2D.Raycast(ray.origin, ray.direction, checkDistance);
        ray2.direction = Vector2.down;
        ray2.origin = rayPoint2.transform.position;
        rayHit2 = Physics2D.Raycast(ray2.origin, ray2.direction, checkDistance);
        
        if(rayHit.collider!=null || rayHit2.collider != null)
        {
            isCollider=true;
        }
        return isCollider;
    }
    private void ChangePolarity()
    {
        if(transform.position.x-lastX>0)
        {
            transform.rotation = Quaternion.Euler(0,0,90);
        }
        if (transform.position.x - lastX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 90);
        }
        lastX = transform.position.x;
    }
    private void CheckAlive()
    {
        if(isAlive==false)
        {
            OnPlayerDead();
        }
    }

    private Animator playerAnimator;
    private void OnPlayerDead()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        playerAnimator.SetBool("isAlive",false);
        GetComponent<BoxCollider2D>().enabled = false;
       
    }

}
