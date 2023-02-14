using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject fireObject;
    [SerializeField]
    private float timerBetweenFiring;

    private Camera mainCam;
    private float timer;
    private bool isWeaponReady;

    private void Start()
    {
        isWeaponReady = true;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        //HandleAiming();
        HandleShooting();
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = mousePosition - transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        firePoint.eulerAngles = new Vector3(0, 0, angle);
    }

    private void HandleShooting()
    {
        if (!isWeaponReady)
        {
            timer += Time.deltaTime;
            if (timer > timerBetweenFiring)
            {
                isWeaponReady = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && isWeaponReady)
        {
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();

            // Creates the bullet locally
            GameObject bullet = (GameObject)Instantiate(
                                    fireObject,
                                    transform.position + (Vector3)(direction * 0.5f),
                                    Quaternion.identity);

            // Adds velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 5;
 
        }
    }
}
