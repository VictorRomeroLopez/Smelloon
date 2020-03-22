using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<BoxManager.BoxType> ingredientList;
    [SerializeField] private int minIngredientsAsked = 0;
    [SerializeField] private float maxTime = 0;
    [SerializeField] private GameObject canvas;
    [SerializeField] private List<GameObject> stars;
    [SerializeField] private Text ingredientText;
    [SerializeField] private Text timeText;
    private int currentIngredientsPicked = 0;

    public BoxManager.BoxType nextIngredient;

    private bool ingredientsAskedCompleted = false;
    private bool specialPicked = false;
    private bool scaped = false;
    private bool levelEnded = false;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale= 1;

        NewIngredientAsked();

        timer = maxTime;

        StartCoroutine(LevelTimer());

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeText();
    }

    public void IngredientPicked()
    {
        currentIngredientsPicked++;
        if(minIngredientsAsked == currentIngredientsPicked)
        {
            ingredientsAskedCompleted = true;
        }

        if (nextIngredient == BoxManager.BoxType.SPECIAL)
            specialPicked = true;

        for(int i=0; i<ingredientList.Count;i++)
        {
            if (ingredientList[i] == nextIngredient)
            {
                ingredientList.RemoveAt(i);
                break;
            }
        }

        NewIngredientAsked();
    }

    private void NewIngredientAsked()
    {
        nextIngredient = ingredientList[(int)Random.Range(0, ingredientList.Count - 0.1f)];
        ingredientText.text = "Ingredient Asked: " + nextIngredient;
    }
    
    public void ScapedAtTime()
    {
        if(ingredientsAskedCompleted)
            scaped = true;

        LevelEnded();
    }

    public void LevelEnded()
    {
        Time.timeScale = 0;
        canvas.SetActive(true);
        if (scaped) stars[0].SetActive(true);
        if (ingredientsAskedCompleted) stars[1].SetActive(true);
        if (specialPicked) stars[2].SetActive(true);
    }

    private void UpdateTimeText()
    {
        timer -= Time.deltaTime;
        if (timer < 0) timer = 0;

        timeText.text = "Time Left: "+ (int)timer;
    }

    IEnumerator LevelTimer()
    {
        yield return new WaitForSeconds(maxTime);
        if(!levelEnded)
            LevelEnded();
    }
    
}
