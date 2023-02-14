using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float force;

    private Camera mainCam;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        Vector3 mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePosition.x.ToString());
        
        Vector3 aimDirection = mousePosition - transform.position;       
        rb.velocity = new Vector2(aimDirection.x, aimDirection.y).normalized * force;

        Vector3 rotation = transform.position - mousePosition;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
