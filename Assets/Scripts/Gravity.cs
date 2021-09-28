using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
	public readonly struct DefaultValues
	{
		public const float StartPosX = 384.4f;
		public const float StartPosY = 0;
		public const float StartPosZ = 0;
		public const float StartVelX = 0;
		public const float StartVelY = -406.53f;
		public const float StartVelZ = 937.67f;
		public const float TimeScale = 1;
		public const double EarthMass = 5.9726e+24;
		public const double MoonMass = 7.342e+22;
	}

	public const float G = 6.7e-11f;
    //1 unity distance unit = 1000km = 1000000m
    public const int DistanceConversion = 1000000;

    public GameObject Earth;
    public float EarthMass;

    public GameObject Moon;
    public float MoonMass;
    public Vector3 StartVelocity;
    public Vector3 StartPosition;

    private bool isCalculatingGravitationalForce = true;

    public Vector3 CurrentVelocity { get; private set; }

    public static float TimeScale;
    
    public static void ChangeTimeScale(float ts)
    {
        TimeScale = ts;
    }
    public void ToggleGravitationalForce()
    {
        isCalculatingGravitationalForce = !isCalculatingGravitationalForce;
    }
    public void ResetMoon()
    {
		CurrentVelocity = StartVelocity;
        transform.position = StartPosition;
        isCalculatingGravitationalForce = true;
        TrailRenderer trail = GetComponent<TrailRenderer>();
        trail.Clear();
    }
    public float GetDistanceInMeters()
    {
        return (Earth.transform.position - Moon.transform.position).magnitude * DistanceConversion;
    }
    public float GetGravitationalForceInNewtons()
    {
        float radius = GetDistanceInMeters();
        return G * (EarthMass * MoonMass / (radius * radius));
    }
    public Vector3 DirectionToEarth()
    {
        return (Earth.transform.position - Moon.transform.position).normalized;
    }
    private void Start()
    {
		CurrentVelocity = StartVelocity;
    }
    void FixedUpdate()
    {
        if (isCalculatingGravitationalForce)
        {
            float acceleration = GetGravitationalForceInNewtons() / MoonMass;
			CurrentVelocity += (DirectionToEarth() * (acceleration * Time.fixedDeltaTime * TimeScale));
        }
        Moon.transform.position += Time.fixedDeltaTime * TimeScale * CurrentVelocity / DistanceConversion;
    }
}