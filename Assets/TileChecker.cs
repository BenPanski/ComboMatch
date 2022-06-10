using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileChecker : MonoBehaviour
{
    Tile tile;
    Button _butt;
    private void Start()
    {
        tile = GetComponent<Tile>();
        _butt = GetComponent<Button>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Button")
        {
            if (tile.Layer < collision.GetComponent<Tile>().Layer)
            {
                _butt.interactable = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
                _butt.interactable = true;
    }

}
