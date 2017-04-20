using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Fields
    public float minSpeed;
    public float maxSpeed;

    public float currentSpeed;
    private float x, y, z;
    #endregion

    #region Properties
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
    #endregion
}
