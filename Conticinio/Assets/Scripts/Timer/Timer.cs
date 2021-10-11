using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimerCloack
{
    public class TimerMethod
    {

        public float passTime;

        public bool Timer(float f)
        {

            passTime += Time.deltaTime;

            bool _changeState = (passTime >= f) ? true : false;

            return _changeState;
        }
    }
}
