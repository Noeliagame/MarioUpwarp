using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float runSpeed = 1.0f;
    public float jumpSpeed = 3.0f;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            _rigidbody.velocity = new Vector2(runSpeed, _rigidbody.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            _rigidbody.velocity = new Vector2(-runSpeed, _rigidbody.velocity.y);
        }
        else
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }
        if (Input.GetKey("space") && CheckGround.isGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpSpeed);
        }
    }
}
