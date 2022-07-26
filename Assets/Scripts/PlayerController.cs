using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private bool isOnGround = true;

    public float speed = 5.0f;
    public float sensitivity = 1000.0f;
    public float jumpForce = 500.0f;
    public float gravityModifier = 1.5f;
    public float vertBound = 24.0f;
    public float horizBound = 24.0f;
    public float sfxVolume = 1.0f;

    public AudioClip jumpClip;
    public AudioClip shootClip;
    private AudioSource playerAudio;
   
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        ConstrainMovement();

        Fire();

    }

    private void MovePlayer()
    {
        float horizontalMouseAxis = Input.GetAxis("Mouse X");
        float vertMouseAxis = Input.GetAxis("Mouse Y");

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.left * speed * verticalInput * Time.deltaTime);

        transform.Rotate(new Vector3(0, horizontalMouseAxis, 0) * sensitivity * Time.deltaTime);
        //playerRb.AddForce(Vector3.forward * verticalInput * speed, ForceMode.Acceleration);
        //playerRb.AddForce(Vector3.right * horizontalInput * speed, ForceMode.Acceleration);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpClip, sfxVolume);
            isOnGround = false;
        }
    }

    private void ConstrainMovement()
    {
        if (transform.position.x < -horizBound)
        {
            transform.position = new Vector3(-horizBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x > horizBound)
        {
            transform.position = new Vector3(horizBound, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -vertBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -vertBound);
        }
        if (transform.position.z > vertBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, vertBound);
        }
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectilePrefab, transform.GetChild(0).position, transform.GetChild(0).rotation);
            playerAudio.PlayOneShot(shootClip, sfxVolume);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
