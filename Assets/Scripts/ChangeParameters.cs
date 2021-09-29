using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeParameters : MonoBehaviour
{
	public readonly struct DefaultValues
	{
		public const float StartPosX = 384.4f;
		public const float StartPosY = 0;
		public const float StartPosZ = 0;
		public const float StartVelX = 0;
		public const float StartVelY = -406.53f;
		public const float StartVelZ = 937.67f;
		public const float EarthMass = 5.9726e+24f;
		public const float MoonMass = 7.342e+22f;
	}
	public Gravity gravity;
	public InputField posXInput;
	public InputField posYInput;
	public InputField posZInput;
	public InputField velXInput;
	public InputField velYInput;
	public InputField velZInput;
	public InputField earthMassInput;
	public InputField moonMassInput;

	private void Start()
	{
		System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
		posXInput.text = gravity.StartPosition.x.ToString();
		posYInput.text = gravity.StartPosition.y.ToString();
		posZInput.text = gravity.StartPosition.z.ToString();
		velXInput.text = gravity.StartVelocity.x.ToString();
		velYInput.text = gravity.StartVelocity.y.ToString();
		velZInput.text = gravity.StartVelocity.z.ToString();
		earthMassInput.text = gravity.EarthMass.ToString();
		moonMassInput.text = gravity.MoonMass.ToString();
	}
	public void ResetToDefault()
	{
		gravity.StartPosition = new Vector3(DefaultValues.StartPosX, DefaultValues.StartPosY, DefaultValues.StartPosZ);
		gravity.StartVelocity = new Vector3(DefaultValues.StartVelX, DefaultValues.StartVelY, DefaultValues.StartVelZ);
		gravity.isCalculatingGravitationalForce = true;
		gravity.EarthMass = DefaultValues.EarthMass;
		gravity.MoonMass = DefaultValues.MoonMass;
		posXInput.text = gravity.StartPosition.x.ToString();
		posYInput.text = gravity.StartPosition.y.ToString();
		posZInput.text = gravity.StartPosition.z.ToString();
		velXInput.text = gravity.StartVelocity.x.ToString();
		velYInput.text = gravity.StartVelocity.y.ToString();
		velZInput.text = gravity.StartVelocity.z.ToString();
		earthMassInput.text = gravity.EarthMass.ToString();
		moonMassInput.text = gravity.MoonMass.ToString();
	}
	public void ChangePosX()
	{
		if (posXInput != null)
		{
			if (posXInput.text != null)
			{
				gravity.StartPosition.x = float.Parse(posXInput.text);
			}
		}
	}
	public void ChangePosY()
	{
		if (posYInput != null)
		{
			if (posYInput.text != null)
			{
				gravity.StartPosition.y = float.Parse(posYInput.text);
			}
		}
	}
	public void ChangePosZ()
	{
		if (posZInput != null)
		{
			if (posZInput.text != null)
			{
				gravity.StartPosition.z = float.Parse(posZInput.text);
			}
		}
	}
	public void ChangeVelX()
	{
		if (velXInput != null)
		{
			if (velXInput.text != null)
			{
				gravity.StartVelocity.x = float.Parse(velXInput.text);
			}
		}
	}
	public void ChangeVelY()
	{
		if (velYInput != null)
		{
			if (velYInput.text != null)
			{
				gravity.StartVelocity.y = float.Parse(velYInput.text);
			}
		}
	}
	public void ChangeVelZ()
	{
		if (velZInput != null)
		{
			if (velZInput.text != null)
			{
				gravity.StartVelocity.z = float.Parse(velZInput.text);
			}
		}
	}
	public void ChangeEarthMass()
	{
		if (earthMassInput != null)
		{
			if (earthMassInput.text != null)
			{
				gravity.EarthMass = float.Parse(earthMassInput.text);
			}
		}
	}
	public void ChangeMoonMass()
	{
		if (moonMassInput != null)
		{
			if (moonMassInput.text != null)
			{
				gravity.MoonMass = float.Parse(moonMassInput.text);
			}
		}
	}
}
