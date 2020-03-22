using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public enum BoxType { CHEESE, FISH, MEAT, GARLIC, SPECIAL }

    [SerializeField] private List<Box> _boxes;

    [SerializeField] private Color _colorRegular = new Color();
    [SerializeField] private Color _colorCheese = new Color();
    [SerializeField] private Color _colorMeat = new Color();
    [SerializeField] private Color _colorFish = new Color();
    [SerializeField] private Color _colorGarlic = new Color();
    [SerializeField] private Color _colorSpecial = new Color();

    public List<Box> Boxes => _boxes;
    public Color RegularColor => _colorRegular;
    public Color CheeseColor => _colorCheese;
    public Color MeatColor => _colorMeat;
    public Color FishColor => _colorFish;
    public Color GarlicColor => _colorGarlic;
    public Color SpecialColor => _colorSpecial;

    public void RemoveBox(Box _boxToRemove)
    {
        _boxes.Remove(_boxToRemove);
    }

    public void ResetBoxes()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).GetComponent<BoxCollider2D>().enabled)
            {
                transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
                transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
                _boxes.Add(transform.GetChild(i).GetComponent<Box>());
            }
        }
    }

    private void OnValidate()
    {
        _boxes = new List<Box>();

        for (int i = 0; i < transform.childCount; i++)
            _boxes.Add(transform.GetChild(i).GetComponent<Box>());
    }
    
}
