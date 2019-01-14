using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BULLET : MonoBehaviour
{

	public float Speed;
	// Use this for initialization
	void Start () {
		Invoke("Kill", 2f);
	}

	private void Kill()
	{
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, Speed);
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.name.Contains("Mob"))
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
			FindObjectOfType<Game>().currentScore += 10;
		}
	}
}
