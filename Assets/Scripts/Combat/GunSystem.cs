using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    //Gun info
    public int damage;
    public float speed, range, reloadTime, shotInterval;
    public int magSize;
    int bulletsLeft, bulletsUsed;

    //bools
    bool isShooting, shotReady, isReloading;

    //reference points
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask enemyIdentify;

    //VFX
    public GameObject muzFlash, bulletHole;
    public TextMeshProUGUI text;

    private void Awake()
    {
        bulletsLeft = magSize;
        shotReady = true;
    }

    public void Update()
    {
        Gun();

        //TEXT DISPLAY
        text.SetText(bulletsLeft + " / " + magSize);
    }
    private void Gun()
    {
        isShooting = Input.GetKey(KeyCode.Mouse0);

        // Reloading
        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !isShooting)
        {
            Reload();
        }

        //Shooting
        if (shotReady && isShooting && !isReloading && bulletsLeft > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        shotReady = false;

        //ray
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range, enemyIdentify))
        {
            Debug.Log(rayHit.collider.name);

            //enemy must have a TakeDamage function
            if (rayHit.collider.CompareTag("Enemy"))
                rayHit.collider.GetComponent<Enemy>().TakeDamage();
        }

        //vxf ex
        Instantiate(bulletHole, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        Invoke("ShootReset", shotInterval);
    }
    private void ShootReset()
    {
        shotReady = true;
    }
    private void Reload()
    {
        isReloading = true;
        Invoke("ReloadDone", reloadTime);
    }
    private void reloadDone()
    {
        bulletsLeft = magSize;
        isReloading = false;
    }
}
 