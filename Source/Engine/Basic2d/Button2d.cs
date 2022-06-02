using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyGame1
{
    public class Button2d : Basic2d
    {
        public bool IsPressed, IsHovered;
        public string Text;
        public Color HoverColor;
        public SpriteFont Font;
        public object Info;
        PassObject ButtonClicked;

        public Button2d(string PATH, Vector2 POS, Vector2 DIMS, string FONTPATH, string TEXT, PassObject BUTTONCLICKED, object INFO) : base(PATH, POS, DIMS)
        {
            Text = TEXT;
            ButtonClicked = BUTTONCLICKED;
            Info = INFO;
            if (FONTPATH != "")
            {
                Font = Global.Content.Load<SpriteFont>(FONTPATH);
            }
            IsPressed = false;
            HoverColor = new Color(200,230,255);
        }

        public override void Update(Vector2 OFFSET)
        {
            if (Hover(OFFSET))
            {
                IsHovered = true;
                if (Global.Mouse.LeftClick())
                {
                    IsHovered = false;
                    IsPressed = true;
                }
                else if (Global.Mouse.LeftClickRelease())
                {
                    RunButtonClick();
                }
            }
            else
            {
                IsHovered = false;
            }

            if (!Global.Mouse.LeftClick() && !Global.Mouse.LeftClickHold())
            {
                IsPressed = false;
            }
            base.Update(OFFSET);
        }

        public virtual void Reset()
        {
            IsPressed = false;
            IsHovered = false;
        }

        public virtual void RunButtonClick()
        {
            if (ButtonClicked != null)
            {
                ButtonClicked(Info);
            }
            Reset();
        }

        /*public override void Draw(Vector2 OFFSET)
        {
            var tempColor = Color.White;
            if (isPressed)
                tempColor = Color.Gray;
            else if (isHovered)
                tempColor = hoverColor;

            //нарисовать ее надо 

            base.Draw(OFFSET);
            var strDims = font.MeasureString(text);
            Global._spriteBatch.DrawString(font, text, pos + OFFSET - strDims, Color.Black);
        }*/

        public override void Draw(Vector2 OFFSET)
        {
            var tempColor = Color.White;
            if (IsPressed)
                tempColor = Color.Gray;
            else if (IsHovered)
                tempColor = HoverColor;

            if (myModel != null)
                Global._spriteBatch.Draw(myModel,
                    new Rectangle((int)(Pos.X + OFFSET.X), (int)(Pos.Y + OFFSET.Y), (int)Dims.X, (int)Dims.Y),
                    null,
                    tempColor,
                    Rotate,
                    new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2),
                    new SpriteEffects(),
                    0);

            base.Draw(OFFSET);
            var strDims = Font.MeasureString(Text);
            Global._spriteBatch.DrawString(Font, Text, Pos + OFFSET - strDims, Color.Black);
        }
    }
}
