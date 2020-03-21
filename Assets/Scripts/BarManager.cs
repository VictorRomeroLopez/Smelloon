using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    private Image _barImage;

    public float Size { get; set; }
    public int MinValue { get; set; }
    public int MaxValue { get; set; }

    public void UpdateBar()
    {
        float valueBar = MinValue;

        if (MaxValue * Size > MinValue)
        {
            valueBar = MaxValue * Size;
        }

        _barImage.rectTransform.sizeDelta = new Vector2(25, valueBar);
    }

    private void OnValidate()
    {
        _barImage = GetComponent<Image>();
    }
}
