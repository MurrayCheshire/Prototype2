using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(menuName ="Data/Tool Action/Seed Tile")]
public class SeedTile : ToolAction
{
    [SerializeField] List<TileBase> canSeed;
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController)
    {
        TileBase tileToSeed = tileMapReadController.GetTileBaseCrop(gridPosition);

        if (tileMapReadController.cropsManager.Check(gridPosition) == false)
        {
            return false;
        }

        if (canSeed.Contains(tileToSeed) == false)
        {
            return false;
        }

        tileMapReadController.cropsManager.Seed(gridPosition);

        return true;
    }

    public override void OnItemUsed(Item usedItem, ItemContainer inventory)
    {
        inventory.Remove(usedItem);
        GameManager.instance.toolbarPanel.Show();
    }
}
