using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchButton : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyUp(KeyCode.E))
		{
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 15, out RaycastHit hit, 20f))
			{
				Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
				Debug.Log("Did Hit");
				print(hit.transform);
				hit.transform.GetComponent<LightSwitchButton2>().DewIt();
			}
			else
			{
				Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 15, Color.white);
				Debug.Log("Did not Hit");
			}
		}
	}
}
