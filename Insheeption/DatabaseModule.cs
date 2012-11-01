using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Insheeption
{
    public class DatabaseModule
    {
        private readonly AlarmModule alarmModule;
        private string server, database, uid, password;
        private readonly MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;

        public DatabaseModule(AlarmModule alarmModule, string server, string database, string uid, string password)
        {
            this.alarmModule = alarmModule;
            this.server = server;
            this.database = database;
            this.uid = uid;
            this.password = password;


            string connectLine = "SERVER=" + server + ";" +
                                 "DATABASE=" + database + ";" +
                                 "UID=" + uid + ";" +
                                 "PASSWORD=" + password + ";";


            connection = new MySqlConnection(connectLine);
            connection.Open();
        }

        public Flock LoadFlockByFlockID(int flockID, int farmerID, DateTime startTime, DateTime stopTime)
        {
            if (!LoadAllFlockIDs(farmerID).Contains(flockID))
                return null;

            var flokk = new Flock(flockID);
            List<int> sheepIDs = LoadAllSheepIDs(flockID);
            foreach (int sheepID in sheepIDs)
                flokk.AddSheep(LoadSheep(sheepID, startTime, stopTime));

            return flokk;
        }

        // Hva skal vi med start- og stopTime her?

        public int GetFlockIDbySheepID(int sheepID)
        {
            int flockID = 0;
            command = connection.CreateCommand();
            command.CommandText = "SELECT flokkID FROM Sauer WHERE sauID='" + sheepID + "';";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                IDataRecord record = reader;
                flockID = int.Parse("" + record);
            }
            return flockID;
        }

        public Flock LoadFlockBySheepID(int sheepID, int farmerID, DateTime startTime, DateTime stopTime)
        {
            int flockID = GetFlockIDbySheepID(sheepID);
            return LoadFlockByFlockID(flockID, farmerID, startTime, stopTime);
        }

        // TODO: Klassen som kaller på CreateNewUser må sjekke om epost og passord  er VARCHAR(50)
        public bool CreateNewUser(string epost, string password)
        {
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO login (epost, passord) VALUES ('" + epost + "','" + password + "')";
            reader = command.ExecuteReader();
            return true;
        }

        public bool NormalLogin(Authentication authentication)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT BondeID FROM login WHERE epost='" + authentication.Username + "' && passord='" +
                                  authentication.Password + "';";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                IDataReader record = reader;
                authentication.FarmerID = int.Parse("" + record[0]);
            }
            reader.Close();

            return authentication.FarmerID != -1;
        }

        public Authentication AdminLogin(Authentication adminAuthentication)
        {
            throw new NotImplementedException();
        }

        public List<int> LoadAllFlockIDs(int farmerID)
        {
            var flockIDs = new List<int>();
            command = connection.CreateCommand();
            command.CommandText = "SELECT flokkID FROM Saueflokk WHERE BondeID='" + farmerID + "';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                IDataRecord record = reader;
                flockIDs.Add(int.Parse("" + record[0]));
            }

            reader.Close(); 
            return flockIDs;
        }

        public List<int> LoadAllSheepIDs(int flockID)
        {
            IT1901Entities1 db = new IT1901Entities1();
            List<int> sheepIDs = db.Sauer.Create<int>();
            return sheepIDs;
        }

        // Parameterløs versjon av metoden over - for å kunne hente ut alle sauer til simulatoren
        public List<int> LoadAllSheepIDs()
        {
            var sheepIDs = new List<int>();
            command = connection.CreateCommand();
            command.CommandText = "SELECT SauID FROM Sauer";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                IDataRecord record = reader;
                sheepIDs.Add(int.Parse("" + record[0]));
            }
            return sheepIDs;
        }


        // Konstruerer et saueobjekt
        public Sheep LoadSheep(int sheepID, DateTime startTime, DateTime stopTime)
        {
            List<HealthStatus> healthLog = LoadHealthLog(sheepID, startTime, stopTime);
            List<Position> positionLog = LoadPositionLog(sheepID, startTime, stopTime);
            var newSheep = new Sheep(sheepID, healthLog, positionLog);
            return newSheep;
        }

        public string dayTimeFormat(DateTime time)
        {
            return String.Format("{0:YYYY-MM-DD HH:mm:ss}", time);
        }

        // Denne skal kalles når man ønsker å sette helsestatus
        public void SetHealth(int sheepID, HealthStatus healthStatus)
        {
            int alarm;
            if (healthStatus.Alarm)
            {
                alarm = 1;
                alarmModule.CallAlarms(sheepID, this);
            }
            else alarm = 0;

            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Helse (tid, hjerteslag, temperatur, alarm) VALUES ('" +
                                  dayTimeFormat(healthStatus.Time) + "','" + healthStatus.Pulse + "','" +
                                  healthStatus.temperature + "','" + alarm + "');";
            reader = command.ExecuteReader();
        }

        public List<HealthStatus> LoadHealthLog(int sheepID, DateTime startTime, DateTime stoptime)
        {
            throw new NotImplementedException();
        }

        public List<Position> LoadPositionLog(int sheepID, DateTime startTime, DateTime stopTime)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Posisjon WHERE tid ";
            throw new NotImplementedException();
        }

        public HealthStatus loadLastHealthStatus(int sheepID)
        {
            throw new NotImplementedException();
        }

        public Position loadLastPosition(int sheepID)
        {
            throw new NotImplementedException();
        }

        public void StorePosition(int sheepID, DateTime tid, Position standardPos)
        {
            throw new NotImplementedException();
        }
    }
}