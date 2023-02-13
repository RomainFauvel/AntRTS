using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntExplorer : MonoBehaviour
{
    public Transform maison;

    public string foodTag = "Food";

    public float speed = 70f;
    public float visionRange = 30f;

    public void Update()
    {
        foodSpotted();
    }
    public void foodSpotted()
    {
        List<Transform> rmEtoile = new List<Transform>();
        foreach(Transform o in AntHill.FoodNotFound)
        {
            float d = Vector3.Distance(o.transform.position, transform.position);
            if (d<visionRange)
            {
                AntHill.FoodFound.Add(o);
                rmEtoile.Add(o);
                Debug.Log("Food has been Found");
            }
        }
        foreach( Transform f in rmEtoile)
        {
            AntHill.FoodNotFound.Remove(f);
        }
    }

}
