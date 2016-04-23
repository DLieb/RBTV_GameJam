using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestInput : MonoBehaviour
{
    public Text outputText;
	// Use this for initialization
	void Start ()
	{
	    string[] Joysticks = Input.GetJoystickNames();
	    for(int i = 0; i < Joysticks.Length; i++)
	    {
	        outputText.text = outputText.text + Joysticks[i];
	    }
           

	}
	
	// Update is called once per frame
	void Update ()
    {

            if (Input.GetButtonDown("Joy1Fire1"))
            {
                outputText.text = "Input Fire1 Controller 1";
            }
            if (Input.GetButtonDown("Joy2Fire1"))
            {
            outputText.text = "Input Fire1 Controller 2";
            }
            if (Input.GetButtonDown("Joy1Jump"))
            {
                outputText.text = "Input Jump1 Controller 1";
            }
            if (Input.GetButtonDown("Joy2Jump"))
            {
             outputText.text = "Input Jump1 Controller 2";
            }
	    /*if (Mathf.Abs(Input.GetAxis("Joy1HorizontalController"))>0)
	    {
            outputText.text = "Input Horizontal Controller 1";
        }
        if (Mathf.Abs(Input.GetAxis("Joy2HorizontalController")) > 0)
        {
            outputText.text = "Input Horizontal Controller 2";
        }
        if (Mathf.Abs(Input.GetAxis("Joy1VerticalController")) > 0)
        {
            outputText.text = "Input Vertical Controller 1";
        }
        if (Mathf.Abs(Input.GetAxis("Joy2VerticalController")) > 0)
        {
            outputText.text = "Input Vertical Controller 2";
        }*/


    }
}
