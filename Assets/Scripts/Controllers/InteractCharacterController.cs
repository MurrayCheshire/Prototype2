using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCharacterController : MonoBehaviour
{
    Character character;
    CharacterController2D characterController;
    Rigidbody2D rgdbdy2d;

    [SerializeField] float offsetDistance = 1.0f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    void Awake()
    {
        character = GetComponent<Character>();
        characterController = GetComponent<CharacterController2D>(); 
        rgdbdy2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    void Interact()
    {
        Vector2 position = rgdbdy2d.position + characterController.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(character);
                break;
            }
        }

    }
}
