using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rgdbdy2d;
    ToolbarController toolbarController;
    Animator animator;

    [SerializeField] float offsetDistance = 1.0f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] Item seed;
    
    
    Vector3Int selectedTilePosition;
    bool selectable;

    void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rgdbdy2d = GetComponent<Rigidbody2D>();
        toolbarController = GetComponent<ToolbarController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0))
        {
            if (UseToolWorld() == true) return;
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
    }

    private void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }

    private void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
    }

    private bool UseToolWorld()
    {
        Vector2 position = rgdbdy2d.position + character.lastMotionVector * offsetDistance;
        
        Item item = toolbarController.GetItem;
        if (item == null) return false;
        if (item.onAction == null) return false;

        animator.SetTrigger("act");
        bool complete = item.onAction.OnApply(position);

        if (complete == true)
            {
                if (item.onItemUsed != null)
                {
                    item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }
            }

        return complete;

    }

    private void UseToolGrid()
    {
        if (selectable == true)
        {
            Item item = toolbarController.GetItem;
            if (item == null) { return; }
            if (item.onTileMapAction == null) { return; }

            animator.SetTrigger("act");

            bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tileMapReadController);

            if (complete == true)
            {
                if (item.onItemUsed != null)
                {
                    item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }
            }
        }
    }
}
