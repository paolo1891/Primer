using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilGuardiaPuerta : MonoBehaviour {

    public float speedX = 3f;
    public float speedY = 0f;
    // crear la explosion
    public GameObject _explosion;
    public string targetTag;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MovimientoProjectilGuardiaPuerta();
	}

    void MovimientoProjectilGuardiaPuerta(){
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(_explosion,other.transform.position,transform.rotation);
        }        
    }

}
