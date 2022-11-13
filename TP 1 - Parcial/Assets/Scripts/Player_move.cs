using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player_move : MonoBehaviour
{
    [SerializeField] float speed = 3;
    private Rigidbody2D myrig;
    private Animator myanim;
    public Vector2 moveInput;
    public float moveX;
    public float moveY;

    public Transform shoot_point;
    public Transform pivot_point;
    public float timer;
    public float cooldown = 1.5f;
    private float speed_bullet = 15;
    public bang bullet;
    private bool flipflop = true;

    public AudioClip walk;
    AudioSource source;
    public AudioMixerGroup mixer;

    private void Start()
    {
        myrig = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
        source = Sound_Manager.instance.CreateASource(walk ,mixer, false);
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        myanim.SetFloat("horizontal", moveX);
        myanim.SetFloat("vertical", moveY);
        myanim.SetFloat("speed", moveInput.sqrMagnitude);

        pivot_point.up = Vector3.Slerp(pivot_point.up, moveInput, Time.deltaTime * speed_bullet);

        if (flipflop == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                bang MyBullet = GameObject.Instantiate(bullet);
                MyBullet.MoveTo(shoot_point.position, shoot_point.up);
                flipflop = !flipflop;
            }

        }
        else
        {
            if (timer < cooldown)
            {
                timer = timer + 1 * Time.deltaTime;
            }
            else
            {
                timer = 0;
                flipflop = !flipflop;
            }
        }
        
        if (myrig.velocity.magnitude > 0.1)
        {
            source.Play();
        }
        else
        {

        }
    }
    private void FixedUpdate()
    {
        myrig.MovePosition(myrig.position + moveInput * speed * Time.fixedDeltaTime);
        
    }
}
