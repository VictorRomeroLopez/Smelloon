using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public enum BoxType { CHEESE, FISH, MEAT, GARLIC }

    [SerializeField] private List<Box> _boxes;

    [SerializeField] private Color _colorRegular = new Color();
    [SerializeField] private Color _colorCheese = new Color();
    [SerializeField] private Color _colorMeat = new Color();
    [SerializeField] private Color _colorFish = new Color();
    [SerializeField] private Color _colorGarlic = new Color();

    public List<Box> Boxes => _boxes;
    public Color RegularColor => _colorRegular;
    public Color CheeseColor => _colorCheese;
    public Color MeatColor => _colorMeat;
    public Color FishColor => _colorFish;
    public Color GarlicColor => _colorGarlic;

    public void RemoveBox(Box _boxToRemove)
    {
        _boxes.Remove(_boxToRemove);
    }

    private void OnValidate()
    {
        _boxes = new List<Box>();

        for (int i = 0; i < transform.childCount; i++)
            _boxes.Add(transform.GetChild(i).GetComponent<Box>());
    }

}
