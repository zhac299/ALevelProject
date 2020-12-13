using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public bool isPortal; //Used to see if a tile is a portal or not

    public bool isPellet; //Used to check and differentiate between a normal pellet and super pellet, if the pellet is a normal pellet this variable will be true for that only
    public bool isSuperPellet; //Used to check if the pellet is a normal pellet or super pellet, if the pellet is a super pellet this variable is true for that only
    public bool didConsume; //Used to check if the pellet has been consumed or not so if pacman has collied with it or not

    public bool isGhostHouseEntrance; //Stores the two node in front of the ghost house
    public bool isGhostHouse; //Stores the Nodes inside the Ghost House

    public GameObject portalReceiver; //Used with the isPortal to allow you to teleport to the other portal
}
