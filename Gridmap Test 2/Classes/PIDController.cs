using Godot;
using System;

/// <summary>
/// Class implementing PID controller functional for Vector3
/// </summary>
public class V3PID
{
    public float P;
    public float I;
    public float D;

    Vector3 _PrevError = Vector3.Zero;
    Vector3 _ErrorIntegral = Vector3.Zero;

    public V3PID(){
        P = 1;
        I = 1;
        D = 1;
    }

    public V3PID(float p, float i, float d)
    {
        P=p;
        I=i;
        D=d;
    }

    /// <summary>
    /// Resets all error values
    /// </summary>
    public void Reset()
    {
        _PrevError = Vector3.Zero;
        _ErrorIntegral = Vector3.Zero;
    }

    /// <summary>
    /// Generates new vector based on existing error, prev errors and delta
    /// </summary>
    /// <param name="error">difference between actual vector and target vector</param>
    /// <param name="delta">Time interval</param>
    public Vector3 newVector(Vector3 error, float delta)
    {
        _ErrorIntegral += error*delta;
        Vector3 ErrorD = (error - _PrevError)/delta;
        _PrevError = error;
        return P*error+I*_ErrorIntegral+D*ErrorD;
    }
}