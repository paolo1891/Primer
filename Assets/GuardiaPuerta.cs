using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaPuerta : MonoBehaviour {
    public GameObject _BalaGuardiaPuerta;
    public float FrecuenciaDisparo = 1f;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Disparo",0,FrecuenciaDisparo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Disparo()
    {
        Instantiate(_BalaGuardiaPuerta, transform.position, transform.rotation);
    }


}
