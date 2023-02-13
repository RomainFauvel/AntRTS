using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class AntHill : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public static List<Transform> FoodFound;
    public static List<Transform> FoodNotFound;

    public Transform Food1;

    public static int Food;

    public string foodTag = "Food";

    public float rangeOfVision = 30f;
    
    void Start()
    {
        FoodFound = new List<Transform>();
        FoodNotFound = new List<Transform>();
        GameObject[] food = GameObject.FindGameObjectsWithTag(foodTag);
        foreach(GameObject f in food)
        {
            float d = Vector3.Distance(f.transform.position, transform.position);
            if (d < rangeOfVision)
            {
                FoodFound.Add(f.transform);
            }
            else
            {
                FoodNotFound.Add(f.transform);
            }
        }
        
        
        Food = 0; ;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeOfVision);
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
