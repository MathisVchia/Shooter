using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemi : MonoBehaviour
{

    public GameObject mobs;
    public Player speed;
    private Transform limitL;
    private Transform limitR;

    public ReferenceLibrary referenceLibrary;
    // Start is called before the first frame update
    void Start()
    {
        referenceLibrary = FindObjectOfType<ReferenceLibrary>();
        limitL = referenceLibrary.LimitL;
        limitR = referenceLibrary.LimitR;
    }

    // Update is called once per frame
    void Update()
    {
        mobs.transform.position += Vector3.left * 0.002f;

        if (transform.position.x < limitL.position.x)
        {
            mobs.transform.position += Vector3.right * 0.002f;
        }

        if (transform.position.x > limitR.position.x)
        {
            mobs.transform.position += Vector3.left * 0.002f;
        }
    }
}
