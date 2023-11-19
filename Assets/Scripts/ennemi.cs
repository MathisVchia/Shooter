using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemi : MonoBehaviour
{

    public GameObject mobs;
    public MovementEtTir player;
    private Transform limitL;
    private Transform limitR;
    private bool direction;

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

        if (transform.position.x <= limitL.position.x)
        {
            mobs.transform.position += Vector3.right * 0.002f;
            direction = false;
        }

        if (transform.position.x >= limitR.position.x)
        {
            mobs.transform.position += Vector3.left * 0.002f;
            direction = true;
        }

        else
        {
            if (direction)
            {
                mobs.transform.position += Vector3.left * 0.002f;
            }
            else
            {
                mobs.transform.position += Vector3.right * 0.002f;
            }
            
        }
    }
}
