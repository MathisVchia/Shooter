using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnnemi : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public GameObject Bonus;
    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.down * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);

    }

}
