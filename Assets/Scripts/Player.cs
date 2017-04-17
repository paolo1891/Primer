using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float playerSpeed;
    public GameObject ProjectilePreFab;

    // Use this for initialization
    void Start () {
        //transform.position = new Vector3(-6, 5,transform.position.z);
	}

    // Update is called once per frame
    void Update()
    {
        float askToMove = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * askToMove);
        //wrap
        if (transform.position.x <= -10.3f)
        {
            transform.position = new Vector3(10.2f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 10.3f)
        {
            transform.position = new Vector3(-10.2f, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown("space"))
        {
            //fire projectile
            Vector3 position = new Vector3(transform.position.x,transform.position.y+(transform.localPosition.y/2));
            Instantiate(ProjectilePreFab,position,Quaternion.identity);
        }

       
    }
}
