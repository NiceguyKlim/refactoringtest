using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
	
	public GameObject bullet1, bullet2;
	public float fireRate;
	private float _lastFire;
	public float Health = 500;

	private void Update()
	{
		
		_lastFire -= Time.deltaTime;
		if (Input.GetButton("Fire1"))
		{
			if (_lastFire <= 0)
			{
				var input = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				var bullet = Instantiate(Random.value > 0.5 ? bullet1 : bullet2);
				bullet.transform.position = transform.position;
				bullet.transform.localRotation = Quaternion.identity;
				
				transform.LookAt(new Vector3(input.x, transform.position.y, input.z));
				bullet.transform.LookAt(new Vector3(input.x, transform.position.y, input.z));
				_lastFire = fireRate;
			}
			
		}
	}
}
