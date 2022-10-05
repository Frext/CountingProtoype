using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallDown : MonoBehaviour
{
    [SerializeField] private float gravity;

    Rigidbody ballRb;

    bool isInAir;

    void Awake()
    {
        ballRb = GetComponent<Rigidbody>();

        isInAir = true;
    }

    void FixedUpdate()
    {
        if (isInAir)
        {
            ballRb.AddForce(Vector3.up * gravity * 20, ForceMode.Acceleration);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isInAir = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isInAir = true;
        }
    }
}
