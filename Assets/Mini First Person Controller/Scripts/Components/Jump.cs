using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;
    public float jumpStrength = 2;
    public event System.Action Jumped;
    Collider coll;
	public PhysicMaterial slipperyMaterial;
	public PhysicMaterial baseMaterial;

	[SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;


    void Reset()
    {
        // Try to get groundCheck.
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        // Get rigidbody.
        rigidbody = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    void LateUpdate()
    {
        if (groundCheck.isGrounded == false)
        {
            coll.material = slipperyMaterial;
        } else
        {
            coll.material = baseMaterial;
        }
        // Jump when the Jump button is pressed and we are on the ground.
        if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded))
        {
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
        }
    }
}
