using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class AntHill : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public static List<Transform> FoodFound;

    public Transform Food1;

    public static int Food;

    public string foodTag = "Food";
    
    void Start()
    {
        FoodFound = new List<Transform>();
        GameObject[] food = GameObject.FindGameObjectsWithTag(foodTag);
        foreach(GameObject f in food)
        {
            FoodFound.Add(f.transform);
        }
        
        
        Food = 0; ;

    }

// Update is called once per frame
void Update()
    {
        
    }
    public void removeFood(Food f)
    {
        FoodFound.Remove(f.transform);
    }
}
