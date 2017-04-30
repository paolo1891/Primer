using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Fields
    public float minSpeed;
    public float maxSpeed;
    public GameObject ExplosionPreFab;
    public float currentSpeed;
    private float x, y, z;
    
    #endregion
    

    #region Functions
    // Use this for initialization
    void Start()
    {
        SetPositionAndSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        float toMove = currentSpeed * Time.deltaTime;
        transform.Translate(Vector3.left * toMove);
        if (transform.position.x <= -20)
        {
            SetPositionAndSpeed();
        }
    }

    public void SetPositionAndSpeed()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        x = 10.0f;
        y = Random.Range(-4f, 5f);
        z = 0.0f;
        transform.position = new Vector3(x, y, z);
    }

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "Player")
        {   
            //Instanciar al jugador, para sacar su funcion de morir para sacarlo de la memoria
            Player player = (Player)otherObject.gameObject.GetComponent("Player");
            //instanciar explosion
            Instantiate(ExplosionPreFab, player.transform.position, player.transform.rotation);
            //Destruir objetos
            Destroy(gameObject);
            player.morir();            
        }
    }
    
    #endregion
}
