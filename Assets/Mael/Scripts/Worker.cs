using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Worker : MonoBehaviour
{
    public Transform maison;
    public Transform target = null;

    private int chargeMax = 5;
    public bool loaded = false;
    
    public float speed = 50f;



    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            chooseTarget(); 
        }
        if (!loaded && Vector3.Distance(transform.position, target.transform.position) < 1 && target!=maison)
        {
            loadFood();
        }
        if (loaded && Vector3.Distance(transform.position, maison.transform.position) < 1)
        {
            unloadFood();
        }
        if (target == null)
        {
            chooseTarget();
        }
        move();
        
    }
    public void chooseTarget()
    {
        float distance = Mathf.Infinity;
        Transform tmp=maison.transform;
        
        foreach(Transform o in AntHill.FoodFound)
        {
            float d = Vector3.Distance(o.transform.position, maison.transform.position);
            if (d<distance)
            {
                distance = d;
                tmp = o;
            }
        }
        
        target = tmp;
        
    }
    public void move()
    {
        
        Vector3 dir;
        if (loaded || target == null)
        {
             dir =  maison.transform.position- transform.position;
        }
        else
        {
             dir = target.transform.position - transform.position;
        }
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }
    public void loadFood()
    {
        Food f = target.GetComponent<Food>();
        if (f.foodRemaining <= chargeMax)
        {
            maison.GetComponent<AntHill>().removeFood(f.GetComponent<Food>());
            f.endOfFood();
            target = null;
        }
        if (f.foodRemaining > 0)
        {
            loaded = true;
            f.foodRemaining -= chargeMax;
            
        }
       
    }

    public void unloadFood()
    {
        AntHill.Food += chargeMax;
        loaded = false;
        Debug.Log(AntHill.Food.ToString());
    }
    
}
