using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript22 : MonoBehaviour
{
    //&& and
    //two straight lines or
    //== same as
    //!= not the same as 
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    public float moveSpeed;         //floats are decimals
    private bool facingRight;       //bools are true or false statements 
    [SerializeField]
    private Transform[] groundPoints;   //creates an array of "points" (actually game objects) to collide with the ground
    [SerializeField]
    private float groundRadius; //creates the siz of the colliders
    [SerializeField]
    private LayerMask whatIsGround; //creates the size of the colliders
    private bool isGrounded;  //defines what is ground
    private bool jump;  //can be set to true or false based on our position
    [SerializeField]
    private float jumpForce;    //allows us to determine the magnitude of the jump
    public bool isAlive;
    public GameObject reset;
    private Slider healthBar;
    public float health = 10f;
    private float healthBurn = 3f;
    private float healthGain = 3f;
    

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();      //a variable to control Players body 
        myAnimator = GetComponent<Animator>();  //a variable that controls the animation of the player
        isAlive = true;
        reset.SetActive(false);
        healthBar = GameObject.Find("health slider").GetComponent<Slider>();
        healthBar.minValue = 0f;
        healthBar.maxValue = health;
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive) {
            float horizontal = Input.GetAxis("Horizontal");     //a variable that stores the value of our horizontal movements(key presses)
                                                                //Debug.Log(horizontal);
            PlayerMovement(horizontal);
            //function that controls player on the x axis
            Flip(horizontal);
            HandleInput();
        }
        else { return;
        }

        isGrounded = IsGrounded();

    }

    //function definitions
    private void PlayerMovement(float horizontal)
    {
        if (isGrounded && jump)
        {
            isGrounded = false;
            jump = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
        }
        myRigidbody.velocity = new Vector2(horizontal * moveSpeed, myRigidbody.velocity.y); //adds velocity to the player's body on the x axis 
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));

    }


    private void Flip(float horizontal)
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;  //resets the bool to the opposite value
            Vector2 theScale = transform.localScale;    //creating a vector 2 and storing the local scale values 
            theScale.x *= -1;        //
            transform.localScale = theScale;
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            //Debug.Log ("I'm jumping")
            myAnimator.SetBool("jumping", true);
        }

    }
    //function to test for collisions between the array of groundPoints and the Ground LayerMask

    private bool IsGrounded()
    {
        if (myRigidbody.velocity.y <= 0)
        {
            //if the player is not moving vertically, test each of the Player's groundPoints for collision with Ground
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; 1 < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject) //if any of the colliders in the array of groundPoints comes into contact with another gameobject, return true.
                    {
                        return true;

                    }
                }
            }
        }
        return false; //if the player is not moving along the y axis, return false.
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "ground")
        {
            myAnimator.SetBool("jumping", false);
        }
        if (target.gameObject.tag == "deadly")
        {
            ImDead();
        }
        if (target.gameObject.tag == "damage")
        {
            UpdateHealth();
        }
        if (target.gameObject.tag == "Potion")
        {
            jumpForce = jumpForce + 150f;
        }
        if (target.gameObject.tag == "HealthPotion")
        {
            GainHealth();
        }
    }
    void GainHealth()
    {
        if (health < 10)
        {
            healthBar.value = health + healthGain;
        }
       
    }
    void UpdateHealth()
    {
        if (health > 0)
        {
            health -= healthBurn;   //health = health - healthBurn 
            healthBar.value = health;
        }
        if (health <= 0)
        {
            ImDead();   
        }

    }
    public void ImDead()
    {
        isAlive = false;
        myAnimator.SetBool("dead", true);
        reset.SetActive(true);
        healthBar.value = 0f;
    }
    IEnumerator Hurt()
    {
        myAnimator.Play("Player_Hurt");
        yield return new WaitForSeconds(.7f);
        myAnimator.Play("Player Running");
    }
}
