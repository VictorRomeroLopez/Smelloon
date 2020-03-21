using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmellBarManager : MonoBehaviour
{
    [SerializeField] private BarManager[] _barManagers = new BarManager[0];
    [SerializeField] private int _minSize;
    [SerializeField] private int _maxSize;
    [SerializeField, Range(0,1)] private float[] _barManagerSize = new float[0];

    private void OnValidate()
    {
        if (_barManagers.Length != transform.childCount) {
            _barManagers = new BarManager[transform.childCount];

            for (int i = 0; i < transform.childCount; i++)
                _barManagers[i] = transform.GetChild(i).GetComponent<BarManager>();
        }

        if (_barManagerSize.Length != transform.childCount)
            _barManagerSize = new float[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {
            _barManagers[i].Size = _barManagerSize[i];
            _barManagers[i].MinValue = _minSize;
            _barManagers[i].MaxValue = _maxSize;
            _barManagers[i].UpdateBar();
        }
    }

}
