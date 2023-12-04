using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantChaseOperation : MonoBehaviour
{
    public GameObject Wall;

    public float rotationSpeed = 5f;
    public float moveSpeed = 2f;

    private bool isRotation = false;
    private bool isFalling = false;
    private bool isRolling = false;

    public Vector3 forceDirection;
    public float forceMagnitude = 10.0f;

    private Rigidbody plantRigidbody;

    private void Start()
    {
        plantRigidbody = GetComponent<Rigidbody>();

        plantRigidbody.useGravity = false;
        plantRigidbody.isKinematic = true;

    }
    private void OnCollisionEnter(Collision collision)
    {
        string otherTag = collision.transform.tag;

        if (otherTag.Contains("Parts"))
        {
            isRotation = true;
        }
        if (collision.gameObject.CompareTag("ChaseRoad"))
        {
            isFalling = false;
            isRolling = true;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player HP --");
        }
    }

    private void Update()
    {
        if(isRotation)
        {
            PlantRotate();
        }

        if(isFalling)
        {
            PlantFall();
        }

        if (isRolling)
        {
            PlantRoll();
        }
    }

    
    private void PlantRotate()
    {
        float zRotation = transform.eulerAngles.z + rotationSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);
        if (zRotation > 90)
        {
            plantRigidbody.useGravity = true;
            plantRigidbody.isKinematic = false;
            isRotation = false;
            isFalling = true;
        }

        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void PlantFall()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void PlantRoll()
    {

        forceDirection = Wall.transform.position - transform.position;
        forceDirection.y = 0;

        plantRigidbody.AddForce(forceDirection * forceMagnitude);
    }
}
