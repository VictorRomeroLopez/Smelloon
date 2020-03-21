using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private int minIngredientsAsked = 0;
    [SerializeField] private float maxTime = 0;
    [SerializeField] private GameObject canvas;
    [SerializeField] private List<GameObject> stars;  
    private int currentIngredientsPicked = 0;

    private bool ingredientsAskedCompleted = false;
    private bool specialPicked = false;
    private bool scaped = false;
    private bool levelEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale= 1;
        StartCoroutine(LevelTimer());
        SpecialIngredientPicked();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IngredientPicked()
    {
        currentIngredientsPicked++;
        if(minIngredientsAsked == currentIngredientsPicked)
        {
            ingredientsAskedCompleted = true;
        }
    }

    public void SpecialIngredientPicked()
    {
        specialPicked = true;
    }

    public void ScapedAtTime()
    {
        scaped = true;
    }

    public void LevelEnded()
    {
        Time.timeScale = 0;
        canvas.SetActive(true);
        if (scaped) stars[0].SetActive(true);
        if (ingredientsAskedCompleted) stars[1].SetActive(true);
        if (specialPicked) stars[2].SetActive(true);
    }

    IEnumerator LevelTimer()
    {
        yield return new WaitForSeconds(maxTime);
        if(!levelEnded)
            LevelEnded();
    }
    
}
