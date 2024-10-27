using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchFirst : MonoBehaviour
{
	[SerializeField]
	private GameObject hurtboxToDisable;
	[SerializeField]
	private GameObject textToDisable;
	[SerializeField]
	private GameObject pressurePlateToHide;
	private bool isHiding = false;
	GameObject[] lights;

	private void Start()
	{
		lights = GameObject.FindGameObjectsWithTag("InitialLight");
	}

	private void Update()
	{
		if (isHiding == true)
		{
			pressurePlateToHide.transform.position = Vector3.MoveTowards(pressurePlateToHide.transform.position, pressurePlateToHide.transform.position - new Vector3(0, 0.1f, 0), 0.1f);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			foreach (GameObject light in lights)
			{
				print(light);
				light.GetComponent<Light>().enabled = true;
			}
			hurtboxToDisable.SetActive(false);
			textToDisable.SetActive(false);
			isHiding = true;
		}
	}
}
