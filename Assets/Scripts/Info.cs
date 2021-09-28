using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
	public Gravity gravity;
	public Text infoPanel;

    void LateUpdate()
    {
		infoPanel.text = "Speed: " + (gravity.CurrentVelocity.magnitude * 1000) + "km/s\r\n" +
						 "Force: " + gravity.GetGravitationalForceInNewtons() + "N\r\n" +
						 "Distance: " + gravity.GetDistanceInMeters() + "m";
    }
}
