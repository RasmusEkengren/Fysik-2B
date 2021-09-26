using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public const float G = 6.7e-11f;
    //1 unity distance unit = 1000km = 1000000m
    public const int DistanceConversion = 1000000;

    public GameObject Earth;
    public float EarthMass;

    public GameObject Moon;
    public float MoonMass;
    public Vector3 StartVelocity;

    private Vector3 currentVelocity;

    public static float TimeScale;
    
    public static void ChangeTimeScale(float ts)
    {
        TimeScale = ts;
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
        currentVelocity = StartVelocity;
    }
    void FixedUpdate()
    {
        //f=m*a, a= f/m
        float acceleration = GetGravitationalForceInNewtons() / MoonMass;

        currentVelocity += (DirectionToEarth() * (acceleration * Time.fixedDeltaTime * TimeScale));
        Moon.transform.position += Time.fixedDeltaTime * TimeScale * currentVelocity / DistanceConversion;
    }
}
