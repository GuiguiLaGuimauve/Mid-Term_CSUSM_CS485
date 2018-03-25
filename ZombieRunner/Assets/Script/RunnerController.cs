using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunnerController : MonoBehaviour {

    public float speed = 10.0f;
    public LayerMask ground;
    public Transform feet;
    public float jumpHeight;
    public float gravity;
    public Text text;
    public Button button;

    private bool isTouched;
    private float chrono;
    private Vector3 walkingVelocity;
    private Vector3 fallingVelocity;
    private int count;
    
    private CharacterController controller;

    // Use this for initialization
    void Start () {
        isTouched = false;
        chrono = 0f;
        count = 1;
        gravity = 9.8f;
        jumpHeight = 3.0f;
        fallingVelocity = Vector3.zero;
        text.text = "";
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if (isTouched == false)
            chrono += Time.deltaTime;
        Vector3 moveDirSide = transform.right * horiz * speed;
        Vector3 moveDirForward = transform.forward * vert * speed;

        controller.Move(moveDirSide * Time.deltaTime);
        controller.Move(moveDirForward * Time.deltaTime);
        
        bool isGrounded = Physics.CheckSphere(feet.position, 0.1f, ground, QueryTriggerInteraction.Ignore);
        if (isGrounded)
            fallingVelocity.y = 0f;
        else
            fallingVelocity.y -= gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                fallingVelocity.y = Mathf.Sqrt(gravity * jumpHeight);
            }
            controller.Move(fallingVelocity * Time.deltaTime);
        

        if (Input.GetKeyDown("escape"))
        {
                Cursor.lockState = CursorLockMode.None;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            isTouched = true;
            Debug.Log("Test");
            text.text = "You survived " + chrono.ToString("0") +" seconds click retry";
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(1850, 10, 50, 25), chrono.ToString("0"));
    }
}
