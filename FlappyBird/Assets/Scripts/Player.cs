using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float forwardSpeeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            if(deathCooldown <= 0)
            {
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    //restart
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }
    public void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeeed;

        if(isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        float lerpAngle = Mathf.Lerp(transform.rotation.eulerAngles.z, angle, Time.fixedDeltaTime * 5f);
        transform.rotation = Quaternion.Euler(0, 0, lerpAngle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode)
            return;

        if (isDead)
            return;

        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;
    }
}