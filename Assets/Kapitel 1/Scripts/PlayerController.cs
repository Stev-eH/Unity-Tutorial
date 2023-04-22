using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool useTransformOrRigidbody; // true = Transform; false = Rigidbody;

    // deltaTime is a property that calculates the time (in seconds) between the previous and current frame
    // if one is not using deltaTime, the actual speed of an object is determined by the speed of your processor
    public bool enableDeltaTime;

    // using Transform for movement manipulates the position of an object directly
    Transform playerTransform;

    // using Rigidbody for movement applies physical forces to an object and calculates movement
    Rigidbody playerRigidbody;

    // will be used to apply velocity to the Rigidbody
    public float sidewayForce;
    public float jumpingForce;

    // will be used to manipulate the position with Transform
    public float jumpingVelocity;
    public float speed;

    // used for jumping, we don't want to able to jump while we're in the air
    public bool grounded;

    public bool inJump;

    public bool movementLocked;
    const float lockTime = 1f;
    public float lockTimer= 0;

    // Start is called before the first frame update
    // the Start function can be used for initializing an object and its properties
    void Start()
    {
        useTransformOrRigidbody = false; // Switch between movement with Transform or Rigidbody
        enableDeltaTime = true;
        sidewayForce = 13f;
        jumpingForce = 5f;
        inJump= false;
        speed= 3.0f;
        movementLocked= true;

        playerTransform = GetComponent<Transform>(); //assigning the attached component to a variable so we can use and modify it

        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // FixedUpdate is mostly used for calculations and physics
    void FixedUpdate()
    {
        float time = enableDeltaTime ? Time.fixedDeltaTime : 1f;

        //get Keyboard input
        bool isLeftKey = Input.GetKey(KeyCode.LeftArrow);
        bool isRightKey = Input.GetKey(KeyCode.RightArrow);
        bool isUpKey = Input.GetKey(KeyCode.UpArrow);
        bool isDownKey = Input.GetKey(KeyCode.DownArrow);
        bool isJumping = Input.GetKey(KeyCode.Space);


        // we're using multiple ifs instead of an if else tree because that enables us to move in multiple directions at the same time

        if (!movementLocked)
        {
            if (useTransformOrRigidbody) // Transform movement
            {

                /*
                 * An objects global position is represented by a Vector3(float x, float y, float z)
                 * By interacting with Transform.position we can directly interact with an objects Vector3
                 */


                if (isLeftKey)
                {
                    playerTransform.position += new Vector3(-speed * time, 0f, 0f);
                }
                if (isRightKey)
                {
                    playerTransform.position += new Vector3(speed * time, 0f, 0f);
                }
                if (isUpKey)
                {
                    playerTransform.position += new Vector3(0f, 0f, speed * time);
                }
                if (isDownKey)
                {
                    playerTransform.position += new Vector3(0f, 0f, -speed * time);
                }
                if (grounded && isJumping)
                {
                    inJump = true;
                    jumpingVelocity = jumpingForce;
                    grounded = false;
                }

                if (inJump)
                {
                    transform.Translate(new Vector3(0, jumpingVelocity, 0) * time);
                    if (grounded)
                        inJump = false;
                }


            }

            if (!useTransformOrRigidbody) // Rigidbody movement
            {
                if (isLeftKey)
                {
                    playerRigidbody.AddForce(-transform.right * sidewayForce);
                }
                if (isRightKey)
                {
                    playerRigidbody.AddForce(transform.right * sidewayForce);
                }
                if (isUpKey)
                {
                    playerRigidbody.AddForce(transform.forward * sidewayForce);
                }
                if (isDownKey)
                {
                    playerRigidbody.AddForce(-transform.forward * sidewayForce);
                }
                if (grounded && isJumping)
                {
                    grounded = false;

                    /* ForceMode.Impulse, instantly applies full force to the object
                     * ForceMode default is ForceMode.Force, here the given force will be applied to the object over a second
                     * https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/
                     */
                    playerRigidbody.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse);

                }
            }
        }

        else
        {
            if (lockTimer <= 0)
                movementLocked= false;
            else
                lockTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Environment"))
        {
            grounded = true;
        }
    }

    // sets the character back to 0 1 0
    public void ResetPosition()
    {
        playerTransform.position = new Vector3(0, 1f, 0);

        // velocity has to be set to 0 aswell or else we keep sliding even after our movement is locked
        playerRigidbody.velocity = Vector3.zero;
        movementLocked = true;
        lockTimer = lockTime;
    }
}

