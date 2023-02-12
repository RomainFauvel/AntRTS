using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    public int foodRemaining;

   public void endOfFood()
    {
        Destroy(gameObject);
        return;
    }
    
}
