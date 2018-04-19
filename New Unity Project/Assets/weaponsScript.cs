using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponsScript : MonoBehaviour {

    public float fireRate = 0;
    public float damage = 10;
    public LayerMask whatToHit;
    public Transform BulletTrailPrefab;

    Transform firePoint;

    // Use this for initialization
    void Awake()
    {
        firePoint = transform.FindChild("firePoint");
        if (firePoint == null) {
            Debug.LogError("Couldn't find the fire point");
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot() {
        Debug.Log("Shooting!");

        Vector2 mousePosition = new Vector2(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y
        );
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
        Effect(Quaternion.FromToRotation(Vector3.right, mousePosition - firePointPosition));
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.red);

        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.yellow);
            Debug.Log("We hit " + hit.collider.name + " and did " + damage + " damage.");
        }
        
           

    }

    void Effect(Quaternion rotation)
    {

        Instantiate(BulletTrailPrefab, firePoint.position, rotation);
    }
}
 