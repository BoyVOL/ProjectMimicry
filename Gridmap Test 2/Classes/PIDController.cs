using Godot;
using System;

namespace PID
{
    /// <summary>
    /// Class implementing PID controller functional for Vector3
    /// </summary>
    public class V3PID : BasePID
    {
    
        public V3PID() : base()
        {
            
        }

        public V3PID(float p, float i, float d):base(p, i, d)
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

        /// <summary>
        /// Generates new vector based on existing error, prev errors and delta
        /// </summary>
        /// <param name="error">difference between actual vector and target vector</param>
        /// <param name="delta">Time interval</param>
        public Vector3 newVector(Vector3 Current, Vector3 Desired, float delta)
        {
            Vector3 _Error = Desired-Current*Scale;
            _ErrorIntegral += _Error*delta;
            Vector3 ErrorD = (_Error - _PrevError)/delta;
            _PrevError = _Error;
            return P*_Error+I*_ErrorIntegral+D*ErrorD;
        }
    }
}