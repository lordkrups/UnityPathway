using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUnitThree : MonoBehaviour
{
    [SerializeField] public bool GAME_OVER = false;
    private Rigidbody playerRb;
    [SerializeField] private GameObject playerModel;
    private Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dustParticle;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    [SerializeField] public bool isOnGround = true;
    [SerializeField] public float jumpForce = 10f;
    [SerializeField] public float gravityModifier = 1f;
    [SerializeField] public Vector3 lastGroundPos;

    // Start is called before the first frame update
    void Start()
    {
        //zxim
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GAME_OVER)
        {
            lastGroundPos = new Vector3();
            lastGroundPos = playerModel.transform.position;
            playerAnimator.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            isOnGround = false;
            dustParticle.Stop();
        }
        if (!isOnGround)
        {
            if (playerModel.transform.position.x >= transform.position.x)
            {
                playerModel.transform.position = transform.position;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dustParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1.0f);
            explosionParticle.Play();
            dustParticle.Stop();
            GAME_OVER = true;
            Debug.Log("GAME OVER: " + GAME_OVER);
        }

    }
}
