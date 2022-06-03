using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyGame1
{
    public class MyMouseControl
    {
        public Vector2 newMousePos { get; set; }
        public MouseState newMouse { get; set; }
        public MouseState oldMouse { get; set; }
        public MouseState firstMouse { get; set; }

        private Vector2 firstMousePos;
        private Vector2 oldMousePos;

        public MyMouseControl()
        {
            newMouse = Mouse.GetState();
            oldMouse = newMouse;
            firstMouse = newMouse;

            newMousePos = new Vector2(newMouse.Position.X, newMouse.Position.Y);
            oldMousePos = new Vector2(newMouse.Position.X, newMouse.Position.Y);
            firstMousePos = new Vector2(newMouse.Position.X, newMouse.Position.Y);

            GetMouseAndAdjust();
        }


        public void Update()
        {
            GetMouseAndAdjust();
            if(newMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed
                && oldMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                firstMouse = newMouse;
                firstMousePos = newMousePos = GetScreenPos(firstMouse);
            }
        }

        public void UpdateOld()
        {
            oldMouse = newMouse;
            oldMousePos = GetScreenPos(oldMouse);
        }

        public virtual float GetDistanceFromClick() => Global.GetDistance(newMousePos, firstMousePos);

        public virtual void GetMouseAndAdjust()
        {
            newMouse = Mouse.GetState();
            newMousePos = GetScreenPos(newMouse);
        }

        public int GetMouseWheelChange() => newMouse.ScrollWheelValue - oldMouse.ScrollWheelValue;


        public Vector2 GetScreenPos(MouseState MOUSE) => new Vector2(MOUSE.Position.X, MOUSE.Position.Y);

        public virtual bool LeftClick()
        {
            if( newMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed 
                && oldMouse.LeftButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed
                && newMouse.Position.X >= 0 && newMouse.Position.X <= Global.ScreenWidth
                && newMouse.Position.Y >= 0 && newMouse.Position.Y <= Global.ScreenHeight)
                return true;

            return false;
        }

        public virtual bool LeftClickHold()
        {
            bool holding = false;

            if( newMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed 
                && oldMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed 
                && newMouse.Position.X >= 0 && newMouse.Position.X <= Global.ScreenWidth 
                && newMouse.Position.Y >= 0 && newMouse.Position.Y <= Global.ScreenHeight)
                holding = true;



            return holding;
        }

        public virtual bool LeftClickRelease()
        {
            if(newMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released 
                && oldMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                return true;

            return false;
        }

        public virtual bool RightClick()
        {
            if(newMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed 
                && oldMouse.RightButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed 
                && newMouse.Position.X >= 0 && newMouse.Position.X <= Global.ScreenWidth 
                && newMouse.Position.Y >= 0 && newMouse.Position.Y <= Global.ScreenHeight)
                return true;

            return false;
        }

        public virtual bool RightClickHold()
        {
            bool holding = false;

            if( newMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed
                && oldMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed
                && newMouse.Position.X >= 0 && newMouse.Position.X <= Global.ScreenWidth
                && newMouse.Position.Y >= 0 && newMouse.Position.Y <= Global.ScreenHeight)
                holding = true;



            return holding;
        }

        public virtual bool RightClickRelease()
        {
            if( newMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Released 
                && oldMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                return true;

            return false;
        }

        public void SetFirst()
        {

        }
    }
}
