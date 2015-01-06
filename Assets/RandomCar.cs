using UnityEngine;
using System.Collections;

public class RandomCar : MonoBehaviour 
{
    float mSpeed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        mSpeed = (float)Random.RandomRange(0.0f, 5.0f);

        transform.position += transform.forward * mSpeed * 0.01f;
	}
}
