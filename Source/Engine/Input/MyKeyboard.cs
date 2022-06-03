using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class MyKeyboard
    {

        private KeyboardState newKeyboard;
        private KeyboardState oldKeyboard;
        private List<MyKey> pressedKeys;
        private List<MyKey>  previousPressedKeys;

        public MyKeyboard()
        {
            pressedKeys = new List<MyKey>();
            previousPressedKeys = new List<MyKey>();
        }

        public virtual void Update()
        {
            newKeyboard = Keyboard.GetState();

            GetPressedKeys();

        }

        public void UpdateOld()
        {
            oldKeyboard = newKeyboard;

            previousPressedKeys = new List<MyKey>();
            for (int i = 0; i < pressedKeys.Count; i++)
            {
                previousPressedKeys.Add(pressedKeys[i]);
            }
        }


        public bool GetPress(string key)
        {

            for (int i = 0; i < pressedKeys.Count; i++)
            {

                if (pressedKeys[i].key == key)
                {
                    return true;
                }

            }

            return false;
        }
        public bool GetSinglePress(string key)
        {
            for (var i = 0; i < pressedKeys.Count; i++)
            {
                var isIn = false;
                for (var j = 0; j < previousPressedKeys.Count; j++)
                {
                    if (pressedKeys[i].key == previousPressedKeys[j].key)
                    {
                        isIn = true;
                        break;
                    }
                }
                if (!isIn && (pressedKeys[i].key == key || pressedKeys[i].print == key))
                    return true;
            }
            return false;
        }


        public virtual void GetPressedKeys()
        {
            pressedKeys.Clear();
            for (int i = 0; i < newKeyboard.GetPressedKeys().Length; i++)
            {

                pressedKeys.Add(new MyKey(newKeyboard.GetPressedKeys()[i].ToString(), 1));

            }
        }

    }
}
