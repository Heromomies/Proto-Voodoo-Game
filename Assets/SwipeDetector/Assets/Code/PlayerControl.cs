using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // these are for movement and flipping
    float dir = 1;
    public float speed;
    public float jumpHeight;
    private Rigidbody2D playerRB;
    bool facingRight = true;
    //these are for swipe controls
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerRB.velocity = new Vector2(dir * speed * Time.deltaTime, playerRB.velocity.y);
        PlayerController();
        PlayerJump();
        SwipeTest();
        
    }
  
    void PlayerController()
    {//makes player flip left and right and move left and right
        if (Input.GetKeyDown(KeyCode.A)   && facingRight==true)
        {
            FlipAndMove();
            
        }
        else if (Input.GetKeyDown(KeyCode.D)  && facingRight == false)
        {
            FlipAndMove();
            
              
        }
    }
 
    void PlayerJump()
    {// makes player jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.velocity = Vector2.up * jumpHeight * Time.deltaTime;
        }
        
    }

    void FlipAndMove()
    {
        dir = -dir;
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }

    void SwipeTest()
    {

    }
   
    void swipeControl()
    {

    }
    


   
    
}
