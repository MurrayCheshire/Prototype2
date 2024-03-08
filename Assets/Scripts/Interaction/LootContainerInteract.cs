using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    [SerializeField] GameObject openChest;
    [SerializeField] GameObject closedChest;
    [SerializeField] bool isOpen;
    public override void Interact(Character character)
    {
        if (isOpen == false)
        {
            isOpen = true;
            closedChest.SetActive(false);
            openChest.SetActive(true);

        }
        else
        {
            isOpen = false;
            closedChest.SetActive(true);
            openChest.SetActive(false);
        }
    }
}
