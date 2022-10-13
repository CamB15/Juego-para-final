using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_chase : MonoBehaviour
{
    private Transform player_pos;
    private Player_move player;
    private Vector2 moveInput;
    public float speed;
    private float moveX;
    private float moveY;
    private Animator myanim;
    private bool inRange;
    [SerializeField]private GameObject item;

    public shot bullet_model;
    float timer;
    public float cooldown = 1f;
    public Transform shoot_point;
    public Transform pivot_point;
    private float speed_pivot = 10;
    private GameObject clone;


    void Start()
    {
        if (player_pos == null)
        {
            player_pos = GameObject.FindWithTag("Player").transform;
            player = GetComponent<Player_move>();
            myanim = GetComponent<Animator>();
            clone = Instantiate(item, GameObject.FindGameObjectWithTag("Canvas").transform, false);

        }
    }

    void Update()
    {
        if (!inRange)
        {
            Chase();
        }
        else
        {
            Attack();
        }

    }
    void FixedUpdate()
    {
        transform.Translate(moveInput * speed * Time.deltaTime);
    }
    void Chase()
    {
        myanim.SetBool("run", true);
        speed = 2.5f;
        moveX = player_pos.transform.position.x - transform.position.x;
        moveY = player_pos.transform.position.y - transform.position.y;
        myanim.SetFloat("Horizontal", moveX);
        myanim.SetFloat("Vertical", moveY);
        moveInput = new Vector2(moveX, moveY).normalized;
    }
    void Attack()
    {
        myanim.SetBool("run", false);
        moveX = player_pos.transform.position.x - transform.position.x;
        moveY = player_pos.transform.position.y - transform.position.y;
        myanim.SetFloat("Horizontal", moveX);
        myanim.SetFloat("Vertical", moveY);
        speed = 0;

        Vector3 dir = player_pos.position - pivot_point.position;
        pivot_point.up = Vector3.Slerp(pivot_point.up, dir, Time.deltaTime * speed_pivot); //apuntado del enemigo
         if (timer < cooldown)
            {
              timer = timer + 1 * Time.deltaTime;
            }
         else
         {                                                                       //cooldown.
             timer = 0;
             shot MyBullet = GameObject.Instantiate(bullet_model);
             MyBullet.MoveTo(shoot_point.position, shoot_point.up);
         }
    }

    void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collission)
    {
        if (collission.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    
}
