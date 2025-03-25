using UnityEngine;

public class NaoMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotationSpeed = 100.0f;
    private Rigidbody rb;
    private DatabaseManager databaseManager;


    void Start(){
        rb = GetComponent<Rigidbody>();
        databaseManager = DatabaseManager.GetDatabaseManager();
    }

    void Update()
    {
        // float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        // float rotate = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;  // Rotazione

        // // Muove il robot in avanti o indietro
        // Vector3 movement = transform.forward * move;
        // rb.MovePosition(rb.position + movement);

        // // Ruota il robot
        // Quaternion turn = Quaternion.Euler(0f, rotate, 0f);
        // rb.MoveRotation(rb.rotation * turn);
    }
}
