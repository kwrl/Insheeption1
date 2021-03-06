﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Insheeption
{

    public class SheepService : ISheepService
    {
        private DatabaseModule databaseModule;
        private SimulatorModule simulatorModule;
        private AlarmModule alarmModule;

        public SheepService()
        {
            initAlarmModule();
            initDatabaseModule();
            initSimulatorModule();
        }

        private void initDatabaseModule()
        {

            string server, database, uid, password;
            server = "129.241.151.172";
            database = "IT1901";
            uid = "root";
            password = "herp";

            if (this.alarmModule == null)
                initAlarmModule();

            this.databaseModule = new DatabaseModule(this.alarmModule, server, database, uid, password);
        }

        private void initAlarmModule()
        {
            this.alarmModule = new AlarmModule();
        }

        //Metode for å teste mailtjenesten
        public Boolean testmail()
        {
            EmailAlarm epost = new EmailAlarm();
            return epost.sendMail();
        }

        private void initSimulatorModule()
        {
            //Intervall mellom hvert tick til simulatoren i ms
            int period = 1000;

            if(this.databaseModule==null)
                initDatabaseModule();

            this.simulatorModule = new SimulatorModule(period);
        }

        Flock ISheepService.LoadFlockByFlockID(int flockID, DateTime startTime, DateTime stopTime, string username, string password)
        {
            Authentication login = new Authentication(username, password);
            if (!databaseModule.NormalLogin(login))
                return null;

            return databaseModule.LoadFlockByFlockID(flockID, login.FarmerID, startTime, stopTime);
        }

        Flock ISheepService.LoadFlockBySheepID(int sheepID, DateTime startTime, DateTime stopTime, string username, string password)
        {
            Authentication login = new Authentication(username, password);
            if (!databaseModule.NormalLogin(login))
                return null;

            return databaseModule.LoadFlockBySheepID(sheepID, login.FarmerID, startTime, stopTime);
        }

        List<int> ISheepService.LoadAllFlockIDs(string username, string password)
        {

            Authentication login = new Authentication(username, password);

            if (!databaseModule.NormalLogin(login))
                return null;

            return databaseModule.LoadAllFlockIDs(login.FarmerID);
        }

        public bool NormalLogin(String brukernavn, String passord) 
        {
            return databaseModule.NormalLogin(new Authentication(brukernavn, passord));
        }

        List<HealthStatus> ISheepService.GetHealthLog(int sheepID, DateTime startTime, DateTime stopTime, string username, string password)
        {
            Authentication login = new Authentication(username, password);
            if (!databaseModule.NormalLogin(login))
                return null;

            return databaseModule.LoadHealthLog(sheepID, startTime, stopTime);
        }

        bool ISheepService.CreateNewUser(Authentication newUser, Authentication adminAuthentication)
        {
            throw new NotImplementedException();
        }
    }
}
