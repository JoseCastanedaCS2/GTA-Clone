using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    public int curHp;
    public int maxHp;

    public float moveSpeed;
    public float jumpForce;
    public float attackRange;
    public int damage;
    public int stepNum;
    public bool isStepping = false;

    private bool isAttacking;

    private AudioSource audioSource;
    public AudioClip[] audioClips;

    public GameObject player;
    public Rigidbody rig;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    void Move() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir *= moveSpeed;

        dir.y = rig.velocity.y;
        rig.velocity = dir;

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) {
            player.GetComponent<Animation>().Play("Running");
        }
        else {
            if (Pistol.isFiring == false && Pistol.isAiming == false && M1.isTexting == false)
                player.GetComponent<Animation>().Play("Idle");
        }
    }

    void Jump() 
    {
        if (CanJump()) {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool CanJump() 
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, -0.1f)) {
            return hit.collider != null;
        }
        return false;
    }

    void Step() 
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip() 
    {
        int index = Random.Range(0, audioClips.Length);
        return audioClips[index];
    }
}
