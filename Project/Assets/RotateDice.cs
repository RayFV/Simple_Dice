using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDice : MonoBehaviour
{

	private Vector3 randomHonrizonal;
	private Vector3 randomVectical;
    // Update is called once per frame
	private void Start() {
		if(Random.Range(1, 3) == 1){
			randomHonrizonal = Vector3.right;
		}else{
			randomHonrizonal = Vector3.left;
		}

		if(Random.Range(1, 3) == 1){
			randomVectical = Vector3.down;
		}else{
			
			randomVectical = Vector3.up;
		}
	}

    void Update()
    {
        gameObject.transform.Rotate(randomHonrizonal + randomVectical);
    }
}
