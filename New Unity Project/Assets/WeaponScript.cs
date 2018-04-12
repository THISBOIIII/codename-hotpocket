using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
	public float fireRate = 0;
	public float damage = 10;
	public LayerMask whatToHit;

	Transform firePoint;

	void Awake(){
		firePoint = transform.Find ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("Couldn't find fire point");
		}
	}
			
	void Update () {
		if(Input.GetButtonDown ("Fire1")){
			Shoot ();
	}
}

	void Shoot (){
		Debug.Log ("Shooting");
		Vector2 mousePosition = new Vector2 (
			Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
			Camera.main.ScreenToWorldPoint(Input.mousePosition).y

		);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
		Debug.DrawLine (firePointPosition, (mousePosition - firePointPosition) * 100, Color.green);
		if (hit.collider != null){
			Debug.DrawLine (firePointPosition, hit.point, Color.blue);
			Debug.Log ("We hit" + hit.collider.name + "and did" + damage + "damage.");
		}
	}
}