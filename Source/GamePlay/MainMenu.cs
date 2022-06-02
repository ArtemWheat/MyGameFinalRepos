/*using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
/**//*
namespace GameShooter
{
    public class MainMenu
    {
*//**//*
public Basic2d bkg;
public PassObject PlayClickDel, ExitClickDel;
public List<Button2d> buttons = new List<Button2d>();
public MainMenu(PassObject PLAYCLICKDEL, PassObject EXITCLICKDEL)
{
    PlayClickDel = PLAYCLICKDEL;
    ExitClickDel = EXITCLICKDEL;
    bkg = new Basic2d("MainMenu", new Vector2(Global.screenWidth / 2, Global.screenHeight / 2), new Vector2(Global.screenWidth, Global.screenHeight));
    buttons.Add(new Button2d("Button", Vector2.Zero, new Vector2(96, 32), "Font//Arial16", "Play", PlayClickDel, 1));
    buttons.Add(new Button2d("Button", Vector2.Zero, new Vector2(96, 32), "Font//Arial16", "Exit", ExitClickDel, null));
}


public virtual void Update()
{
    for (var i = 0; i < buttons.Count; i++)
    {
        buttons[i].Update(new Vector2(340, 560 + 45 * i));
    }
}

public virtual void Draw()
{
    bkg.Draw(Vector2.Zero);
    for (var i = 0; i < buttons.Count; i++)
    {
        buttons[i].Draw(new Vector2(340, 560 + 45 * i));
    }
}
    }
}*//**/
/**//**/