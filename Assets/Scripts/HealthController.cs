using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
	[SerializeField]
	private int PlayerHealth = 100;
	[SerializeField]
	private BoxCollider DeathTrigger;
	[SerializeField]
	private GameObject LevelStartPoint;
	[SerializeField]
	private GameObject deathBackground;
	[SerializeField]
	private GameObject endBackground;
	[SerializeField]
	private HealthBar healthBar;
	Vector3 LevelStartPointPos;
	Rigidbody rb;
	int triggerCounter = 0;
	bool isTakingDamage;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		if (LevelStartPoint)
		{
			LevelStartPointPos = LevelStartPoint.transform.position;
		}
	}

	// Update is called once per frame
	void Update()
	{
		//print(PlayerHealth);
		if (PlayerHealth <= 0)
		{
			rb.constraints = RigidbodyConstraints.FreezeAll;
			if (Input.GetKey(KeyCode.R))
			{
				Respawn();
			}
			ShowDeathMessage();
		} else if (rb.constraints == RigidbodyConstraints.FreezeAll && PlayerHealth > 0) 
		{
			rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		}
	}

	public void Respawn()
	{
		PlayerHealth = 100;
		transform.position = LevelStartPointPos;
		healthBar.SetHealth(100);
		healthBar.SetHealthValue((int)PlayerHealth, 100);
		endBackground.SetActive(false);
		deathBackground.SetActive(false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<BoxCollider>() == DeathTrigger)
		{
			PlayerHealth = 0;
			healthBar.SetHealth(0);
			healthBar.SetHealthValue((int)PlayerHealth, 100);
			Debug.Log("Ded");
		}
		if (other.CompareTag("Hurtbox"))
		{
			triggerCounter++;
			if (triggerCounter == 1)
			{
				isTakingDamage = true;
				StartCoroutine(TakeDamage());
				StopCoroutine(HealDamage());
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Hurtbox"))
		{
			triggerCounter--;
			if (triggerCounter == 0)
			{
				isTakingDamage = false;
				StopCoroutine(TakeDamage());
				StartCoroutine(HealDamage());
			}
		}
	}
	IEnumerator TakeDamage()
	{
		int seconds = 0;
		while (isTakingDamage == true)
		{
			for (float timer = 0; timer < 1; timer += Time.deltaTime)
				yield return 0;

			PlayerHealth -= 10; 
			healthBar.SetHealth((int)PlayerHealth);
			healthBar.SetHealthValue((int)PlayerHealth, 100);
			seconds++;
			print("Stopped");
		}
	}
	IEnumerator HealDamage()
	{
		int seconds = 0;
		while (isTakingDamage == false)
		{
			for (float timer = 0; timer < 1; timer += Time.deltaTime)
				yield return 0;
			if (PlayerHealth < 100)
			{
				PlayerHealth += 2;
			}
			healthBar.SetHealth((int)PlayerHealth);
			healthBar.SetHealthValue((int)PlayerHealth, 100);
			seconds++;
			print("Stopped");
		}
	}

	public void ShowDeathMessage()
	{
		deathBackground.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
