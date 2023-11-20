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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        MovementEtTir ennemy = collision.gameObject.GetComponent<MovementEtTir>();
        if (ennemy != null)
        {

            Destroy(collision.gameObject);

        }
    }

}
