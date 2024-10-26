using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTriggerController : MonoBehaviour
{
	[SerializeField]
	private GameObject EndScreen;
	[SerializeField]
	private Rigidbody rb;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			rb.constraints = RigidbodyConstraints.FreezeAll;
			WinScreen();
		}
	}
	
	void WinScreen()
	{
		EndScreen.SetActive(true);
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
}
