using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
	public GameObject objectToToggle;
    public void Toggle()
	{
		objectToToggle.SetActive(!objectToToggle.activeSelf);
	}
}
