using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4_2
{
    public class Time //时间类
    {
        private int hour;
        private int min;
        private int sec;
        public int Hour
        {
            get => hour;
            set => hour = (value >= 0 && value < 24) ? value : 0;
        }
        public int Min
        {
            get => min;
            set => min = (value >= 0 && value < 60) ? value : 0;
        }
        public int Sec
        {
            get => sec;
            set => sec = (value >= 0 && value < 60) ? value : 0;
        }
        public Time(int hour, int min, int sec)
        {
            Hour = hour;
            Min = min;
            Sec = sec;
        }
        public void Add() //时间前进一秒
        {
            Sec++;
            if (Sec == 0)
            {
                Min++;
                if (Min == 0)
                {
                    Hour++;
                }
            }
        }
        public override string ToString() //转为字符串
        {
            return $"{Hour}:{Min}:{Sec}";
        }
        public int ToInt() //转为整型
        {
            return Sec + Min * 60 + Hour * 60 * 60;
        }
    }

    public class AlarmClock //闹钟类
    {
        public event Action<object, Time> Tick;   //滴答事件
        public event Action<object, Time> Alarm; //响铃事件
        public Time CurrentTime { get; set; } //当前时刻
        public Time AlarmTime { get; set; }   //响铃时刻
        public Time AlarmLength { get; set; } //响铃时间长度

        public AlarmClock(Time currentTime, Time alarmTime, Time alarmLength)
        {
            CurrentTime = currentTime;
            AlarmTime = alarmTime;
            AlarmLength = alarmLength;
        }
        public void GoTick()
        {
            Tick(this, CurrentTime);
        }
        public void GoAlarm()
        {
            Alarm(this, CurrentTime);
        }
    }

    public class Program
    {
        public static void MethodTick(object sender, Time currentTime)
        {
            Console.WriteLine(currentTime.ToString() + "\tTick");
            currentTime.Add();
        }
        public static void MethodAlarm(object sender, Time currentTime)
        {
            Console.WriteLine(currentTime.ToString() + "\tAlarm! Alarm! Alarm! Alarm! Alarm!");
            currentTime.Add();
        }
        static void Main(string[] args)
        {
            AlarmClock clock = new AlarmClock(new Time(7, 59, 50), new Time(8, 0, 0), new Time(0, 0, 10));
            clock.Tick += MethodTick;
            clock.Alarm += MethodAlarm;

            //在适当时间范围内测试
            int testTime = (clock.AlarmTime.ToInt() - clock.CurrentTime.ToInt() + 24 * 60 * 60) % (24 * 60 * 60)
                + clock.AlarmLength.ToInt() + 5;
            for (int i = 0; i < testTime; i++)
            {
                if (clock.CurrentTime.ToInt() >= clock.AlarmTime.ToInt()
                    && clock.CurrentTime.ToInt() <= clock.AlarmTime.ToInt() + clock.AlarmLength.ToInt())
                    clock.GoAlarm();
                else
                    clock.GoTick();

                Thread.Sleep(1000);
            }
        }
    }
}
