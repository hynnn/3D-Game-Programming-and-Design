using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parabola_1 : MonoBehaviour
{
	private GameObject MySphere;
	 private float x;
     private float y;
     private float g;
    // Start is called before the first frame update
    void Start()
    {
		MySphere = GameObject.Find("Sphere");
        x = 10f;
        y = 0f;
        g = 9.8f;
    }

    // Update is called once per frame
    void Update()
    {
        y += g * Time.deltaTime * 0.5f;
        MySphere.transform.position += Vector3.right * Time.deltaTime * x;
        MySphere.transform.position += Vector3.down * Time.deltaTime * y;
    }
}
