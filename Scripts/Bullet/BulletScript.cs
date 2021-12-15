using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public ControladorDelegados controlador;
    private GameObject player;
    private GameObject pointsCanvas;
    private Rigidbody2D rigidbody;
    private Vector2 bulletOrientation;
    public float bulletSpeed;
    private bool bulletShoot;

    void Start()
    {
        controlador = GameObject.FindWithTag("MainCamera").GetComponent<ControladorDelegados>();
        player = GameObject.FindWithTag("Player");
        pointsCanvas = GameObject.FindWithTag("CanvasPoints");
        rigidbody = GetComponent<Rigidbody2D>();
        bulletSpeed = 5f;
    }

    private void FixedUpdate() {
        if (bulletShoot == true) {
            rigidbody.velocity = bulletOrientation * bulletSpeed;
        }
    }

    public void SetOrientation(Vector2 orientation)
    {
        bulletOrientation = orientation;
    }

    public void SetPosition(Transform playerTransform)
    {
        transform.position = playerTransform.position;
    }

    public void SetVelocity(bool playerMovement)
    {
        if (playerMovement){
            bulletSpeed = 4f;
        } else {
            bulletSpeed = 3f;
        }
    }

    public void ShootBullet()
    {
        bulletShoot = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag != player.tag) && (collision.gameObject != this.gameObject)) {
            GameObject.Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy") {
            controlador.SetPlayerPoints();
        }
    }
}
