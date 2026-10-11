using UnityEngine;

[CreateAssetMenu(fileName = "foodData", menuName = "Scriptable Objects/foodData")]
public class foodData : ScriptableObject
{
    public string foodName;
    public float cookTime;
    public int stages;
    public int currentStage;

    public void updateSprite()
    {
        switch (cookTime)
        {
            case < 3:
                // raw
                currentStage = 1;
                break;
            case > 3 and < 6:
                // cooked
                currentStage = 2;
                break;
            case > 6:
                // burnt
                currentStage = 3;
                break;
        }
    }
}
