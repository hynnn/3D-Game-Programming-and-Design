using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolution : MonoBehaviour
{
	public Transform Sun;
    public Transform Mercury;
    public Transform Venus;
    public Transform Earth;
    public Transform Mars;
    public Transform Jupiter;
    public Transform Saturn;
    public Transform Uranus;
    public Transform Neptune;
 
	public Vector3 axis1;
    public Vector3 axis2;
    public Vector3 axis3;
    public Vector3 axis4;
    public Vector3 axis5;
    public Vector3 axis6;
    public Vector3 axis7;
    public Vector3 axis8;
    // Start is called before the first frame update
    void Start()
    {
		Sun = GameObject.Find("Sun").transform;
        Mercury = GameObject.Find("Mercury").transform;
        Venus = GameObject.Find("Venus").transform;
        Earth = GameObject.Find("Earth").transform;
        Mars = GameObject.Find("Mars").transform;
        Jupiter = GameObject.Find("Jupiter").transform;
        Saturn = GameObject.Find("Saturn").transform;
        Uranus = GameObject.Find("Uranus").transform;
        Neptune = GameObject.Find("Neptune").transform;

        axis1 = new Vector3(1, 4, 0);
        axis2 = new Vector3(1, 3, 0);
        axis3 = new Vector3(1, 2, 0);
        axis4 = new Vector3(1, 1, 0);
        axis5 = new Vector3(5, 1, 0);
        axis6 = new Vector3(2, 1, 0);
        axis7 = new Vector3(3, 1, 0);
        axis8 = new Vector3(4, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Sun.Rotate(Vector3.up * 10 * Time.deltaTime);
        
        Mercury.RotateAround(Sun.position, axis1, 47 * Time.deltaTime);
        Mercury.Rotate(Vector3.up * 50 * Time.deltaTime);

        Venus.RotateAround(Sun.position, axis2, 35 * Time.deltaTime);
        Venus.Rotate(Vector3.up * 30 * Time.deltaTime);

        Earth.RotateAround(Sun.position, axis3, 10 * Time.deltaTime);
        Earth.Rotate(Vector3.up * 30 * Time.deltaTime);

        Mars.RotateAround(Sun.position, axis4, 24 * Time.deltaTime);
        Mars.Rotate(Vector3.up * 30 * Time.deltaTime);

        Jupiter.RotateAround(Sun.position, axis5, 13 * Time.deltaTime);
        Jupiter.Rotate(Vector3.up * 30 * Time.deltaTime);

        Saturn.RotateAround(Sun.position, axis6, 9 * Time.deltaTime);
        Saturn.Rotate(Vector3.up * 30 * Time.deltaTime);

        Uranus.RotateAround(Sun.position, axis7, 6 * Time.deltaTime);
        Uranus.Rotate(Vector3.up * 30 * Time.deltaTime);

        Neptune.RotateAround(Sun.position, axis8, 5 * Time.deltaTime);
        Neptune.Rotate(Vector3.up * 30 * Time.deltaTime);
    }
}
