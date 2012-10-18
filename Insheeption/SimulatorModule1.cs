using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;

namespace Insheeption 
{
    public class SimulatorModule
    {
        private List<Simulator> simulators;
        private Timer timer;

        public SimulatorModule(int period)
        {
            this.timer = new Timer();
            this.timer.Interval = period;
            this.timer.Elapsed += new ElapsedEventHandler(Tick);
        }

        public void Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (Simulator i in simulators)
                i.Tick();
        }
    }

    public abstract class Simulator
    {
        protected int tickLimit, tickCounter;
        protected Authentication rootUser;
        protected DatabaseModule databaseModule;
        protected DateTime lastTrigger;

        public Simulator(int triggerLimit, DatabaseModule databaseModule, Authentication rootUser)
        {
            this.databaseModule = databaseModule;
            this.tickLimit = triggerLimit;
            this.rootUser = rootUser;
            this.tickCounter = 0;
        }

        public void Tick()
        {
            tickCounter++;
            if (tickCounter >= tickLimit)
            {
                tickCounter = 0;
                Trigger();
            }
        }

        protected abstract void Trigger();

    }

    public class AlarmSimulator : Simulator
    {
        private int chancePerTick;

        public AlarmSimulator(int tickLimit, DatabaseModule databaseModule, Authentication rootUser)
            : base(tickLimit, databaseModule, rootUser)
        {
        }

        protected override void Trigger()
        {

        }
    }

    public class MotionSimulator : Simulator
    {
        private Position standardPosition;
        private int movement;
        public MotionSimulator(int triggerLimit, DatabaseModule databaseModule, Authentication rootUser, Position standardPosition, int movement)
            : base(triggerLimit, databaseModule, rootUser)
        {
            this.standardPosition = standardPosition;
            this.movement = movement;
        }

        protected override void Trigger()
        {
            DateTime temp;

            if (lastTrigger == null)
                temp = DateTime.Now.AddDays(-1);
            else
                temp = lastTrigger;

            lastTrigger = DateTime.Now;

            List<int> flockIDs = databaseModule.LoadAllFlockIDs(rootUser.FarmerID);

        }

        private void moveFlock(int flockID, DateTime startTime)
        {
            List<int> sheep = databaseModule.LoadAllSheepIDs(flockID);
            foreach (int sheepID in sheep)
                moveSheep(sheepID, startTime);
        }

        private void moveSheep(int sheepID, DateTime startTime)
        {
            List<Position> pos = databaseModule.LoadPositionLog(sheepID, startTime, DateTime.Now);
            Position last;
            last = pos.ElementAt(pos.Count - 1);
            if (last == null)
                databaseModule.StorePosition(sheepID, DateTime.Now, standardPosition);
            else
            {
                Random rnd = new Random();
                last.Latitude += rnd.Next(movement);
                last.Longitude += rnd.Next(movement);
                databaseModule.StorePosition(sheepID, DateTime.Now, last);
            }
        }
    }

}