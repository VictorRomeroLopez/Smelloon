using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGraber : MonoBehaviour
{
    [SerializeField] private BoxManager _boxManager;
    private List<BoxManager.BoxType> _grabedBoxes = new List<BoxManager.BoxType>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int iterator = GetClosestBox(out float distance);

            if (distance < 1.3f && iterator != -1)
            {
                _grabedBoxes.Add(_boxManager.Boxes[iterator].PickupBox());
            }
        }
    }

    private int GetClosestBox(out float distance)
    {
        int boxToReturn = -1;
        distance = -1;

        for(int i = 0; i < _boxManager.Boxes.Count; i++)
        {

            if (Vector2.Distance(transform.position, _boxManager.Boxes[i].transform.position) < distance || distance == -1)
            {
                boxToReturn = i;
                distance = Vector2.Distance(transform.position, _boxManager.Boxes[i].transform.position);
            }
        }

        return boxToReturn;
    }
}
