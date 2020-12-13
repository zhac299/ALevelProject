using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameBoard : MonoBehaviour
{

    public static int pacManLives = 3; //Keeps track of PacMans Lives

    public static int playerLevel = 1; //Keeps track of what level the player is on

    private static int boardWidth = 28; //This varaible is an integer which won't change its value thus is static and not dynamic, the varaible sets the games width which is the same as the width of the original PacMan game
    private static int boardHeight = 36; //This varaible is an integer which won't change its value thus is static and not dynamic, the varaible sets the games height which is the same as the height of the original PacMan game

    public int totalPellets = 0; //This will be used to count how many pellets there are in the game
    public static int Score = 0; //This will store the players score

    public static int ghostConsumedRunningScore; //Variable will store the score gained from consuming a ghost

    public Text playerOneUp; //Will indicate where the player score is shown
    public Text playerOneScoreText; //Will display the players score

    //Holds picture of PacMan which represents the amount of lives he has left
    public Image Lives;
    public Image Lives2;
    public Image Lives3;

    public GameObject inputField; //Stores the InputBox where the player will write their high score, used to hide it
    public GameObject hideButton; //Stores the button and is used to hide it 
    public InputField textField; //Stores the text field where the player will write their username if they want to store it
    public Button submitButton; //Stores the button which when pressed will save the players data

    public GameObject[,] board = new GameObject[boardWidth, boardHeight]; //This multidimenstional array will be used to store all the game objects which are inside the board (thus the width and height is referenced)

    // Use this for initialization
    void Start()
    {

        inputField.SetActive(false); //Makes the Input Field Invisible
        hideButton.SetActive(false); //Makes the Button Invisible

        Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject)); //Makes a local variable called objects which will detect all of the GameObjects in the scene at the start of the Array and will be used with the FOR loop below to iterate through them and store them in the array

        foreach (GameObject o in objects) //Iterates through all of the objects and adds them to the Array which will contain all the objects in the scene
        {
            Vector2 pos = o.transform.position; //Stores the position in Vector 2

            if (o.name != "PacMan" && o.name != "Nodes" && o.name != "NonNodes" && o.name != "Maze" && o.name != "Pellets" && o.tag != "Ghost" && o.tag != "ghostHome" && o.name != "Canvas" && o.tag != "UIElements" && o.tag != "Berry") //If the tag/name of the object being added to the array is any of the name specified within the parameter it won't be added to the array
            {
                if (o.GetComponent<Tile>() != null) //If the object is a Tile then the following code is ran
                {
                    if (o.GetComponent<Tile>().isPellet || o.GetComponent<Tile>().isSuperPellet) //If the object is a pellet or a superpellet then the following code is ran
                    {
                        totalPellets++; //Increments the value of total pellets by 1, so counts how many pellets there are initially
                    }
                }

                board[(int)pos.x, (int)pos.y] = o; //The x and y location is stored in the array for every object not called Pacman as o

            }
            else
            { //If the condtion in the IF statement isn't fuffiled then this ELSE statement is executed

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI(); //Calls the Sub Routine by the same name here
        CheckPelletsConsumed();
    }

    void UpdateUI() //Used to Update all objects on the UI
    {
        playerOneScoreText.text = Score.ToString(); //Updates the Players Score text box displaying their score so they can see it

        if (pacManLives == 2) //If PacMan has two lives left then the following code is ran
        {
            Lives.enabled = false; //One life image is diabled to inform player how many lives they have left
            Berries.count = 1; //Variable used to count is reset
        }
        else if (pacManLives == 1) //If PacMan has only one life left then the following code is executed
        {
            //Disabled the Life image to inform player how many lives they have left
            Lives.enabled = false;
            Lives2.enabled = false;

            Berries.count = 1; //Variable used to count is reset
        }
        else if (pacManLives == 0) //If PacMan has 0 Lives left then the following code is ran
        {

            GameObject pacMan = GameObject.Find("PacMan"); //Finds PacMan
            pacMan.transform.GetComponent<PacMan>().canMove = false; //Stops Pacman from moving

            GameObject[] o = GameObject.FindGameObjectsWithTag("Ghost"); //Finds all of the Ghosts and stores in an array called o
            foreach (GameObject ghost in o)
            {
                ghost.transform.GetComponent<Ghost>().canMove = false; //Stops ghosts from moving
            }

            //Disabled the Life image to inform player how many lives they have left
            Lives.enabled = false;
            Lives2.enabled = false;
            Lives3.enabled = false;

            //Makes the following Fields Visible
            inputField.SetActive(true);
            hideButton.SetActive(true);
            inputField.SetActive(true);

            submitButton.onClick.AddListener(SaveData); //Saves the Users Data when the button is pressed
        }

        //Used to reduce errors by resetting PacMan lives to 0 if they ever go below 0 for any bug related reason at all
        if (pacManLives < 0)
        {
            pacManLives = 0;
        }

    }

    //Code below checks to see how many pellets PacMan has consumed
    void CheckPelletsConsumed()
    {
        if (totalPellets == PacMan.pelletConsumed) //Check if the Player has eaten all the pellets
        {
            PacMan.pelletConsumed = 0; //Resets the amount of Pellets eaten by PacMan
            PlayerWin(1); //Launches the sub-routine by the same name
        }
    }

    //The Code Below is ran when the player eats all of the pellets
    void PlayerWin(int playerNum)
    {
        if (playerNum == 1)
        {
            GameBoard.playerLevel++; //Increases the players level via increment
        }
        StartCoroutine(ProcessWin(2));
    }

    IEnumerator ProcessWin(float delay) //starts the win process by causing a delay which is stated in the parenthesis when called
    {
        GameObject pacMan = GameObject.Find("PacMan");
        pacMan.transform.GetComponent<PacMan>().canMove = false; //Stops Pacman from moving

        GameObject[] o = GameObject.FindGameObjectsWithTag("Ghost");
        foreach (GameObject ghost in o)
        {
            ghost.transform.GetComponent<Ghost>().canMove = false; //Stops ghosts from moving
        }
        yield return new WaitForSeconds(delay); //Will be used to animate the blinking of the board, if the player does win as the board blinks

        StartNextLevel(); //Starts the next level
        Berries.berryTimer = 0f; //Value of timer is reset
        Berries.count = 1; //Count Variable is reset
        Berries.count2 = 1; //Count2 Variable is reset
    }

    private void StartNextLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Level1"); //Will restart the scene allowing the player to continue playing once they've eaten all of the pellets of one level
    }

    public void Restart() //This is used to restart the whole game for when PacMan is caught
    {
        pacManLives -= 1; //Decreases PacMans lives each time he's caught

        Berries.count = 1;

        GameObject pacMan = GameObject.Find("PacMan"); //Finds Pacman then runs the code below
        pacMan.transform.GetComponent<PacMan>().Restart();  //Runs PacMans restart routine

        GameObject[] o = GameObject.FindGameObjectsWithTag("Ghost"); //Finds all of the Ghosts in the game and stores them in an array

        foreach (GameObject ghost in o) //This FOR EACH loop, loops through all the ghosts in the array and applies the restart method on them
        {
            ghost.transform.GetComponent<Ghost>().Restart();
        }
    }

    private void SaveData()
    {
        //Path of the File
        string path = ("E:/College Subjects/Computer Science/Computer Science NEA/My Games/PacMan Unity/Help/PacMan Clone/PacMan Clone/Assets/Text File/Username.txt");

        //Gets writer which will write to the file in path
        StreamWriter writer = new StreamWriter(path);

        //Writes the line in the parameters
        writer.WriteLine(textField.text + ", " + playerOneScoreText.text);

        //Closes the Writer
        writer.Close();


        //Path of the File
        string path2 = ("E:/College Subjects/Computer Science/Computer Science NEA/My Games/PacMan Unity/Help/PacMan Clone/PacMan Clone/Assets/Text File/Score.txt");

        //Gets writer which will write to the file in path
        StreamWriter writer2 = new StreamWriter(path2);

        //Writes the line in the parameters
        writer2.WriteLine(playerOneScoreText.text);

        //Closes the Writer
        writer2.Close();

        Application.Quit(); //Closes the Application
    }
}