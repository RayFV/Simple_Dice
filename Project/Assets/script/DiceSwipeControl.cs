using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceSwipeControl : MonoBehaviour {
	public GameObject diceObj;
	public Camera dicePlayCam;
	public TMP_Text diceNum;
    public Image diceImg;
    public AudioClip landingSoundEffect;
    public AudioClip throwingSoundEffect;

	public float settingTest = 20f;
    
	private Vector3 initPos;
	private Vector3 originalDicePos;
	
	private void Start() {
		originalDicePos = diceObj.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 currentPos = Input.mousePosition;
        Vector3 newPos = dicePlayCam.ScreenToWorldPoint(new Vector3(currentPos.x, currentPos.y, Mathf.Clamp(currentPos.y / 10, 5, 25)));
        if (Input.GetMouseButtonDown(0))
        {
            ResetRigidBody();
            gameObject.GetComponent<AudioSource>().PlayOneShot(throwingSoundEffect);
            initPos = dicePlayCam.ScreenToWorldPoint(Input.mousePosition);
            AddForce(newPos);
            diceObj.transform.position = new Vector3(dicePlayCam.transform.position.x, dicePlayCam.transform.position.y, dicePlayCam.transform.position.z - settingTest);
            diceObj.transform.rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
		}
        if (Input.GetMouseButtonUp(1))
        {
            diceObj.transform.position = originalDicePos;
            ResetRigidBody();
        }
        
		Vector3 dicePos = diceObj.transform.position;
		dicePlayCam.transform.position = new Vector3(dicePos.x, 22.9f, dicePos.z + settingTest);
	}

	void AddForce(Vector3 lastPos){
        diceObj.GetComponent<Rigidbody>().AddTorque(Vector3.Cross(lastPos, initPos) * 1000, ForceMode.Impulse);
		lastPos.y += 5;
        diceObj.GetComponent<Rigidbody>().AddForce((lastPos - initPos).normalized * Vector3.Distance(lastPos, initPos) * 30 * diceObj.GetComponent<Rigidbody>().mass);
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(landingSoundEffect);
            //diceNum.SetText(Dice.instance.GetDiceCount().ToString());
            diceImg.sprite = Dice.instance.GetDiceSprite();

        }
	}

    private void ResetRigidBody()
    {
        diceObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        diceObj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
