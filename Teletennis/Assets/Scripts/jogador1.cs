using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogador1 : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)){
            rb.velocity = new Vector3(-speed, 0,0);//Anda para esquerda
        } else if (Input.GetKey(KeyCode.D)){
            rb.velocity = new Vector3(speed, 0,0);//Anda para direita
        } else {
            rb.velocity = new Vector3(0,0,0);
        }
    }
}