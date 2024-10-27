using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchButton2 : MonoBehaviour
{
	[SerializeField]
	private GameObject lightToEnable;
	[SerializeField]
	private GameObject hurtboxToDisable;
	[SerializeField]
	private GameObject switchToHide;
	private bool isHiding = false;

	private void Update()
	{
		if (isHiding == true)
		{
			if (switchToHide.CompareTag("Switch2"))
			{
				switchToHide.transform.position = Vector3.MoveTowards(switchToHide.transform.position, switchToHide.transform.position - new Vector3(0.2f, 0, 0), 0.1f);
			} else if (switchToHide.CompareTag("Switch"))
			{
				switchToHide.transform.position = Vector3.MoveTowards(switchToHide.transform.position, switchToHide.transform.position + new Vector3(0.2f, 0, 0), 0.1f);
			}
			
		}
	}

	public void DewIt()
	{
		lightToEnable.SetActive(true);
		hurtboxToDisable.SetActive(false);
		isHiding = true;
	}
}
