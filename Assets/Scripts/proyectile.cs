using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectile : MonoBehaviour {
    private float proyectileSpeed=20;
    public GameObject ExplosionPreFab;
    public string TargetTag;
    private Transform myTransform;

	// Use this for initialization
	void Start () {
        //sds
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
       // Debug.Log("We hit! " + otherObject.name);
        if (otherObject.tag == TargetTag) {
            if (TargetTag =="Player")
            {
                //Instanciar al jugador, para sacar su funcion de morir para sacarlo de la memoria
                Player player = (Player)otherObject.gameObject.GetComponent("Player");
                Instantiate(ExplosionPreFab, player.transform.position, player.transform.rotation);
                player.morir();
            }
            if (TargetTag == "Enemy")
            {
                //Instanciar al enemigo para crear un nuevo enemigo
                Enemy enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");
                Instantiate(ExplosionPreFab, enemy.transform.position, enemy.transform.rotation);
                Destroy(gameObject);
                Player.Score++;
                enemy.SetPositionAndSpeed();
            }

            Destroy(gameObject);
        }
    }

}
