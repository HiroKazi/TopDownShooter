using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class boundary
{
    public float xMin, xMax, yMin, yMax;
}
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float tilt;
    Vector3 Movement;

    public GameObject shotPrefab;
    public Transform showSpawn;
    public float fireRate;
    float nextFire;

    public boundary boundary;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        Movement.x = Input.GetAxis("Horizontal");
        Movement.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.K))
        {
            nextFire = Time.deltaTime * fireRate; 
            Instantiate(shotPrefab, showSpawn.position, Quaternion.identity);
        }
    }
    void FixedUpdate()
    {
        Vector3 newPosition = rb.position + Movement * speed * Time.fixedDeltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, boundary.xMin, boundary.xMax);
        newPosition.y = Mathf.Clamp(newPosition.y, boundary.yMin, boundary.yMax);

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //rb.velocity = movement * speed;

        rb.MovePosition(newPosition);

        rb.rotation = Quaternion.Euler(0.0f, rb.velocity.x * tilt, 0.0f);
        
    }
}
