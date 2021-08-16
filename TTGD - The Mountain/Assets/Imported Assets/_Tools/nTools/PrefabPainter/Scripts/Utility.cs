
#if (UNITY_EDITOR)

using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace nTools.PrefabPainter
{

 
    public static class Utility
    {

        public static bool IsVector2Equal (Vector2 a, Vector2 b, float epsilon = 0.001f)
        {
            return Mathf.Abs (a.x - b.x) < epsilon && Mathf.Abs (a.y - b.y) < epsilon;
        }

        public static bool IsVector3Equal (Vector3 a, Vector3 b, float epsilon = 0.001f)
        {            
            return Mathf.Abs (a.x - b.x) < epsilon && Mathf.Abs (a.y - b.y) < epsilon && Mathf.Abs (a.z - b.z) < epsilon;
        }

        public static Vector3 RoundVector(Vector3 v, int digits)
        {
            return new Vector3((float)Math.Round(v.x, digits), (float)Math.Round(v.y, digits), (float)Math.Round(v.z, digits));
        }

        public static float Round(float v, int digits)
        {
            return (float)Math.Round(v, digits);
        }


    } // class Utility




} // namespace 

#endif // (UNITY_EDITOR)

