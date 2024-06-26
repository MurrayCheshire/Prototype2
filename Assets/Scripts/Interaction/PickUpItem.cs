using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    //[SerializeField] float timeToLeave = 10f;

    public Item item;
    public int count = 1;

    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }
    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickUpDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (distance < 0.1f)
        {
            GameManager.instance.sound.GetComponent<AudioSource>().Play();
            //Statements below should be moved into specified controller rather than being checked here
            if (GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);
                GameManager.instance.inventoryPanel.Show();
                GameManager.instance.toolbarPanel.Show();
            }
            else
            {
                Debug.LogWarning("No inventory container attached to the GameManager.");
            }
            Destroy(gameObject);
            
        }
    }
}
