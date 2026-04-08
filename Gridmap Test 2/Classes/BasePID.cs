using System;
using Godot;

namespace PID
{
    public class BasePID
    {
        public float P;
        public float I;
        public float D;

        public float Scale = 1;

        protected Vector3 _PrevError = Vector3.Zero;
        protected Vector3 _ErrorIntegral = Vector3.Zero;

        
        public BasePID(){
            P = 1;
            I = 1;
            D = 1;
        }

        public BasePID(float p, float i, float d)
        {
            P=p;
            I=i;
            D=d;
        }
    }
}