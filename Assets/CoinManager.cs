using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// static class to hold global variables, etc.
static class Globals
{
    // global int
    public static int counter;

}

    public class CoinManager : MonoBehaviour
{



    public void addCoin()
    {
        Globals.counter++;
    }

    public int getCoins()
    {
        return Globals.counter;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Y))
        {
            Globals.counter++;

            print("Coin count: " + Globals.counter);
        }
    }

}
