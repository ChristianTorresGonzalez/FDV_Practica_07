using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCola : MonoBehaviour
{
    public ControladorDelegados controlador;

    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == player.tag)
        {
            controlador.SetPlayerPerk("speedCola");
        }
    }
}
