using System.Collections;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    [SerializeField] private float destroyAfterSeconds;

    Renderer ballRenderer;

    bool shouldCountDown;

    void Awake()
    {
        ballRenderer = GetComponent<Renderer>();    
    }

    void Update()
    {
        if (shouldCountDown) {

            destroyAfterSeconds -= Time.deltaTime;

            if(destroyAfterSeconds < 0.01f)
            {
                Destroy(gameObject);
            }
        }    
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            shouldCountDown = true;
        }
    }
}
