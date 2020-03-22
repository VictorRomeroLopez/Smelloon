using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<BoxManager.BoxType> ingredientList;
    [SerializeField] private int minIngredientsAsked = 0;
    [SerializeField] private float maxTime = 0;
    [SerializeField] private GameObject _panel;
    [SerializeField] private List<GameObject> stars;
    [SerializeField] private Text ingredientText;
    [SerializeField] private Text timeText;
    [SerializeField] private PlayerManager _playerManager;

    private int currentIngredientsPicked = 0;

    public BoxManager.BoxType nextIngredient;

    private bool ingredientsAskedCompleted = false;
    private bool specialPicked = false;
    private bool scaped = false;
    public float timer = 0;

    void Start()
    {
        Time.timeScale = 0;

        NewIngredientAsked();

        timer = maxTime;

        StartCoroutine(LevelTimer());
    }

    void Update()
    {
        UpdateTimeText();
    }

    public void IngredientPicked(bool specialFound = false)
    {
        currentIngredientsPicked++;
        if(minIngredientsAsked == currentIngredientsPicked)
        {
            ingredientsAskedCompleted = true;
        }
        
        for(int i=0; i<ingredientList.Count;i++)
        {
            if (ingredientList[i] == nextIngredient)
            {
                ingredientList.RemoveAt(i);
                break;
            }
        }

        if(!specialFound)
            NewIngredientAsked();
        else
        {
            specialPicked = true;
        }
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
        _panel.SetActive(true);
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

    public IEnumerator LevelTimer()
    {
        yield return new WaitForSeconds(maxTime);
        LevelEnded();
    }

    public void OnReset()
    {
        NewIngredientAsked();
        timer = maxTime;
        StartCoroutine(LevelTimer());

        ingredientsAskedCompleted = false;
        specialPicked = false;
        scaped = false;
        currentIngredientsPicked = 0;

        foreach(GameObject star in stars)
            star.SetActive(false);

        _playerManager.OnReset();
    }

}
