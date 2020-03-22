using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmellProximityDetector : MonoBehaviour
{
    private const float MAX_SMELL_DISTANCE = 10f;

    [SerializeField] private BoxManager _boxManager;
    [SerializeField] private SmellBarManager _barManager;
    
    void Update()
    {
        _barManager.Bar[0].Size = 1 - GetDistanceToBox(BoxManager.BoxType.CHEESE) / MAX_SMELL_DISTANCE;
        _barManager.Bar[1].Size = 1 - GetDistanceToBox(BoxManager.BoxType.MEAT) / MAX_SMELL_DISTANCE;
        _barManager.Bar[2].Size = 1 - GetDistanceToBox(BoxManager.BoxType.FISH) / MAX_SMELL_DISTANCE;
        _barManager.Bar[3].Size = 1 - GetDistanceToBox(BoxManager.BoxType.GARLIC) / MAX_SMELL_DISTANCE;

        for( int i = 0; i < _barManager.Bar.Length; i++ )
        {
            _barManager.Bar[i].UpdateBar();
        }
    }

    private float GetDistanceToBox(BoxManager.BoxType _boxType)
    {
        float distance = -1;

        foreach(Box box in _boxManager.Boxes)
        {
            if(box.Type == _boxType && (Vector2.Distance(transform.position, box.transform.position) < distance || distance == -1))
            {
                distance = Vector2.Distance(transform.position, box.transform.position);
            }
        }
        
        return distance < 0 ? MAX_SMELL_DISTANCE : distance > MAX_SMELL_DISTANCE ? MAX_SMELL_DISTANCE : distance;
    }
}
