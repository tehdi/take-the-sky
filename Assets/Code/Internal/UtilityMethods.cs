using System;
using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public static class UtilityMethods
    {
        private static readonly Color32 ACTIVE_BUTTON_COLOR = new Color32(92, 205, 253, 255);

        public static T RandomEnumValue<T>()
        {
            var enumValues = Enum.GetValues(typeof(T));
            return (T)enumValues.GetValue(new System.Random().Next(enumValues.Length));
        }

        public static void ChangeBackgroundColor(Toggle toggleButton)
        {
            if (toggleButton.isOn)
            {
                toggleButton.image.color = ACTIVE_BUTTON_COLOR;
            }
            else
            {
                toggleButton.image.color = Color.white;
            }
        }
    }
}
