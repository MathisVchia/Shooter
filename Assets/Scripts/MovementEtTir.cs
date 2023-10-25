using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;
    public TextMeshProUGUI monUi;

    public float speed = 0.2f;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left*speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right*speed;
        }
        if (Score < 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bullet, parent.position + Vector3.up * 1.1f, parent.rotation);
            }
        }

        if (Score >= 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bullet, parent.position + Vector3.up * 2 + Vector3.left * 0.9f, parent.rotation);
                Instantiate(bullet, parent.position + Vector3.up * 2 + Vector3.right*1.1f, parent.rotation);
            }
        }

        if (transform.position.x < limitL.position.x)
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Score++;
        Destroy(collision.gameObject);
        monUi.text = "J'ai " + Score + " de bonus";
    }
}
