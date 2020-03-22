using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    [SerializeField] private BoxManager.BoxType _boxType;

    public BoxManager.BoxType Type => _boxType;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = GetComponentInParent<BoxManager>().RegularColor;
    }

    private void OnValidate()
    {
        Color setColor = new Color();

        try
        {
            switch (_boxType)
            {
                case BoxManager.BoxType.MEAT:
                    setColor = GetComponentInParent<BoxManager>().MeatColor;
                    break;
                case BoxManager.BoxType.CHEESE:
                    setColor = GetComponentInParent<BoxManager>().CheeseColor;
                    break;
                case BoxManager.BoxType.FISH:
                    setColor = GetComponentInParent<BoxManager>().FishColor;
                    break;
                case BoxManager.BoxType.GARLIC:
                    setColor = GetComponentInParent<BoxManager>().GarlicColor;
                    break;
                default:
                    setColor = GetComponentInParent<BoxManager>().CheeseColor;
                    break;
            }
        }
        catch
        {

        }

        GetComponent<SpriteRenderer>().color = setColor;
    }

    public BoxManager.BoxType PickupBox()
    {
        GetComponentInParent<BoxManager>().RemoveBox(this);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        return _boxType;
    }
}