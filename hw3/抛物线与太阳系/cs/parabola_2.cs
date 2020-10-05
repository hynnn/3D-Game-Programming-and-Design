using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parabola_2 : MonoBehaviour
{
	private GameObject MySphere;
	private Vector3 speed;
    private Vector3 g;
    // Start is called before the first frame update
    void Start()
    {
        MySphere = GameObject.Find("Sphere");
		speed = new Vector3(10f, 0f, 0f);
        g = new Vector3(0f, -9.8f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        speed += g * Time.deltaTime * 0.5f;
        MySphere.transform.position += speed * Time.deltaTime;
    }
}
