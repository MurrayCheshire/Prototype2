using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public GameObject sound;
    public ItemContainer inventoryContainer;
    public InventoryPanel inventoryPanel;
    public ItemToolbarPanel toolbarPanel;
    public ItemDragAndDropController dragAndDropController;
}
