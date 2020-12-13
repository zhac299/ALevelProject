using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    //The speed the ghosts move at
    public float moveSpeed = 3.9f;

    //The Speed the ghosts will have when they are in frightened mode
    public float frightenedModeMoveSpeed = 2.9f;

    //Stores the ghosts normal move speed, used for robustness
    public float normalMoveSpeed = 3.9f;

    //Stores the speed the ghosts move at if they've been consumed
    public float consumedMoveSpeed = 15f;

    //The Speed the Ghosts had before the Mode changed allows for us to reverse it
    private float previousMoveSpeed;

    //The time it will take before Pinky will be able to leave the Ghost House
    public int pinkyReleaseTimer = 5;

    //The time it will take before Inky will be able to leave the Ghost House
    public int inkyReleaseTimer = 14;

    //The time it will take before Clyde will be able to leave the Ghost House
    public int clydeReleaseTimer = 21;

    //The Time it will take for Ghost to start Chasing PacMan
    public float ghostReleaseTimer = 0;

    //Time used to count the duration of frightened mode
    private int frightenedModeDuration = 10;

    //Time for when the ghosts start blinking during their frightened mode
    private int startBlinkingAt = 7;

    //Used to check if the Ghost is in the ghost house (centre rectangle) or not
    public bool isInGhostHouse = false;

    //Dictates wheather the ghosts can move or not
    public bool canMove = true;

    //The position of the ghosts at the start
    public Node startingPosition;

    //The variable below will be used to assign each ghost the corner they move to in scatter mode
    public Node homeNode;

    //Used to let ghosts know where their house is so they can return there when they have been consumed
    public Node ghostHouse;

    //The Variable Below resets the ghosts when they change modes
    public RuntimeAnimatorController ghostLeft;

    //The Variables are used to run animations when the player eats a super pellet
    public RuntimeAnimatorController ghostBlue;
    public RuntimeAnimatorController ghostWhite;

    //The Variables below are used as Timers which will count down and lead to different mode that the ghosts move in
    public int scattermodeTimer1 = 7;
    public int chasemodeTimer1 = 20;
    public int scattermodeTimer2 = 7;
    public int chasemodeTimer2 = 20;
    public int scattermodeTimer3 = 5;
    public int chasemodeTimer3 = 20;
    public int scattermodeTimer4 = 5;
    private int modeChangeIteration = 1;
    private float modeChangeTimer = 0;

    //The Variables below are the Timers for Frightened Mode
    public float frightenedModeTimer = 0;
    public float blinkTimer = 0;

    //Variable used to determmine if the ghosts are supposed to blink or not
    private bool frightenedModeisWhite = false;

    //The enumuration below will allow me to change through from each mode more easily
    private enum Mode
    {
        Chase,
        Scatter,
        Frightened,
        Consumed
    }
    //The starting mode is Scatter mode so that's waht the current mode will start of with
    Mode currentMode = Mode.Scatter;
    Mode previousMode;

    //Enum will allow me to use all the different ghosts
    public enum GhostType
    {
        Red,
        Pink,
        Blue,
        Orange
    }

    //Instantiate the ghost type
    public GhostType ghostType = GhostType.Red;

    //This Variable will be used to track PacMan
    private GameObject pacMan;

    //These variables will be used to track the location the Ghosts are on and what direction they want to move in and go
    private Node currentNode, targetNode, previousNode;
    private Vector2 direction, nextDirection;

    // Use this for initialization
    void Start ()
    {
        pacMan = GameObject.FindGameObjectWithTag("PacMan"); //Finds PacMan and makes it equal to pacMan

        Node node = GetNodeAtPosition(transform.localPosition); //New node is declared and becomes equivalent too the position of the ghost

        if (node != null) //If the node isn't empty then the following code is ran
        { 
            currentNode = node; //CurrentNode becomes equal to node so the currentNode is initially equal to the Ghosts starting position
        }

        if (isInGhostHouse) //If the ghost is in the ghost house the following code is ran
        {
            direction = Vector2.up; //The Ghost moves up to leave the ghost house
            targetNode = currentNode.neighbors[0]; //This is 0 as there is only one neighbour in the index which is the node above the ghost house
        }
        else
        {
            direction = Vector2.left; //Initially the Ghost moves left  
            targetNode = ChooseNextNode();  
        }

        previousNode = currentNode; //sets the previous node to the current node as the current node is going to change

        UpdateAnimatorController(); //Updates the Animations

	}
	
    public void Restart() //Resets all ghost variabels to their original values and resets the ghosts position to their original position
    {
        canMove = true; //Allows the ghosts to move

        transform.position = startingPosition.transform.position; //Moves all of the ghosts back to their original position

        ghostReleaseTimer = 0; //Resets this timer, controls whent the ghosts are released from the ghost house
        Berries.berryTimer = 0f; //Resets the Berry Timer
        modeChangeIteration = 1; //Resets the iteration of the Ghosts so when they leave the ghost house they follow their original time limits on each mode
        modeChangeTimer = 0; //Resets this Timer which controls when the Modes chage

        if (transform.name != "Red_Ghost")
            isInGhostHouse = true; //Makes it so blinky (the Red Ghost) is also reset even though he doesn't originally start inside the ghost house

        currentNode = startingPosition; //Resets the currentNode of the ghosts so it starts of equalling the ghosts starting points

        if (isInGhostHouse) //If the Ghosts are in the ghost house then the following code is ran
        {
            direction = Vector2.up; //The Ghosts move upwards to leave the ghost house
            targetNode = currentNode.neighbors [0];
        }
        else //If the Ghost isn't in the ghost house initially (so blinky i.e the red ghost) then the following code is ran
        {
            direction = Vector2.left; //The ghost initally moves left
            targetNode = ChooseNextNode();                 
        }
        previousNode = currentNode; //Resets the value of the previous Node so it starts of intially with the currentNode that the Ghosts are on
        UpdateAnimatorController(); //Updates any animation if it's required
    }

	// Update is called once per frame
	void Update () {
        if (canMove == true) //If the Ghosts can move then the following code is executed
        {
            ModeUpdate(); //Calls the sub routine by the same name here
            Move(); //Calls the sub routine by the same name here
            ReleaseGhosts(); //Calls the sub routine by the same name here
            CheckCollision(); //Calls the sub routine by the same name here
            CheckIsInGhostHouse(); //Calls the sub routine by the same name here
        }
    }

    //Code below checks to see if the Ghosts are in the ghost house or not
    void CheckIsInGhostHouse()
    {
        if (currentMode == Mode.Consumed) //If the ghosts have been eaten by PacMan when they were in frightened mode their mode is changed to consumed and if they are in consumed mode then the following code is ran
        {
            GameObject tile = getTileAtPosition(transform.position); //Get the Tile at the Ghosts current position
            
            if (tile != null) //If there is a value stored in tile then the following code is ran for it
            {
                if (tile.transform.GetComponent<Tile> () != null)
                {
                    if (tile.transform.GetComponent<Tile>().isGhostHouse) //Checks to see if the ghosts are in the ghost house if they are then the following code is ran
                    {
                        moveSpeed = normalMoveSpeed; //The ghost move speed is changed to the normal move speed that they move at
                        Node node = GetNodeAtPosition(transform.position); //Gets the node the ghosts is at

                        //Updates the Node Values
                        if (node != null)
                        {
                            currentNode = node;

                            direction = Vector2.up; //Makes Ghosts move up to leave the ghost house
                            targetNode = currentNode.neighbors[0];

                            previousNode = currentNode;
                            currentMode = Mode.Chase; //Sets Ghost in Chase Mode

                            UpdateAnimatorController(); //Updates Animations
                               
                        }
                    }
                }
            }
        }
    }


    //Code below checks if a collision with pacman has occured or not
    void CheckCollision()
    {
        Rect ghostRect = new Rect(transform.position, transform.GetComponent<SpriteRenderer>().sprite.bounds.size / 4); //Used to consistently make rectangles for the ghost which will be used in collision detection
        Rect pacManRect = new Rect(pacMan.transform.position, pacMan.transform.GetComponent<SpriteRenderer>().sprite.bounds.size /4); //Used to make a rectangle around PacMan of the same size as his sprite which can then be used for collision detection

        //The Code Below will either return true or false which will be used to tell if we have a collision with PacMan or not
        if (ghostRect.Overlaps(pacManRect))
        {
            if (currentMode == Mode.Frightened)
            {
                Consumed();
            }
            else //If the current mode isn't frightened then the following code is ran
            {
                if (currentMode != Mode.Consumed)
                {
                    GameObject.Find("Game").transform.GetComponent<GameBoard>().Restart(); //Calls the restart method from gameboard thus causing the whole game to restart
                }
            }
        }
    }
  
    void Consumed()
    {
        GameBoard.Score += GameBoard.ghostConsumedRunningScore; //Increases the players score when they eat a ghost
        currentMode = Mode.Consumed; //Changes the Ghosts current Mode
        previousMoveSpeed = moveSpeed; //Stores the Ghosts current speed as previous speed
        moveSpeed = consumedMoveSpeed; //Updates the Ghosts Current Move speed to the speed they move at when they are consumed

        UpdateAnimatorController(); //Updates the Animations

        GameBoard.ghostConsumedRunningScore = GameBoard.ghostConsumedRunningScore * 2; //Multuplies the ghosts score by 2 each time a ghost is eaten as this is what happened in the original game

    }

    void UpdateAnimatorController() //Updates the Animations
    {
        if (currentMode != Mode.Frightened) //If the Ghosts are not in frightened mode then the following code is ran
        {
            if (direction == Vector2.up || direction == Vector2.left || direction == Vector2.right || direction == Vector2.down) //If the ghosts are moving in any of the stated directions then the following code is ran
            {
                //If I wanted to add animations for each direciton this is where I would add them with the correct direction using a IF ... ELSE IF statement
                transform.GetComponent<Animator>().runtimeAnimatorController = ghostLeft; //Get the Ghost moving left animation
            }
        }
        else //If the Ghosts are in Frightened Mode then the Following code is ran
        {
            transform.GetComponent<Animator>().runtimeAnimatorController = ghostBlue; //The Ghosts get their blue scared animation
        }
    }

    //Code Below allows the Ghosts to Move
        void Move()
    {
        if (targetNode != currentNode && targetNode != null && !isInGhostHouse) //If the targetNode has a value and it isn't the currentNode then the following code and the ghost is in the ghost house then the following code is ran
        {
            if (OverShotTarget()) //Checks to see if we overshot the target or not
            {
                currentNode = targetNode; //If we did Overshoot the target then our currentNode becomes our targetNode

                transform.localPosition = currentNode.transform.position;

                GameObject otherPortal = GetPortal(currentNode.transform.position); //Check to see if we are on a portal

                if (otherPortal != null) //Makes sure we have a portal
                {
                    transform.localPosition = otherPortal.transform.position; //Moves our ghosts position to the other portal

                    currentNode = otherPortal.GetComponent<Node>(); //Makes out currentNode equal to the portal node that we just moved to
                }

                targetNode = ChooseNextNode(); //Launches ChooseNextNode and assigns the returned value to targetNode so where the ghost is trying to move

                previousNode = currentNode; //Updates the previous node with the current node as current node is about to be updated
            
                currentNode = null;

                UpdateAnimatorController(); //Calls the sub by the same name
            }
            else //If we didn't overshoot our target the following code is ran
            {
                transform.localPosition += (Vector3)direction * moveSpeed * Time.deltaTime; //This code increments the ghosts position basically allowing the ghost to move
            }
        }
    }

    void ModeUpdate() //This routine allows the mode of the ghosts to change as time goes on
    {
        if (currentMode != Mode.Frightened) //If Ghosts aren't in Frightened Mode then the following code is ran
        {
            modeChangeTimer += Time.deltaTime; //The Timer is started

            if (modeChangeIteration == 1) //When modeChangeIteration equals one then the following code is ran
            {
                if (currentMode == Mode.Scatter && modeChangeTimer > scattermodeTimer1) //Checks to see if we are in scatter mode or not and if it is for the following code to run the modechangeTimer would have to have exceeded the scattermodeTimer meaning the mode neads to change
                {
                    ChangeMode(Mode.Chase); //Changes the Ghosts to Chase Mode at the correct iteration of the time
                    modeChangeTimer = 0; //Resets the Timer
                }
                if (currentMode == Mode.Chase && modeChangeTimer > chasemodeTimer1) //If the Timer exceeds the chasemode timer and the current mode is chase then the following code is ran
                {
                    modeChangeIteration = 2; //Changes the Mode iteration to 2 as in PacMan the ghosts follow this loop 4 times, alternating between chase and scatter 4 times before sticking to chase mode
                    ChangeMode(Mode.Scatter); //Changes the Ghosts to scatter Mode
                    modeChangeTimer = 0; //Resets the Timer
                } 
            }

            //The ELSE IF statements below check to see which iteration we are on so do we use chasemodeTimer1 or chasemodeTimer2 etc
            else if (modeChangeIteration == 2) 
            {
                if (currentMode == Mode.Scatter && modeChangeTimer > scattermodeTimer2) //If the Ghosts are in scatter mode and the timer has exceed that time then the following code is ran
                {
                    ChangeMode(Mode.Chase); //Ghosts change to Chase mode
                    modeChangeTimer = 0; //Resets the Timer
                }
                if (currentMode == Mode.Chase && modeChangeTimer > chasemodeTimer2) //If the Ghosts are in chase mode and timer exceeds the chase timer then the following code is ran
                {
                    modeChangeIteration = 3; //Calls the third iteration of mode changes
                    ChangeMode(Mode.Scatter); //Changes the Ghosts to Scatter Mode
                    modeChangeTimer = 0; //Resets the timer
                }
            }
            else if (modeChangeIteration == 3) //If we are in the third iteration then the following code is ran
            {
                if (currentMode == Mode.Scatter && modeChangeTimer > scattermodeTimer3) //If we are in scatterMode and modeChangeTimer exceeds scatterModeTimer then the following code is ran
                {
                    ChangeMode(Mode.Chase); //Changes the Ghosts to Chase Mode
                    modeChangeTimer = 0; //Resets the Timer
                }
                if (currentMode == Mode.Chase && modeChangeTimer > chasemodeTimer3) //If we are in Chase Mode and the modeChangeTimer exceeds the chase Timer then the following code is ran
                {
                    modeChangeIteration = 4; //We Move on to our 4th iteration
                    ChangeMode(Mode.Scatter); //Changes the ghost mode to scatter mode
                    modeChangeTimer = 0; //Resets the Timer
                }
            }
            else if (modeChangeIteration == 4)
            {
                // The IF statement below does not contain a scatter mode as in the original PacMan game after 4 iterations of the Timer the game just let the ghosts stay in Chase Mode
                if (currentMode == Mode.Scatter && modeChangeTimer > scattermodeTimer4)
                {
                    ChangeMode(Mode.Chase);
                    modeChangeTimer = 0;
                }
            }
        }
        else if (currentMode == Mode.Frightened) //If Ghosts are in Frightened Mode then the following code is ran
        {
            frightenedModeTimer += Time.deltaTime; //Increments the Timer

            if (frightenedModeTimer >= frightenedModeDuration) //Once the Frightened Mode Timer as reached it max duration the following code is ran
            {
                frightenedModeTimer = 0; //Value is reset

                ChangeMode(previousMode); //Mode is changed back to its previous mode

            }
            if (frightenedModeTimer >= startBlinkingAt) //If FrightendModetimer exceeds the startBlinking period then the following code is ran
            {
                blinkTimer += Time.deltaTime; //Starts Blink Timer, allows ghosts to blink to inform player that  frightend mode is nearly over

                if (blinkTimer >= 0.1f)
                {
                    blinkTimer = 0f; //Resets the Blink Timer
                     
                    if (frightenedModeisWhite) //Checks the Boolean, initally false so the following code is ran which alternates the ghost between blue and white
                    {
                        //Code below allows Ghosts to blink by alternating a bool variable for if the ghost is white or not and by using the animator to change the ghosts animation between scared blue and white ghosts
                        transform.GetComponent<Animator>().runtimeAnimatorController = ghostBlue; 
                        frightenedModeisWhite = false;
                    }
                    else
                    {
                        transform.GetComponent<Animator>().runtimeAnimatorController = ghostWhite;
                        frightenedModeisWhite = true;
                    }
                }
            }
        }
    }

    void ChangeMode(Mode m) //This changes the mode we are playing at and as it isn't a function it doesn't return anything
    {

        if (currentMode == Mode.Frightened) //Checks if the Mode is Frightened then the movespeed gains speed as previous move speed if there is one
        {
            moveSpeed = previousMoveSpeed;
        }

        if (m == Mode.Frightened) //If the mode is frightened then the following code is ran
        {
            previousMoveSpeed = moveSpeed;
            moveSpeed = frightenedModeMoveSpeed; //Ghosts gain the slower speed of frightened move speed
        }

        if (currentMode != m) //If our current mode isn't the mode we are trying to change to then the following code is ran, this is done to stop an infinite loop of a mode such as frightened mode as otherwise previous mode would get updated to be frightend mode again if it was called again thus causing an infinite loop
        {
            //Updates all of the Modes
            previousMode = currentMode; 
            currentMode = m;
        }

        UpdateAnimatorController(); //Updates the Animations

    }

    public void startFrightenedMode()
    {
        if (currentMode != Mode.Consumed) //If the Ghosts haven't been consumed by PacMan then the following code is ran
        {
            GameBoard.ghostConsumedRunningScore = 200; //Everytime frightened mode is started and a ghost is consumed the score recieved from eating a ghost is always initally 200 and multiplies by 2 each time

            frightenedModeTimer = 0; //Resets the Timer whenever Frightened Mode is started

            ChangeMode(Mode.Frightened); //Changes the Mode to Frightened Mode
        }
    }
            
    Vector2 GetRedGhostTargetTile()
    {
        Vector2 pacManPosition = pacMan.transform.localPosition; //This variable stores PacMans position
        Vector2 targetTile = new Vector2(Mathf.RoundToInt (pacManPosition.x), Mathf.RoundToInt (pacManPosition.y)); //Rounds PacMans position to an Integer

        return targetTile; //Function outputs targetTile
    }

    Vector2 GetPinkGhostTargetTile()
    {
        //Has to be 4 tiles ahead of PacMan and need to take into account the positon and orientation

        Vector2 pacManPosition = pacMan.transform.localPosition; //Variable stores PacMans location
        Vector2 pacManOrientation = pacMan.GetComponent<PacMan>().orientation; //Stores PacMans Orientation

        int pacManPositionX = Mathf.RoundToInt(pacManPosition.x); //Rounds PacMans x coordinate to a whole number
        int pacManPositionY = Mathf.RoundToInt(pacManPosition.y); //Rounds PacMans y coordinate to a whole number

        Vector2 pacManTile = new Vector2(pacManPositionX, pacManPositionY);
        Vector2 targetTile = pacManTile + (4 * pacManOrientation); //Multiplies all of the vector2 by 4 so both x and y coordinate seperatly and then adds pacManTile to it so Pinky is always 4 tiles ahead of PacMan

        return targetTile; //Function outputs targetTile
    }

    Vector2 GetBlueGhostTargetTile()
    {
        //Most Complex AI out of all of the Ghosts
        //Select the Position two tiles in front of PacMan then draw a vector from blinky to that position then double the length of that vector

        Vector2 pacManPosition = pacMan.transform.localPosition; //Gets PacMans position
        Vector2 pacManOrientation = pacMan.GetComponent<PacMan> ().orientation; //Gets Pacmans Orientation

        int pacManPositionX =  Mathf.RoundToInt(pacManPosition.x); //Stores PacMan X coordinate in this variable
        int pacmanPositionY = Mathf.RoundToInt(pacManPosition.y);  //Stores PacMan Y cooridinate in this variable

        Vector2 pacManTile = new Vector2 (pacManPositionX, pacmanPositionY); //Get PacMan Tile

        Vector2 targetTile = pacManTile + (2 * pacManOrientation); //Create a TargetTile for where PacMan is

        Vector2 tempBlinkyPosition = GameObject.Find("Red_Ghost").transform.localPosition;  //Create a temp variable for Blinky position
    
        
        int blinkyPositionX = Mathf.RoundToInt(tempBlinkyPosition.x); //Stores Blinkys x position in this variable 
        int blinkyPositionY = Mathf.RoundToInt(tempBlinkyPosition.y); //Stores Blinkys y position in this variable

        tempBlinkyPosition = new Vector2(blinkyPositionX, blinkyPositionY); //Stores Blinkys coordinate in a new vector2 variable

        float distance = GetDistanceApart(tempBlinkyPosition, targetTile); //Gets the distance apart between blinkys position and the target tile
        distance *= 2; //Multiplies the distance by 2 every time it changes so the Blue ghost is always two tiles in from of PacMan

        targetTile = new Vector2(tempBlinkyPosition.x + distance, tempBlinkyPosition.y + distance); //The target tile is equal to Blinkys x and y position + the distance

        return targetTile; //Outputs the Target Tile
    }

    Vector2 GetOrangeGhostTargetTile()
    {
        //Calculate the Distance that Clyde is from PacMan then if the distance > 8 tiles then targetting is same as Blinky else the target is his Home Node, so same as Scatter Mode
        //This is because Clyde never catches PacMan is similar to a bluff to trick the player into breaking logic and moving into risky situations

        Vector2 pacManPosition = pacMan.transform.localPosition; //Gets PacMans position

        float distance = GetDistanceApart(transform.localPosition, pacManPosition); //Gets the distance from Clyde to PacMan
        Vector2 targetTile = Vector2.zero; //Sets targetTile to (0,0)
       
        if (distance > 8) //If Distance is greater than 8 then the following code is ran
        {
            targetTile = new Vector2(Mathf.RoundToInt(pacManPosition.x), Mathf.RoundToInt(pacManPosition.y));
        }
        else if (distance < 8) //If Distance is less than 8 then the following code is ran
        {
            targetTile = homeNode.transform.position; //Makes the TargetTile the Home Node
        }
        return targetTile; //Outputs the targetTile
    }

    Vector2 GetTargetTile () //This function returns each ghosts target tile
    {
        Vector2 targetTile = Vector2.zero;

        if (ghostType == GhostType.Red) //The red ghost will be released with the following code
        {
            targetTile = GetRedGhostTargetTile();
        }
        else if (ghostType == GhostType.Pink) //The pink ghost will be released with the following code
        {
            targetTile = GetPinkGhostTargetTile();
        }
        else if (ghostType == GhostType.Blue) //The blue ghost will be released with the following code
        {
            targetTile = GetBlueGhostTargetTile();
        }
        else if (ghostType == GhostType.Orange) //The orange ghost will be released with the following code
        {
            targetTile = GetOrangeGhostTargetTile();
        }
        return targetTile; //Returns (Outputs) the target tile
    }

    Vector2 GetRandomTile()
    {
        int x = Random.Range(0, 28); //Gets a random x value between the range of the maps width
        int y = Random.Range(0, 36); //Gets a random y value between the range of the maps height

        return new Vector2 (x, y); //Outputs the Random Position (so Tile/Node) the ghost moves to
    }

    void ReleasePinkGhost() //Used to Release the Pink Ghost from the Ghost House
    {
        if (ghostType == GhostType.Pink && isInGhostHouse) //If the ghost is the Pink ghost and is in the ghost house the following code is executed
        {
            isInGhostHouse = false; //Makes it so that the Pink Ghost leaves so is no longer in the house so the boolean variable becomes false
        }
    }

    void ReleaseBlueGhost() //Used to release the Blue Ghost from the ghost house
    {
        if (ghostType == GhostType.Blue && isInGhostHouse) //If the ghost is the blue ghost and is in the ghost house then the following code is ran
        {
            isInGhostHouse = false; //Makes it so that the Blue ghost leaves so is no longer in the house so the boolean varaibele isInGhostHouse becomes false
        }
    }

    void ReleaseOrangeGhost() //Used to release the Orange Ghost from the ghost house
    {
        if (ghostType == GhostType.Orange && isInGhostHouse) //If the ghost is the orange ghost and is in the ghost house then the following code is ran
        {
            isInGhostHouse = false; //Makes it so that the Orange ghost leaves so is no longer in the house so the boolean varaibele isInGhostHouse becomes false
        }        

    }

    void ReleaseGhosts()
    {
        ghostReleaseTimer += Time.deltaTime; //Counts the timer which will be used to execute time based events

        if (ghostReleaseTimer >= pinkyReleaseTimer) //If the ghostreleasetimer has a greater value then the timer for the pinky release timer the following code is executed
            ReleasePinkGhost(); //Pinky is released

        if (ghostReleaseTimer >= inkyReleaseTimer) //If the ghostreleasetimer has counted over then inkys release timer then the following code is ran (this is will be literally when the timer is above the inky timer by the smallest possible amount)
            ReleaseBlueGhost(); //Inky is released

        if (ghostReleaseTimer >= clydeReleaseTimer) //If the ghostreleasetimer has a greater value then the timer for clyde release timer then the following code is executed
            ReleaseOrangeGhost(); //Clyde is released
    }

    Node ChooseNextNode() //This function will tell the ghost AI which Node to move to next
    {
        Vector2 targetTile = Vector2.zero; //The target tile initially is (0, 0)

        //The IF statement below allows for the ghosts to change mode and follow the mode that they should be in, this will be the same as the original game
        if (currentMode == Mode.Chase) 
        {
        targetTile = GetTargetTile(); //targetTile is now set by GetTargetTile which gets a different TargetTile according to each ghosts original algorithm
        }
        else if (currentMode == Mode.Scatter) //When program starts ghosts are initally going to be in scatter mode thus the following code will move each ghost to their home Node (their corner in the map)
        {
            targetTile = homeNode.transform.position; //The Ghosts move towards their home nodes
        }else if (currentMode == Mode.Frightened) //If the Current Mode is Frightened Mode then the following code is ran
        {
            targetTile = GetRandomTile(); //The Ghosts move to random tiles across the map
        }else if (currentMode == Mode.Consumed) //If the Ghosts have been consumed by pacman whilst they were in frightened mode then the following code is ran
        {
            targetTile = ghostHouse.transform.position; //The Ghosts move to the GhostHouse node they have been assigned
        }

        //A new Node variable is made here which has a initial value of nothing (null), this is used to allow ghosts to move from node to node
        Node moveToNode = null; 

        Node[] foundNodes = new Node[4];
        Vector2[] foundNodesDirection = new Vector2[4];

        int nodeCounter = 0;

        for (int i = 0; i < currentNode.neighbors.Length; i++)
        {
            if (currentNode.validDirections [i] != direction * -1)
            {
                if (currentMode != Mode.Consumed) //If the Ghosts are not in Consumed Mode then the following code is ran
                {
                    GameObject tile = getTileAtPosition(currentNode.transform.position); //Get a tile for the node the ghost is at

                    if (tile.transform.GetComponent<Tile>().isGhostHouseEntrance == true)
                    {
                        //If we found a Ghost House, thus we don't want to allow movement

                        if (currentNode.validDirections[i] != Vector2.down)
                        {
                            foundNodes[nodeCounter] = currentNode.neighbors[i];
                            foundNodesDirection[nodeCounter] = currentNode.validDirections[i];
                            nodeCounter++;
                        }
                    }
                    else //If we are at tile which isn't the ghost house tile then the following code is ran
                    {
                        foundNodes[nodeCounter] = currentNode.neighbors[i];
                        foundNodesDirection[nodeCounter] = currentNode.validDirections[i];
                        nodeCounter++;
                    }
                }
                else //If we are in consumed mode then we have to allow the ghosts to move in any direction so they can travel to the ghost house
                {
                    foundNodes[nodeCounter] = currentNode.neighbors[i];
                    foundNodesDirection[nodeCounter] = currentNode.validDirections[i];
                    nodeCounter++;

                }

            }
        }
        if (foundNodes.Length == 1) //This means we have only found one Node, as a result of this the following code is ran
        {
            moveToNode = foundNodes[0];
            direction = foundNodesDirection[0];
        }

        if (foundNodes.Length > 1) //If we have found more than one node
        {
            float leastDistance = 100000f;
        
            for (int i = 0; i < foundNodes.Length; i++)
            {
                if (foundNodesDirection [i] != Vector2.zero)
                {
                    float distance = GetDistanceApart(foundNodes[i].transform.position, targetTile);

                    if (distance < leastDistance)
                    {
                        leastDistance = distance;
                        moveToNode = foundNodes [i];
                        direction = foundNodesDirection[i];
                    }
                }
            }
        }
        return moveToNode;
    }

    Node GetNodeAtPosition (Vector2 pos)
    {

        //Creating a GameObject and setting it equal to the  object in the GameBoard array at that position
        GameObject tile = GameObject.Find("Game").GetComponent<GameBoard> ().board[(int)pos.x, (int)pos.y];

        if (tile != null) //Checks to see if the object we grabbed is empty (null) or not
        {
            if (tile.GetComponent<Node> () != null) //Checks to see if the object we grabbed is a Node or not
            {
                return tile.GetComponent<Node>();
            }
        }
        return null;
    }

    GameObject getTileAtPosition(Vector2 pos) //Used to get the Tile Position where the ghosts is at
    {
        //Two variables are madewhich store x and y values
        int tileX = Mathf.RoundToInt(pos.x); 
        int tileY = Mathf.RoundToInt(pos.y);

        //Stores everything in the gameboard at tileX and tileY in tile
        GameObject tile = GameObject.Find("Game").GetComponent<GameBoard>().board[tileX, tileY];

        if (tile != null) //If tile does equal something then the following code is ran
            return tile;
        return null;
    }

    GameObject GetPortal (Vector2 pos) //This function allows the Ghosts to use the same portals as PacMan as they could in the original game
    {
        GameObject tile = GameObject.Find("Game").GetComponent<GameBoard>().board[(int)pos.x, (int)pos.y]; //Searches throught the GameBoard array

        if (tile != null)
        {
            if (tile.GetComponent<Tile> ().isPortal) //Checks to see if the Tile is a portal tile or not if it is then the following code is ran
            {
                GameObject otherPortal = tile.GetComponent<Tile>().portalReceiver; //Makes the tile in the other portal the reciever and stores its value in otherPortal
                return otherPortal; //Outputs otherPortal
            }
        }
        return null; //Otherwise returns null
    }

    float LengthFromNode (Vector2 targetPosition) //Calculatees the distance from the node to allow AI to get the fastest way to PacMan
    {
        Vector2 vec = targetPosition - (Vector2)previousNode.transform.position;

        return vec.sqrMagnitude;
    }

    //Checks to see if we went over/past target or not
    bool OverShotTarget()
    {
        float nodeToTarget = LengthFromNode(targetNode.transform.position); //Lets us get the position of the Node and thus the distance
        float nodeToSelf = LengthFromNode(transform.localPosition); //Gets the distance from Ghost to Node

        return nodeToSelf > nodeToTarget; //Returns a value if the Ghost is further away from the Node then the target
    }

    float GetDistanceApart (Vector2 posA, Vector2 posB) //Function allows the ghosts to know the distance apart they are from two positions A and B
    {
        float dx = posA.x - posB.x;
        float dy = posA.y - posB.y;

        float distance = Mathf.Sqrt(dx * dx + dy * dy); //Simple Mathematical formula used to calculate distance: distance = sqroot(x1 + x2)^2 + (y1 + y2)^2

        return distance; //Returns the distance apart
    }
}
