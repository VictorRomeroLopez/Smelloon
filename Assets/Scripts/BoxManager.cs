using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public enum BoxType { CHEESE, FISH, MEAT, GARLIC }

    [SerializeField] private Box[] _boxes = new Box[0];

    [SerializeField] private Color _colorRegular;
    [SerializeField] private Color _colorCheese;
    [SerializeField] private Color _colorMeat;
    [SerializeField] private Color _colorFish;
    [SerializeField] private Color _colorGarlic;

    public Box[] Boxes => _boxes;
    public Color RegularColor => _colorRegular;
    public Color CheeseColor => _colorCheese;
    public Color MeatColor => _colorMeat;
    public Color FishColor => _colorFish;
    public Color GarlicColor => _colorGarlic;

    private void OnValidate()
    {
        _boxes = new Box[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            _boxes[i] = transform.GetChild(i).GetComponent<Box>();
    }

}
