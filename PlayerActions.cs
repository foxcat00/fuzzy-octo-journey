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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4f))

        {
            if(hit.collider.gameObject.GetComponent<Interactible>() == null)
            {
                if (hit.collider.gameObject.GetComponentInParent<Interactible>() != null)
                {
                    hit.collider.gameObject.GetComponentInParent<Interactible>().Interact();
                }
            }
            if (hit.collider.gameObject.GetComponent<Interactible>() != null)
            {
                hit.collider.gameObject.GetComponent<Interactible>().Interact();
            }
        }
    }

    public void OnAttack(InputValue value)
    {
        //do an attack
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 4f, Color.yellow);
        Debug.Log("Attack");
    }
}

