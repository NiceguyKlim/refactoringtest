using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
	private GameObject __player;

	public bool lechit;
    public float speed;
	public GameObject Projectile;
	public float damage;
	

	// Use this for initialization
	void Start () {
		__player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (__player == null)
		{
			__player = GameObject.Find("Player");
		}


		if (__player == null)
		{
			return;
		}
		
		
		transform.position = Vector3.MoveTowards(transform.position, __player.transform.position, speed);
		transform.LookAt(__player.transform.position);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (__player == null)
		{
			__player = GameObject.Find("Player");
		}
		
		if (other.gameObject.tag == (__player.tag))
		{
			if (lechit)
			{
				__player.GetComponent<PLayerController>().Health += damage;
			}
			else
			{
				__player.GetComponent<PLayerController>().Health -= damage;
			}
			Destroy(gameObject);
			
		}
	}

}
