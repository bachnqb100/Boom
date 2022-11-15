using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum Item
    {
        ExtraBomb, 
        BlastRadius,
        SpeedIncrease,
    }

    public Item type;

    private void OnItemPickup(GameObject player)
    {
        switch (type)
        {
            case Item.ExtraBomb:
                player.GetComponent<BombController>().AddBomb();
                break;
            case Item.SpeedIncrease:
                if (player.CompareTag("Player"))
                {
                    player.GetComponent<MovementController>().speed++;
                } else
                {
                    player.GetComponent<Enemy>().SpeedUp();
                }

                break;
            case Item.BlastRadius:
                player.GetComponent<BombController>().explosionRadius++;
                break;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            OnItemPickup(other.gameObject);
        }
    }
}
