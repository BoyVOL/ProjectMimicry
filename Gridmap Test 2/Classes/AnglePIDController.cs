using System;
using Godot;

public class QPID
{
    public float P;
    public float I;
    public float D;

    public float Scale = 1;

    Vector3 _PrevError = Vector3.Zero;
    Vector3 _ErrorIntegral = Vector3.Zero;

    public QPID(){
        P = 1;
        I = 1;
        D = 1;
    }

    public QPID(float p, float i, float d)
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
    public Vector3 newVector(Quaternion Current,Quaternion Desired, float delta)
    {
        Quaternion _QError = (Desired*Current.Inverse()).Normalized();
        if(_QError.W < 0) _QError = -_QError;
        Vector3 Axis = _QError.GetAxis().Normalized();
        GD.Print(Axis);
        double Angle =  _QError.GetAngle();
        GD.Print(Angle);
        Vector3 _Error = Axis * (float)Angle*Scale;
        _ErrorIntegral += _Error*delta;
        Vector3 ErrorD = (_Error - _PrevError)/delta;
        _PrevError = _Error;
        return P*_Error+I*_ErrorIntegral+D*ErrorD;
    }
}