using System;
using Godot;

namespace PID
{
    public class QPID : BaseV3PID{

    
        public QPID() : base()
        {
            
        }
    public QPID(float p, float i, float d): base(p, i, d)
        {
            
        }

    /// <summary>
    /// Resets all error values
    /// </summary>
    public void Reset()
    {
        _PrevError = Vector3.Zero;
        _ErrorIntegral = Vector3.Zero;
    }

    Vector3 UpdateWithError(Vector3 _Error,float delta)
    {
        _ErrorIntegral += _Error*delta;
        Vector3 ErrorD = (_Error - _PrevError)/delta;
        _PrevError = _Error;
        return P*_Error+I*_ErrorIntegral+D*ErrorD;
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
        double Angle =  _QError.GetAngle();
        Vector3 _Error = Axis * (float)Angle*Scale;
        return UpdateWithError(_Error,delta);
    }
}
}