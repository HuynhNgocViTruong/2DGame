using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject ItemPrefab;
    public List<Loot> lootLists = new List<Loot>();

    #region Drop many item
    private List<Loot> GetDropItems()
    {
        int randomNum = Random.Range(0, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootLists)
        {
            if(randomNum <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            return possibleItems;
        }
        return null;
    }

    public void InstantiateLoots(Vector3 spawnPosition)
    {
        List<Loot> droppedItem = GetDropItems();
        if (droppedItem.Count > 0)
        {
            foreach (Loot item in droppedItem)
            {
                Vector3 randomness = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                GameObject lootGameObject = Instantiate(ItemPrefab, spawnPosition + randomness, Quaternion.identity);
                lootGameObject.GetComponent<SpriteRenderer>().sprite = item.lootSprite;
                lootGameObject.GetComponent<LootInform>().LootTag = item.lootTag;
                lootGameObject.GetComponent<LootInform>().LootName = item.lootName;
            }
        }
    }
    #endregion

    #region Drop 1 item
    private Loot GetDropItem()
    {
        int randomNum = Random.Range(0, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootLists)
        {
            if (randomNum <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            Loot dropItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return dropItem;
        }
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDropItem();
        if(droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(ItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
        }
    }
    #endregion
}
