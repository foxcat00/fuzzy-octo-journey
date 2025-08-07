using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract(InputValue value)
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 4f, Color.yellow);
        Debug.Log("Interact");
    }

    public void OnAttack(InputValue value)
    {
        //do an attack
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 4f, Color.yellow);
        Debug.Log("Attack");
    }
}
