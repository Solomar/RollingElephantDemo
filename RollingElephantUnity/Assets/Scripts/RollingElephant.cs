using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RollingElephant : MonoBehaviour
{
    DIRECTION current;
    Rigidbody2D rigidBody;
    public float rollingSpeed;

    private bool _jumping;
    private float _jumpTimer;

    void Start()
    {
        current = DIRECTION.RIGHT;
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector3(rollingSpeed, 0f, 0f);
        _jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 speedCalculation = rigidBody.velocity;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            current = DIRECTION.LEFT;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            current = DIRECTION.RIGHT;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!_jumping)
            {
                _jumping = true;
                _jumpTimer = 0.75f;
                rigidBody.gravityScale = 0.0f;
                rigidBody.angularDrag = 0.0f;
                speedCalculation.y = 4.0f;
            }
        }

        if (current == DIRECTION.LEFT)
        {
            if (rigidBody.velocity.x != -rollingSpeed)
            {
                speedCalculation.x = Mathf.Clamp(rigidBody.velocity.x - 15.0f * Time.deltaTime, -rollingSpeed, rollingSpeed);
            }
        }
        else if (current == DIRECTION.RIGHT)
        {
            if (rigidBody.velocity.x != rollingSpeed)
            {
                speedCalculation.x = Mathf.Clamp(rigidBody.velocity.x + 15.0f * Time.deltaTime, -rollingSpeed, rollingSpeed);
            }
        }

        // Check if we need to stop jumping
        if(_jumping)
        {
            _jumpTimer -= Time.deltaTime;
            if (_jumpTimer < 0.0f)
            {
                _jumping = false;
                rigidBody.gravityScale = 1.0f;
                rigidBody.angularDrag = 1.75f;
            }
        }

        rigidBody.velocity = speedCalculation;
    }

}
