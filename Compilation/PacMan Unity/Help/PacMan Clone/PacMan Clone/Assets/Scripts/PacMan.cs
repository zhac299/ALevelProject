using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    public Vector2 orientation; //Holds PacMans orientation
    
    public float speed = 4.0f; //This Variable will hold the speed at which Pacman will move at

    public Sprite idleSprite; //This Variable allows PacMan to have a Idle sprite when he interacts with a tile

    private Vector2 direction = Vector2.zero; //Variable will hold Pacmans direction in it so if it's moving left, right, up or down
    private Vector2 nextDirection; //This variable will be used to check which direction PacMan will want to Move to

    public bool canMove = true; //Dictates wheather PacMan can Move or Not

    public static int pelletConsumed = 0; //Is used to count how many pellets are eaten

    private Node currentNode, targetNode, previousNode; //These variables are Node type variables and will store which node pacman is currently on, TargetNode is the Node we are actually going to move to, previousNode will be used to track the node we came from

    private Node startingPosition; //Stores PacMans starting Position for when he gets consumed by a ghost so he can move to it when the game is reset

    // Use this for initialization
    void Start() {
        Node node = GetNodeAtPosition(transform.localPosition); //We get the Postion of the Node that Pacman is on as localPosition is just refernecing PacMan

        startingPosition = node; //Makes startingPosition equal to the Node that PacMan origianlly starts at

        if (node != null) //If the position of pacman is on is a node then the following code is executed
        {
            currentNode = node; //Pacman current location is changed to the node

        }
        direction = Vector2.left; //As in the Original game PacMan starts facing left
        orientation = Vector2.left;
        ChangePosition(direction); //Calls the sub routine by the same name here
    }

    //The Code below is used to reset PacMan when he gets caught by a ghost
    public void Restart()
    {
        canMove = true; //Allows PacMan to Move

        transform.position = startingPosition.transform.position; //Resets PacMans starting position to his original position

        currentNode = startingPosition; //Sets PacMans currentNode to where he started

        direction = Vector2.left; //As in the Original game PacMan starts facing left
        orientation = Vector2.left; //Orientation will be left originally as PacMan moves left originally so will face left
        nextDirection = Vector2.left;

        ChangePosition(direction); //Restarts PacMan Position allowing it to change from its original position
    }

    // Update is called once per frame
    void Update() {

        if (canMove == true) //If PacMan can move then the following code is executed
        {
            CheckInput(); //Sub routine by the same name is called here

            Move(); //Sub routine by the same name is called here

            UpdateOrientation(); //Sub routine by the same name is called here

            UpdateAnimationState(); //Sub Routine by the same name is called here

            ConsumePellet(); //Sub Routine by the same name is called here
        }
    }

    void CheckInput() {

        if (Input.GetKeyDown(KeyCode.LeftArrow)) { //If the Left Key is pressed down then the following code is executed as the condition in the subroutine is fuffiled
            ChangePosition(Vector2.left); //The ChangePosition Routine is called with Vector2.direction we are trying to move in
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow)) //If the Right Key is pressed down then the following code is executed 
        {
            ChangePosition(Vector2.right); //The ChangePosition Routine is called with Vector2.direction we are trying to move in
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow)) //If the Up arrow key is pressed then as the condition in the IF statement is fufilled then the following code is executed
        {
            ChangePosition(Vector2.up); //The ChangePosition Routine is called with Vector2.direction we are trying to move in
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow)) //If the Down key is pressed then the following code is executed
        {
            ChangePosition(Vector2.down); //The ChangePosition Routine is called with Vector2.direction we are trying to move in
        }
    }

    void ChangePosition(Vector2 d) //This will allow PacMan to change his direction
    {
        if (d != direction) //If this statement is correct the follwing code will be executed, the condition is that when d doesn't equal our direction
            nextDirection = d; //If the condition above is fuffiled then this piece of Code will be executed where out next direction = our current direction (d)

        if (currentNode != null) //If we are on a Node then the following code is executed
        {
            Node moveToNode = CanMove(d); //We move to the Node we are trying to reach

            if (moveToNode != null) //If we are trying to move to a Node the following code will be run as the postion we are trying to will not be empty as it contains a Node
            {
                direction = d; //The direction becomes the direction we are trying to move in
                targetNode = moveToNode; //Our targetNode becomes our moveToNode as we are trying to move to that Node
                previousNode = currentNode; //The Node we were on before (or on if we just moved) becomes our previous node
                currentNode = null; //Current Node is reset back to Null
            }
        }

    }


    void Move() //This doesn't return anything so is a void and will control Pacman's movement
    {
        if (targetNode != currentNode && targetNode != null) //If the targetNode doesn't equal the node we are on and the targetNode isn't empty then the following code is ran

            //The IF statement below allows me to change direction in between Nodes
            if (nextDirection == direction * -1) //IF statement makes it so that the direction we want to move changes this is done by inversing the original direction (* -1) so it travels in the opposite direction
            {
                direction *= -1; //Sets Direction to the opposite in the direction it is travelling, so if PacMan is moving up you can move it down if you want and vice versa

                Node tempNode = targetNode; //Temp variable to store a Node for a while whilst other code is ran before, used to value of targetNode isn't lost

                targetNode = previousNode;
                previousNode = tempNode;

            }
        {

            if (OverShotTarget()) //Calls the OverShotTarget function here to check against
            {
                currentNode = targetNode; //currentNode becomes equivilant to our targetNode

                transform.localPosition = currentNode.transform.position; //Our position is moved to the same position as the currentNode

                GameObject otherPortal = GetPortal (currentNode.transform.position); //Code moves PacMan to the other Portal
                if (otherPortal != null) //If the otherPortal isn't null (if the variable isn't empty then the following code is ran)
                {
                    transform.localPosition = otherPortal.transform.position;
                    currentNode = otherPortal.GetComponent<Node> ();
                }

                Node moveToNode = CanMove(nextDirection); //We use the variable moveToNode and set it equal to CanMove with the direction we want to move in next

                if (moveToNode != null) //If the node we are trying to move to isn't empty the following code is executed
                    direction = nextDirection; //Our direction is updated with the new Direction

                if (moveToNode == null) //If the node we are trying to move to is empty so equals null then the following code is executed
                    moveToNode = CanMove(direction); //The CanMove function is run with the direction we are trying to move in and is made equal to the node PacMan is trying to get to

                if (moveToNode != null) //If the node we are trying to move to isn't empty the following code is executed
                {
                    targetNode = moveToNode; //Our targetNode becomes our moveToNode as we are trying to move to that Node
                    previousNode = currentNode; //The Node we were on before (or on if we just moved) becomes our previous node
                    currentNode = null; //Current Node is reset back to Null
                }
                else //If the condition above is not fuffilled then the code below is ran instead
                {
                    direction = Vector2.zero;
                }
            }
            else //If the condition above is not fuffilled then the code below is ran instead
            {
                transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime; //This piece of code basically moves Pacman in the direction it is facing at a pace of the float variable called speed
            }
        }
    }

    void UpdateOrientation() {


        if (direction == Vector2.left) { //If the direction of the object (Pacman) changes than the game is updated with the new direction, here if the direction is changed to left so Pacman faces left than the following code is executed

            orientation = Vector2.left; //Makes the left Orientation the same as the left vector2
            transform.localScale = new Vector3(-1, 1, 1); //Pacman transform inversely so it is resized with its inital values however the -1 as the x value inverses pacman so it faces the opposite direction
            transform.localRotation = Quaternion.Euler(0, 0, 0); //Pacman is not rotated as its not going to be facing up or down

        } else if (direction == Vector2.right) { //If the direction of Pacman is changed to right then the following code is executed

            orientation = Vector2.right; //Makes it so orientation is the same as the right vector2
            transform.localScale = new Vector3(1, 1, 1); //Pacman is made to transform to all positive values so it faces right
            transform.localRotation = Quaternion.Euler(0, 0, 0); //Pacman doesn't rotate as it's not facing up or down

        } else if (direction == Vector2.up) { //If Pacmans direction is changed so it faces upwards

            orientation = Vector2.up; //Makes it so orientation is the same as when PacMan is facing up and thus is given the same vector2
            transform.localScale = new Vector3(1, 1, 1); //It's not resized
            transform.localRotation = Quaternion.Euler(0, 0, 90); //Pacman is rotated so it faces 90 degrees on the set axis as a result it will face up

        } else if (direction == Vector2.down) { //If Pacmans direction is changed so it faces downwards than the following code is ran

            orientation = Vector2.down; //Makes it so orientation is the same as when PacMan is facing down and thus is given the same vector2
            transform.localScale = new Vector3(1, 1, 1); //Pacman isn't inversed size wise so it doesn't change scale wise
            transform.localRotation = Quaternion.Euler(0, 0, 270); //Pacman is set to face 270 degrees on the set axis as a result it will face downwards
        }
    }

    void UpdateAnimationState() //This is used to update the Animation of PacMan
    {

        //Code below makes it so when PacMan collides with a tile (reaches a Node where he cannot move in that single direction anymore) his munching animation stops and remains in a static animation until the next userinput moves him away from that direction
        if (direction == Vector2.zero)
        {
            GetComponent<Animator>().enabled = false; //Disables the Animator
            GetComponent<SpriteRenderer>().sprite = idleSprite; //Sets the sprite to the sprite stored in idleSprite which will stop PacMan from opening and closing his mouth
        }
        else
        {
            GetComponent<Animator>().enabled = true; //Enables the Animator
        }
    }

    void ConsumePellet() //Used to allow PacMan to eat the pellets and superpellets
    {
        GameObject o = GetTileAtPosition(transform.position);

        if (o != null) //If the tile PacMan is occupying isn't null (empty) then the following code is ran
        {
            Tile tile = o.GetComponent<Tile> (); //Temp variable called tile is made which stores the tile PacMan is on

            if (tile != null) //If the tile isn't empty (null) then the following code is ran
            {
                if (!tile.didConsume && (tile.isPellet || tile.isSuperPellet)) //If the tile is consumed and is either a pellet  or super pellet than the following code is ran
                {
                    o.GetComponent<SpriteRenderer>().enabled = false; //The visibility of the pellet/superpellet is turned off as their sprite is no longer going to render as the render is now set to false
                    tile.didConsume = true; //Boolean did consume becomes true

                    if (tile.isSuperPellet) //Short Hand IF statement as only one line of code is executed each time so we can ignore the curly brackets
                    GameBoard.Score += 50; //If PacMan eats a super pellet then he gains 50 points
                    else
                    GameBoard.Score += 10; //Increases the Players Score by 10  for each pellet consumed

                    pelletConsumed++;

                    if (tile.isSuperPellet) //If the tile which is eaten by PacMan is a super pellet the following code is ran
                    {
                        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost"); //Stores all the Ghosts in a Array

                        foreach (GameObject go in ghosts) //Goes through each Ghost and executed the following code
                        {
                            go.GetComponent<Ghost>().startFrightenedMode(); //Puts all of the Ghosts in Frightened Mode
                        }
                    }
                }
            }
        }
    }

    void MoveToNode(Vector2 d)
    {

        Node MovetoNode = CanMove(d); //This variable is used to check if the we can move to the Node or not

        if (MovetoNode != null) //If the position we want to move to is a Node then the follwing code is executed
        {  

            transform.localPosition = MovetoNode.transform.position; //Pacman is moved to the Node we are checking if we can move to or not
            currentNode = MovetoNode; //Pacmans current Node becomes the node we just moved to

        }

    }

    GameObject GetTileAtPosition (Vector2 pos)
    {
        int tileX = Mathf.RoundToInt(pos.x); //This code rounds the X position to a whole number and saves it in the varaible tileX
        int tileY = Mathf.RoundToInt(pos.y); //This code rounds the Y position to a whole number and saves it in the variable tileY

        GameObject tile = GameObject.Find("Game").GetComponent<GameBoard>().board[tileX, tileY]; //Gets allthe tiles from the gameboard into tile

        if (tile != null)
        
        return tile;
     return null;
    }



    Node GetNodeAtPosition (Vector2 pos)
    {

        GameObject tile = GameObject.Find("Game").GetComponent<GameBoard>().board [(int)pos.x, (int)pos.y]; //Here it creates a game object called Tile and we are taking the game component from the game object and then using the board array we are taking the value at pos x and y 

         if (tile != null) //If the tile does equal null we will get a null reference error
        {
            return tile.GetComponent<Node> (); //Returns the value of the component of that node 

        }
        return null; //If tile does equal null then we just return null (so nothing)
    }


    bool OverShotTarget() //Function returns a True or False at the end
    {
        //Variables are declared here and set to values which can change when the program is run
        float NodetoTarget = LengthFromNode(targetNode.transform.position);
        float NodetoSelf = LengthFromNode(transform.localPosition);

        return NodetoSelf > NodetoTarget; //Return True or False, it will be True when we overshot our target otherwise it will be false
    }

    float LengthFromNode(Vector2 targetPosition) //Function is declared where in the parenthasis a Value is required for Vector 2 
    {
        Vector2 vec = targetPosition - (Vector2)previousNode.transform.position; //Here vec is declared as a variable which equals the targetPosition - the position of our previous node
        return vec.sqrMagnitude; //Returns the squared length of vec (Vector2)
    }


 Node CanMove(Vector2 d)
{
    Node MoveToNode = null; //This variable will be used to check if we can Move to the Next Node or not, if we can then the node we can move to is set equal to this variable

    for (int i = 0; i < currentNode.neighbors.Length; i++) //Iterating through all the neighbours of the Node we are currently on, at every iteration we check if all the valid direction we can move, if Pacman can move to the next node then the following code is ran

        if (currentNode.validDirections[i] == d) //If the Node we are trying to go to is a valid node in that direction the following code is ran
        {

            MoveToNode = currentNode.neighbors[i]; //We move to the neighbour of our current node in the direction we are trying to move in
            break; //This makes it so the loop is not ran over again as MovetoNode will be reset to null

        }
    return MoveToNode;
}

    GameObject GetPortal (Vector2 pos)
    {
        GameObject tile = GameObject.Find ("Game").GetComponent<GameBoard> ().board [(int)pos.x, (int)pos.y]; //Finds all objects from game which fit this description

        if (tile != null) //If the tile varaible isn't empty so isn't null the follwing code is ran
        {
            if (tile.GetComponent<Tile>() != null)
            {

                if (tile.GetComponent<Tile>().isPortal) //Checks to see if PacMan is on a Portal Tile (Node) if it is then the following code is ran
                {
                    GameObject otherPortal = tile.GetComponent<Tile>().portalReceiver;
                    return otherPortal; //Used so you can come out of the other portal if you enter the one on the opposite side
                }
            }
        }
        return null; //Function returns nothing if the conditons aren't met
        }
    }