using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMinable : ToolHit
{

    [SerializeField] GameObject pickUpDrop;
    [SerializeField] float spread = 0.7f;
    [SerializeField] Item item;
    [SerializeField] int dropCount = 5;
    [SerializeField] int itemDropInOneCount = 1;
    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount--;
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            
            ItemSpawnManager.instance.SpawnItem(position, item, itemDropInOneCount);
        }

        Destroy(gameObject);
    }
}
