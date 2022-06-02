using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endlessScroll : MonoBehaviour
{
    //direccion del obstaculo / velocidad
    public float gameVelocity;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.transform.position += new Vector3(-gameVelocity, 0, 0)*Time.deltaTime;
    }

    //creamos un evento para cuando el enemy salga del game area (el game area lo creamos en la escena y le agregamos un isTriger)
    private void OnTriggerExit(Collider gameArea)
    {
        //al salir del game area lo regresa hasta el inicio (derecha del game area)
        transform.position += Vector3.right * (gameArea.bounds.size.x + GetComponent<BoxCollider>().size.x);
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
