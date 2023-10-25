using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public GameObject Bonus;
    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        if (Score < 1)
        {
            monRigidBody.velocity = Vector3.up * speed;
        }

        if (Score >= 1)
        {
            monRigidBody.velocity = Vector3.up * speed * 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        Instantiate(Bonus, collision.transform.position, collision.transform.rotation);
    }

}
