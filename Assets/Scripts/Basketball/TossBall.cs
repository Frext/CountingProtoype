using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Windows.WebCam;
using Random = System.Random;

[RequireComponent(typeof(Rigidbody))]
public class TossBall : MonoBehaviour
{
    [SerializeField] private float speed;

    [Space] [SerializeField] private Transform forcePosition;

    // This will be initialized by the basketball spawner when a new basketball is spawned.
    public BasketballSpawner basketballSpawner;

    Rigidbody ballRb;

    bool isStill;

    void Awake()
    {
        ballRb = GetComponent<Rigidbody>();

        isStill = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isStill)
        {
            ApplyToss();

            NotifySpawner();

            isStill = false;
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.red,5);
            
            /*
            Vector3 mousePos = Input.mousePosition;
            mousePos.z =  Camera.main.farClipPlane;
            
            Debug.DrawRay(Camera.main.ScreenToWorldPoint(mousePos), Camera.main.ScreenToWorldPoint(mousePos).normalized * (-1 * 50000), Color.red,5);
            */
        }
    }

    private void ApplyToss()
    {
        Vector3 cursorDirection = Camera.main.ScreenPointToRay(Input.mousePosition).direction * (speed * 100);
        
        /*       
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.farClipPlane;

        Vector3 cursorDirection = Camera.main.ScreenToWorldPoint(mousePos).normalized * (speed * 100);
        */
        
        Vector3 force = new Vector3(cursorDirection.x, cursorDirection.y + speed * 100, cursorDirection.z);

        ballRb.AddForceAtPosition(force, forcePosition.position, ForceMode.VelocityChange);
    }

    private void NotifySpawner()
    {
        basketballSpawner.SpawnBasketball();
    }
}