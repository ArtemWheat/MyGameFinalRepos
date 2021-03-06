using System;
using System.Xml.Linq;

namespace MyGame1
{
    public class MyTimer
    {
        private bool goodToGo;
        private int mSec;
        private TimeSpan timer;
        

        public MyTimer(int m)
        {
            goodToGo = false;
            mSec = m;
            timer = new TimeSpan();
        }
        public MyTimer(int m, bool startLoader)
        {
            goodToGo = startLoader;
            mSec = m;
        }

        public int MSec
        {
            get => mSec;
            set { mSec = value; }
        }
        public int Timer{ get => (int)timer.TotalMilliseconds; }

        public void UpdateTimer()
        {
            timer += Global.GameTime.ElapsedGameTime;
        }

        public void UpdateTimer(float speed)
        {
            timer += TimeSpan.FromTicks((long)(Global.GameTime.ElapsedGameTime.Ticks * speed));
        }

        public void AddToTimer(int msec)
        {
            timer += TimeSpan.FromMilliseconds((long)(msec));
        }

        public bool Test()
        {
            if(timer.TotalMilliseconds >= mSec || goodToGo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            timer = timer.Subtract(new TimeSpan(0, 0, mSec/60000, mSec/1000, mSec%1000));
            if(timer.TotalMilliseconds < 0)
            {
                timer = TimeSpan.Zero;
            }
            goodToGo = false;
        }

        public void Reset(int newTimer)
        {
            timer = TimeSpan.Zero;
            MSec = newTimer;
            goodToGo = false;
        }

        public void ResetToZero()
        {
            timer = TimeSpan.Zero;
            goodToGo = false;
        }

        public XElement ReturnXML()
        {
            XElement xml= new XElement("Timer",
                                    new XElement("mSec", mSec),
                                    new XElement("timer", Timer));



            return xml;
        }

        public void SetTimer(TimeSpan time)
        {
            timer = time;
        }

        public void SetTimer(int msec)
        {
            timer = TimeSpan.FromMilliseconds((long)(msec));
        }
    }
}
