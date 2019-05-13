using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

	private int diceCount;
    private Sprite diceSprite;
	public static Dice instance;

    public Sprite dice_1;
    public Sprite dice_2;
    public Sprite dice_3;
    public Sprite dice_4;
    public Sprite dice_5;
    public Sprite dice_6;

    internal Vector3 initPos;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().solverIterations = 16; //teacher give 250
		instance = this;
		initPos = transform.position;
	}

	private void OnEnable() {
		initPos = transform.position;
	}

	public int GetDiceCount(){
		diceCount = 0;
		regularDiceCount();
		return diceCount;
	}

    public Sprite GetDiceSprite()
    {
        regularDiceCount();
        return diceSprite;
    }

    private void regularDiceCount()
    {
        if(Vector3.Dot(transform.forward, Vector3.up) > 0.6f){
			diceCount = 5;
            diceSprite = dice_5;

        }
		if(Vector3.Dot(-transform.forward, Vector3.up) > 0.6f){
			diceCount = 2;
            diceSprite = dice_2;
        }
		if(Vector3.Dot(transform.up, Vector3.up) > 0.6f){
			diceCount = 3;
            diceSprite = dice_3;
        }
		if(Vector3.Dot(-transform.up, Vector3.up) > 0.6f){
			diceCount = 4;
            diceSprite = dice_4;
        }
		if(Vector3.Dot(transform.right, Vector3.up) > 0.6f){
			diceCount = 6;
            diceSprite = dice_6;
        }
		if(Vector3.Dot(-transform.right, Vector3.up) > 0.6f){
			diceCount = 1;
            diceSprite = dice_1;
        }
    }

}
