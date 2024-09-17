using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamePopUpGenerator : MonoBehaviour
{
    public static DamePopUpGenerator current;
    public GameObject prefab;

    private void Awake()
    {
        current = this;
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.F10))
        {
            CreatePopUp(transform.position, Random.Range(0, 1000).ToString(), Color.red);
        }*/
    }

    public void CreatePopUp(Vector3 position, string text, Color color)
    {
        var popup = Instantiate(prefab, position, Quaternion.identity);
        var temp = popup.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        temp.text = text;
        temp.faceColor = color;

        //Destroy Timer
        Destroy(popup, 1f);
    }
}
