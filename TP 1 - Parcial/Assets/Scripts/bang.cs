using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bang : MonoBehaviour
{
    private float speed = 5;
    private Life enemy;
    public int damage = 5;

    public void MoveTo(Vector3 position, Vector3 dir)
    {
      transform.position = position;
      transform.up = dir;
    }
    private void Update()
    {
        transform.position = transform.position + transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collission)
    {
         enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Life>();

        if (collission.CompareTag("enemy"))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
