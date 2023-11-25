using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementEtTir : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;
    public TextMeshProUGUI monUi;

    public AudioSource audioSource;
    public AudioSource spaceSound;

    public float speed = 0.2f;
    public int Score;
    public int Kills;
    public int PV;

    // Start is called before the first frame update
    void Start()
    {
        PV = 3;
        // Initialisation de l'AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Dash");

        spaceSound = GetComponent<AudioSource>();
        spaceSound.clip = Resources.Load<AudioClip>("piouh v2");
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
        if (Input.GetKey(KeyCode.LeftShift)&&Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * (speed*3);
            PlaySound(audioSource);

        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * (speed * 3);
            PlaySound(audioSource);

        }
        if (Score < 5)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bullet, parent.position + Vector3.up * 1.1f, parent.rotation);
                PlaySound(spaceSound);
            }
        }

        if (Score >= 5)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bullet, parent.position + Vector3.up * 2 + Vector3.left * 0.9f, transform.rotation);
                Instantiate(bullet, parent.position + Vector3.up * 2 + Vector3.right*1.1f, transform.rotation);
                PlaySound(spaceSound);
            }
        }

        if (Score >= 10)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bullet, parent.position + Vector3.up * 3, parent.rotation);
                PlaySound(spaceSound);
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
        Kills++;
        Destroy(collision.gameObject);
        monUi.text = "Bonus : " + Score;
    }

    void PlaySound(AudioSource audioSource)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
