using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{

    public static GameManager instance; // singleton instance of the GameManager

    public float score;
    public float highScore;
    public int level;

    private bool levelStart = false; // to check if the level has started
    private bool soupCooking = false; // to check if the soup is cooking
    private bool cheeseCooking = false; // to check if the cheese is cooking
    private float speedUpAmount = 5f; // amount to speed up the cook time
    private float currentSoupTime;
    private float currentCheeseTime;
    private bool soupObserved = false; // to check if the soup has been observed
    private bool cheeseObserved = false;

    public foodData soup; // data for the food items in the game
    public foodData cheese; 

    private List<string> foodItems = new List<string>(); // to store the current food items in the level

    [Header ("FoodPrefabs")]
    public GameObject soupPrefab;
    public GameObject cheesePrefab;

    [Header ("FoodSpawnPoints")]
    public Transform soupSpawnPoint;
    public Transform cheeseSpawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        score = 0;
        highScore = 0;
        level = 1;
        // building the default food items 
        soup.foodName = "Tomato_Soup"; soup.cookTime = 300; soup.stages = 3; soup.currentStage = 1; 
        cheese.foodName = "Cheese"; cheese.cookTime = 200; cheese.stages = 3; cheese.currentStage = 1;
        // add the food items to the dictionary
        foodItems.Add(soup.foodName);
        foodItems.Add(cheese.foodName);

        currentCheeseTime = cheese.cookTime;
        currentSoupTime = soup.cookTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelStart) { soupCooking = true; cheeseCooking = true; soupController(); cheeseController(); }
        Debug.Log("currentSoupTime: " + currentSoupTime + " currentCheeseTime: " + currentCheeseTime);
    }

    // score manager
    public void AddScore(float points)
    {
        score += points;
        if (score > highScore)
        {
            highScore = score;
        }
    }

    // for when the player preses start
    public void startLevel()
    {
        if (!levelStart && level == 1)
        {
            Instantiate (soupPrefab, soupSpawnPoint.position, Quaternion.identity);
            Instantiate (cheesePrefab, cheeseSpawnPoint.position, Quaternion.identity);
            levelStart = true;
        } else
        {
            speedUpAmount += level;
            Instantiate(soupPrefab, soupSpawnPoint.position, Quaternion.identity);
            Instantiate(cheesePrefab, cheeseSpawnPoint.position, Quaternion.identity);
            levelStart = true;
        }
    }
    // controls the soup cooking 
    public void soupController()
    {
        if (soupCooking)
        {
            if (currentSoupTime <= 0 && currentSoupTime > 0.2f)
            {
                Debug.Log("Soup is cooked");
                // ui pop up to say cooked here
                // allow player to quickly press space to take the food off the hob and add points to the score
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    AddScore(10);
                    currentSoupTime = soup.cookTime;
                }
            } else if (currentSoupTime <= 0.2f)
            {
                Debug.Log("Soup is burnt");
                // ui pop up to say burnt here
                // logic for burning the food and taking points off the score
            }
            currentSoupTime -= (soupObserved ? 1f : speedUpAmount) * Time.deltaTime;
            // logic for cooking soup
        }
    }

    // controls the cheese cooking
    public void cheeseController()
    {
        if (cheeseCooking)
        {
            if (currentCheeseTime <= 0 && currentCheeseTime > 0.2f)
            {
                Debug.Log("Cheese is cooked");
                // logic for taking food off the hob and adding points to the score
            }
            else if (currentCheeseTime <= 0.2f)
            {
                Debug.Log("Cheese is burnt");
                // logic for burning the food and taking points off the score
            }
            
            currentCheeseTime -= (cheeseObserved ? 1f : speedUpAmount) * Time.deltaTime;
            // logic for cooking cheese
        }
    }

    //detects food observation
    public void foodObserved(string foodName)
    {
        if (foodName == soup.foodName)
        {
            Debug.Log("Soup observed");
            soupObserved = true;
            cheeseObserved = false;
        } else if (foodName == cheese.foodName)
        {
            Debug.Log("Cheese observed");
            cheeseObserved = true;
            soupObserved = false;
        }
    }

    // for when the player levels up and the next food is added to the currentFoods list (future improvements)
    public void foodBuilder()
    {

    }
}
