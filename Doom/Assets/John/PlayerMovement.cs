using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    [Tooltip("How fast the player walks.")]
    public float walkSpeed;
    [Tooltip("How fast the player walks backwards.")]
    public float reverseSpeed;
    [Tooltip("How fast the player can move sideways.")]
    public float strafeSpeed;
    [Tooltip("How fast the player can rotate.")]
    public float rotateSpeed;

	float rotationY = 0f;
	public float sensitivityY = 15;
	public float minY = -60;
	public float maxY = 60;

	//Total force of the player to send it in a direction.
	Vector3 totalForce = Vector3.zero;

    [Tooltip("How high the player can jump once.")]
    public float jumpForce = 3f;
    [Tooltip("Whether or not the player is on the ground.")]
    [SerializeField] bool isGrounded = false;
    [Tooltip("Whether or not the player has used double jump.")]
    [SerializeField] bool doubleJump = false;
    [Tooltip("The rigidbody of the player.")]
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

		rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        totalForce = Vector3.zero;
        if (Input.GetAxis("Vertical") < 0)
        {
            totalForce += transform.forward * Input.GetAxis("Vertical") * (walkSpeed/2);
        }
        else
        {
            totalForce += transform.forward * Input.GetAxis("Vertical") * walkSpeed;
        }
        totalForce += transform.right * Input.GetAxis("Horizontal") * strafeSpeed;
        transform.position += totalForce * Time.deltaTime;

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);

		//Up and down rotation
		rotationY -= Input.GetAxis("Mouse Y") * sensitivityY;

		rotationY = Mathf.Clamp(rotationY, minY, maxY);
		Camera.main.transform.localEulerAngles = new Vector3(rotationY, 0, 0);

		isGrounded = Physics.Raycast(transform.position, Vector3.down, .1f);

        if(Input.GetButtonDown("Jump") && ((isGrounded) || (doubleJump)))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            if (isGrounded == false)
            {
                doubleJump = false;
            }
        }

        if (isGrounded == true)
        {
            doubleJump = true;
        }
    }
}
