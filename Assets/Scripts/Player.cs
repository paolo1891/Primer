using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speedX = 0.1f;
    public float speedY = 0.1f;
    public static int Score=0;
    public static int Lives = 3;
    //public float playerSpeed;
    public GameObject ProjectilePreFab;

    // Use this for initialization
    void Start () {
        //transform.position = new Vector3(-6, 5,transform.position.z);
	}

    // Update is called once per frame
    void Update()
    {
        //float askToMove = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        //transform.Translate(Vector3.right * askToMove);
        ////wrap
        //if (transform.position.x <= -10.3f)
        //{
        //    transform.position = new Vector3(10.2f, transform.position.y, transform.position.z);
        //}
        //else if (transform.position.x >= 10.3f)
        //{
        //    transform.position = new Vector3(-10.2f, transform.position.y, transform.position.z);
        //}
        Movimiento();
        Disparar();
        
    }

    void Movimiento()
    {
        float moveX = 0;
        float moveY = 0;

        //movimiento WASD

        bool keyWPressed = Input.GetKey(KeyCode.W);
        if (keyWPressed)
        {
            moveY = speedY;
        }

        bool keyAPressed = Input.GetKey(KeyCode.A);
        if (keyAPressed)
        {
            moveX = -speedX;
        }

        bool keyDPressed = Input.GetKey(KeyCode.D);
        if (keyDPressed)
        {
            moveX = speedX;
        }

        bool keySPressed = Input.GetKey(KeyCode.S);
        if (keySPressed)
        {
            moveY = -speedY;

        }



        //al presionar E se duplicara la velocidad
        bool keyLeftShiftPressed = Input.GetKey(KeyCode.LeftShift);

        if (keyLeftShiftPressed)
        {
            moveX *= 2;
            moveY *= 2;
        }

        //convierte la velocidad por frames a velocidad por segundo
        transform.Translate(moveX * Time.deltaTime, moveY * Time.deltaTime, 0);
    }

    void Disparar()
    {
        if (Input.GetKeyDown("space"))
        {
            //fire projectile
            Vector3 position = new Vector3(transform.position.x, transform.position.y ,0);
            Debug.Log(position.x + "," + position.y + "," + position.z);
            Instantiate(ProjectilePreFab, position, Quaternion.identity);
        }
    }

    public void morir()
    {
        Destroy(this.gameObject);
    }

    void OnGUI()
    {
        buildGUI();
    }
    void buildGUI()
    {
        GUI.contentColor = Color.blue;
        GUI.Label(new Rect(0, 0, 120, 240), "Score=" + Player.Score.ToString());
        GUI.Label(new Rect(60, 0, 120, 240), "Lives=" + Player.Lives.ToString());
    }
}
