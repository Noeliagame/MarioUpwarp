using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
   
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    public PausaManager pausaM;    
    private float Horizontal;
    private float Vertical;
    private bool Grounded;


    public GameObject JumpSound;
        
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(pausaM.enPausa == true)
        {
            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach(AudioSource a in audios)
            {
                a.Pause();
            }
            return;
        }
       
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        Animator.SetBool("jumping", Vertical != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 1.2f, Color.red);

        if(Physics2D.Raycast(transform.position, Vector3.down, 1.2f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
        Instantiate(JumpSound);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
}
