using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectile : MonoBehaviour {
    private float proyectileSpeed=20;
    public GameObject ExplosionPreFab;
    
    private Transform myTransform;
	// Use this for initialization
	void Start () {
        myTransform = transform;
        myTransform.Rotate(0, 0,-90);
    }
	
	// Update is called once per frame
	void Update () {
        float askToMove = proyectileSpeed * Time.deltaTime;
        
        myTransform.Translate(Vector3.up * askToMove);

        if (myTransform.position.x >10.5f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider otherObject)
    {
        Debug.Log("We hit! " + otherObject.name);
        if (otherObject.tag == "Enemy") {
            //Destroy(otherObject.gameObject);
            //otherObject.transform.position = new Vector3(otherObject.transform.position.x,7.0f, otherObject.transform.position.z);
            Enemy enemy=(Enemy)otherObject.gameObject.GetComponent("Enemy");
            //instanciar explosion
            Instantiate(ExplosionPreFab, enemy.transform.position, enemy.transform.rotation);
            enemy.SetPositionAndSpeed();
            Destroy(gameObject);
            //DestroyInm(ExplosionPreFab);
        }
    }
}
