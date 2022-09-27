using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    [SerializeField] float speed = 3;
    private Rigidbody2D myrig;
    private Animator myanim;
    private Vector2 moveInput;
    
    private void Start()
    {
        myrig = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        myanim.SetFloat("horizontal", moveX);
        myanim.SetFloat("vertical", moveY);
        myanim.SetFloat("speed", moveInput.sqrMagnitude);

    }
    private void FixedUpdate()
    {
        myrig.MovePosition(myrig.position + moveInput * speed * Time.fixedDeltaTime);
        
    }
}
