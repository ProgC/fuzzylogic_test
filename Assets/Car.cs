using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour 
{
    public GameObject mCarFront;

    public float mSpeed = 0;
    
    public double close;
    public double mid;
    public double far;

    public double slow;
    public double stop;
    public double fast;

    public double decelerate;
    public double keep;
    public double accel;

    public double angleLeft;
    public double angleMid;
    public double angleRight;

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    // distance
        double distToCar = Vector3.Distance(mCarFront.transform.position, transform.position);
                
        Vector3 carPosInLocal = transform.InverseTransformPoint(mCarFront.transform.position);
        double targetAngle = Mathf.Atan2(carPosInLocal.x, carPosInLocal.z) * Mathf.Rad2Deg;        
        double angleToCar = targetAngle;
        
        angleLeft = Fuzzy.FuzzyReverseGrade(angleToCar, -45, -25);
        angleMid = Fuzzy.FuzzyTriangle(angleToCar, -45, 0, 45);
        angleRight = Fuzzy.FuzzyGrade(angleToCar, 25, 45);
        
        close = Fuzzy.FuzzyReverseGrade(distToCar, 0, 2);
        mid = Fuzzy.FuzzyTriangle(distToCar, 1, 3, 5);
        far = Fuzzy.FuzzyGrade(distToCar, 4, 6);

        slow = Fuzzy.FuzzyReverseGrade(mSpeed, -2, -0.7);
        stop = Fuzzy.FuzzyTriangle(mSpeed, -1, 0, 1);
        fast = Fuzzy.FuzzyGrade(mSpeed, 0.7, 2);

        decelerate = Fuzzy.OR(Fuzzy.OR(Fuzzy.AND(slow, close), Fuzzy.AND(stop, close)), Fuzzy.AND(fast, close));
        keep = Fuzzy.OR(Fuzzy.OR(Fuzzy.AND(slow, mid), Fuzzy.AND(fast, mid)), Fuzzy.AND(fast, far));
        accel = Fuzzy.OR(Fuzzy.OR(Fuzzy.AND(slow, far), Fuzzy.AND(stop, mid)), Fuzzy.AND(stop, far));

        double deploy = (decelerate * -20 + keep * 0 + accel * 10) / (decelerate + keep + accel);
        mSpeed = (float)deploy;

        if (keep > accel || keep > decelerate)
            mSpeed = 0;

        if (angleLeft > angleMid && angleLeft > angleRight)
            transform.Rotate(Vector3.up, -1);
        else if (angleRight > angleMid && angleRight > angleLeft)
            transform.Rotate(Vector3.up, 1);
        else
        {
            // keep mid
        }

        transform.position += transform.forward * mSpeed * 0.01f;
	}
}
