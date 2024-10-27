using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchPP : MonoBehaviour
{
	[SerializeField]
	private GameObject lightToEnable;
	[SerializeField]
	private GameObject hurtboxToDisable;
	[SerializeField]
	private GameObject pressurePlateToHide;
	private bool isHiding = false;

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
			lightToEnable.SetActive(true);
			hurtboxToDisable.SetActive(false);
			isHiding = true;
		}
	}
}
