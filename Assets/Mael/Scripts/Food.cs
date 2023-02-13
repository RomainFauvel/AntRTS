using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    public int foodRemaining;


    public bool isdead = false;
   public void endOfFood()
    {
        isdead = true;
        Destroy(gameObject);
        return;
    }
    
}
