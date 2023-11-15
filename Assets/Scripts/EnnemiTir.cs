using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiTir : MonoBehaviour
{

    public GameObject bulletEnnemis;
    public Transform parent;

    public float bulletTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= 2.0f)
        {
            Instantiate(bulletEnnemis, parent.position, parent.rotation);
            bulletTimer = 0.0f;
        }
    }
}
