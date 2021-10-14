using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.flamingo.icecream.pumperstick
{
    public class PumperStick
    {
        public GameObject pumperStick;
        public GameObject button;

        public PumperStick( GameObject pumperStick, GameObject button)
        {
            this.pumperStick = pumperStick;
            this.button = button;
        }
    }

    
}