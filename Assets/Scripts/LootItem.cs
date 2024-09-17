using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour
{
    public float money = 0;
    public float hp = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Loot")
        {
            if(other.gameObject.GetComponent<LootInform>().LootTag == "Money")
            {
                switch (other.gameObject.GetComponent<LootInform>().LootName)
                {
                    case "SilverCoin":
                        money += 10;
                        break;
                    case "GoldCoin":
                        money += 50;
                        break;
                    case "SilverBar":
                        money += 100;
                        break;
                    case "GoldBar":
                        money += 1000;
                        break;
                }
            }
            Destroy(other.gameObject);
        }

    }
}
