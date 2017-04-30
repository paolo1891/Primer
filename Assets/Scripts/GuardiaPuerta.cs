using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaPuerta : MonoBehaviour {
    public GameObject _BalaGuardiaPuerta;
    public float FrecuenciaDisparo = 1f;
    // instancia el objeto vacio
    public Transform _spawn;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Disparo",0,FrecuenciaDisparo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Disparo()
    {
        // Permite cambiar la bala a nuvea direccion dependiendo del objeto vacio.    
        Instantiate(_BalaGuardiaPuerta, _spawn.position, _spawn.rotation);
    }


}
