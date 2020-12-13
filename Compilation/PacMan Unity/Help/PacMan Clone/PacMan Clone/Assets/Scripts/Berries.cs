using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berries : MonoBehaviour {

    public static int count = 1; //Count Variable used to keep track of how many times an even can take place
    public static int count2 = 1; //Counts if a berry has been eaten or not
    public int berryPoint = 100; //Amount of points gained by PacMan if he consumes a berry

    public static float berryTimer = 0f; //BerryTimer keeps track of when berry can appear
    public float privCounter = 0f;

    public bool isConsumed; //Checks to see if berry has been consumed or not
    private bool isVisible; //Checks to see if berry is visible or not

    private bool canTick = true; //Used to tell if Timer Can Tick or not

    private GameObject pacMan; //Stores PacMan

    //Variables Below store all of the berries
    private GameObject Strawberry;
    private GameObject Cherry;
    private GameObject Apple;
    private GameObject Peach;

    // Use this for initialization
    void Start() {

        pacMan = GameObject.FindGameObjectWithTag("PacMan"); //Finds PacMan and makes it equal to pacMan

        Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));

        foreach (GameObject o in objects) //Iterates through all of the objects and adds them to the Array which will contain all the objects in the scene
        {
            if (o.name == "Strawberry") //If object is strawberry
            {
                Strawberry = o; //Makes strawberry equal to its object
                o.GetComponent<SpriteRenderer>().enabled = false; //Stop rendering its sprite
            }
            else if (o.name == "Cherry") //If object is Cherry
            {
                Cherry = o; //Makes Cherry equal to its object
                o.GetComponent<SpriteRenderer>().enabled = false; //Stop rendering its sprite
            }
            else if (o.name == "Apple") //If object is Apple
            {
                Apple = o; //Makes Apple equal to its object
                o.GetComponent<SpriteRenderer>().enabled = false; //Stop rendering its sprite
            }
            else if (o.name == "Peach") //If object is Peach
            {
                Peach = o; //Makes Peach equal to its object
                o.GetComponent<SpriteRenderer>().enabled = false; //Stop rendering its sprite
            }
        }
    }

    // Update is called once per frame
    void Update() {
        int rnd = Random.Range(0, 5); //Gets a random number between the range 0 and 5

        if (canTick == true) //If the timer is allowed to tick then the following code is ran
        {
            privCounter += Time.deltaTime; //privCounter is started
        }

        //Code Below checks to see if Berry can spawn in or not and if they are spawning in at the right timer and level
        berryTimer += Time.deltaTime;
        if (((berryTimer >= 45) && GameBoard.playerLevel == 1) && count2 == 1)
        {
            BerryGen(Cherry);
        }
        else if (((berryTimer >= 45) && GameBoard.playerLevel == 2) && count2 == 1)
        {
            BerryGen(Strawberry);
        }
        else if (((berryTimer >= 45) && GameBoard.playerLevel == 3) && count2 == 1)
        {
            BerryGen(Apple);
        }
        else if (((berryTimer >= 45) && GameBoard.playerLevel == 4) && count2 == 1)
        {
            BerryGen(Peach);
        }
        else if (((berryTimer >= 45) && GameBoard.playerLevel > 4) && count2 == 1)
        {
            if (rnd == 1)
                BerryGen(Strawberry);
            else if (rnd == 2)
                BerryGen(Cherry);
            else if (rnd == 3)
                BerryGen(Peach);
            else if (rnd == 4)
                BerryGen(Apple);
            else if (rnd == 5)
            {
                //Do Nothing
            }
        }
  CheckCollision(); //Call Sub Routine by the same name here
    }

    //Checks to see if Berry and PacMan have collided or not
    void CheckCollision()
    {

        Rect BerryRect = new Rect(transform.position, transform.GetComponent<SpriteRenderer>().sprite.bounds.size / 4); //Used to consistently make rectangles for the berries which will be used in collision detection
        Rect pacManRect = new Rect(pacMan.transform.position, pacMan.transform.GetComponent<SpriteRenderer>().sprite.bounds.size / 4); //Used to make a rectangle around PacMan of the same size as his sprite which can then be used for collision detection

        //The Code Below will either return true or false which will be used to tell if we have a collision with PacMan or not
        if (BerryRect.Overlaps(pacManRect))
        {
            isConsumed = true; //Makes the isConsumed Variable True meaning makes it so the berry has been eaten

            if (isVisible == true) //If the berry is visible so the player can see it then follwing code is ran
            {
                GameBoard.Score += 100; //Player gains 100 point
                isVisible = false; //Makes it so Berry is no longer visible so player cannot gain an infinite amount of points
                count2 -= 1; //Decreases Count by 1
            }                

            //Code below disables all the berrys
            Cherry.GetComponent<SpriteRenderer>().enabled = false;
            Strawberry.GetComponent<SpriteRenderer>().enabled = false;
            Apple.GetComponent<SpriteRenderer>().enabled = false;
            Peach.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    //Code Below spawns in Berrys which PacMan can eat to gain more points
    void BerryGen(GameObject Berry)
    {
        int roll = Random.Range(0, 10); //Random Number between range 0 to 10 is given

        if (count == 1 && roll == 5) //If count is 1 and the number given by roll is 5 then the following code is ran
        {
            Berry.GetComponent<SpriteRenderer>().enabled = true; //The Berry stated is spawned in
            isVisible = true; //Berry becomes visible
            isConsumed = false; //Berry hasn't been eaten
            count -= 1; //Reduces count by 1 so an infinte amount of berrys cannot spawn in
        }

        if (privCounter >= 45) //If privCounter has exceeded the stated value then the following code is ran
        {
            canTick = false; //Can tick is set to false
            Berry.GetComponent<SpriteRenderer>().enabled = false; //Berry is disabled
        }
    }
}
