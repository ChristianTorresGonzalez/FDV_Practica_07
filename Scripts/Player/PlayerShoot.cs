using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public ControladorDelegados controlador;
    private GameObject ammoCanvas;
    public GameObject reloadCanvas;
    private GameObject playerPrefab;
    public GameObject bulletPrefab;
    public Weapon currentWeapon;
    public float shootDelay;
    private float lastShoot;
    public bool isReloading;

    void Start()
    {
        playerPrefab = GameObject.FindWithTag("Player");
        ammoCanvas = GameObject.FindWithTag("CanvasAmmo");
        reloadCanvas = GameObject.FindWithTag("ReloadBar");
        
        reloadCanvas.GetComponent<CanvasReloadWeapon>().InitializeReload();
        currentWeapon.InitializeWeapon();
        
        SetCanvasAmmo(currentWeapon.GetCurrentWeaponAmmo(), currentWeapon.GetTotalWeaponAmmo());

        shootDelay = 0.25f;
    }

    void OnEnable()
    {
        controlador.ActivePlayerWeapon += ChangeWeapon;
    }

    void OnDeseable()
    {
        controlador.ActivePlayerWeapon -= ChangeWeapon;
    }

    void Update()
    {
        if (GetComponent<PlayerLife>().GetPlayerAlive()) {
            if (Input.GetMouseButtonDown(0) && Time.time > lastShoot + shootDelay) {
                if (currentWeapon.GetCurrentWeaponAmmo() > 0) {
                    lastShoot = Time.time;

                    ShootBullet();

                    if (playerPrefab.GetComponent<PlayerPerks>().GetDoubleTap()) {
                        Invoke("ShootBullet", 0.1f);
                    }
                    
                    currentWeapon.ShootWeapon();

                    SetCanvasAmmo(currentWeapon.GetCurrentWeaponAmmo(), currentWeapon.GetTotalWeaponAmmo());
                } else {
                    ammoCanvas.GetComponent<CanvasAmmoSystem>().SetNoAmmo(currentWeapon.GetCurrentWeaponAmmo(), currentWeapon.GetTotalWeaponAmmo());
                }
            }

            if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentWeapon.GetCurrentWeaponAmmo() != currentWeapon.GetWeaponAmmoMagazine()) {
                isReloading = true;
                StartCoroutine(ReloadWeapon());
            }
        }
    }

    IEnumerator ReloadWeapon()
    {
        int rTime = currentWeapon.GetReloadTime();

        if (playerPrefab.GetComponent<PlayerPerks>().GetSpeedCola()) {
            rTime /= 3;
        }

        reloadCanvas.GetComponent<CanvasReloadWeapon>().ReloadWeapon(rTime);

        yield return new WaitForSeconds(rTime);

        currentWeapon.ReloadWeapon();

        SetCanvasAmmo(currentWeapon.GetCurrentWeaponAmmo(), currentWeapon.GetTotalWeaponAmmo());
        isReloading = false;
    }

    public void ChangeWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
    }

    private void ShootBullet()
    {
        Vector3 bulletDirection = Vector3.zero;
        Vector2 playerOrientation = playerPrefab.GetComponent<PlayerController>().GetOrientation();

        if (playerOrientation.x == -1) {
            bulletDirection.x = -0.25f;
        } else if (playerOrientation.x == 1) {
            bulletDirection.x = 0.25f;
        }

        if (playerOrientation.y == -1) {
            bulletDirection.y = -0.45f;
        } else if (playerOrientation.y == 1) {
            bulletDirection.y = 0.45f;
        }
        
        GameObject bullet = Instantiate(currentWeapon.GetBulletPrefab(), playerPrefab.transform.position + bulletDirection, Quaternion.identity);

        bullet.GetComponent<BulletScript>().SetOrientation(playerPrefab.GetComponent<PlayerController>().GetOrientation());
        bullet.GetComponent<BulletScript>().ShootBullet();
    }

    private void SetCanvasAmmo(int currentAmmo, int totalAmmo)
    {
        ammoCanvas.GetComponent<CanvasAmmoSystem>().SetAmmo(currentAmmo, totalAmmo);
    }
}
