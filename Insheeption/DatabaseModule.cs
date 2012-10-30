﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data.Odbc;
using System.Data;

namespace Insheeption
{

    public class DatabaseModule
    {
        private AlarmModule alarmModule;
        private string server, database, uid, password;
        private MySqlConnection connection;
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


            return null;
        }

        // Hva skal vi med start- og stopTime her?
        public Flock LoadFlockBySheepID(int sheepID, int farmerID, DateTime startTime, DateTime stopTime)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT 
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
            command.CommandText = "SELECT BondeID FROM login WHERE epost='" + authentication.Username + "' && passord='" + authentication.Password + "';";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                IDataReader record = (IDataReader)reader;
                authentication.FarmerID = int.Parse("" + record[0]);
            }
            reader.Close();

            return authentication.FarmerID!=null;
        }

        public Authentication AdminLogin(Authentication adminAuthentication)
        {
            throw new NotImplementedException();
        }

        public List<int> LoadAllFlockIDs(int farmerID)
        {
            List<int> flockIDs = new List<int>();
            command = connection.CreateCommand();
            command.CommandText = "SELECT flokkID FROM Saueflokk WHERE BondeID='" + farmerID + "';";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                IDataRecord record = (IDataRecord)reader;
                flockIDs.Add(int.Parse("" + record[0]));
            }

            reader.Close();
            return flockIDs;
        }

        public List<int> LoadAllSheepIDs(int flockID)
        {
            List<int> sheepIDs = new List<int>();
            command = connection.CreateCommand();
            command.CommandText = "SELECT SauID FROM Sauer WHERE FlokkID='" + flockID + "'";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                IDataRecord record = (IDataRecord)reader;
                sheepIDs.Add(int.Parse("" + record[0]));
            }
            return sheepIDs;
        }

        // Parameterløs versjon av metoden over - for å kunne hente ut alle sauer til simulatorens 
        public List<int> LoadAllSheepIDs()
        {
            List<int> sheepIDs = new List<int>();
            command = connection.CreateCommand();
            command.CommandText = "SELECT SauID FROM Sauer";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                IDataRecord record = (IDataRecord)reader;
                sheepIDs.Add(int.Parse("" + record[0]));
            }
            return sheepIDs;
        }

        public Sheep LoadSheep(int sheepID)
        {
            throw new NotImplementedException();
        }

        // Denne skal kalles når man ønsker å sette helsestatus
        public void SetHealth(int sheepID, int heartBeat, float temperature)
        {
            command = connection.CreateCommand();
            command.CommandText = "UPDATE Helse SET hjerteslag='" + heartBeat + "',temperatur='" + temperature + "' WHERE sauID='" + sheepID + "'";
            reader = command.EndExecuteReader();
        }

        public List<HealthStatus> LoadHealthLog(int sheepID, int farmerID, DateTime startTime, DateTime stoptime)
        {
            throw new NotImplementedException();
        }

        public List<Position> LoadPositionLog(int sheepID, DateTime startTime, DateTime stopTime)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Posisjon WHERE tid ";
            throw new NotImplementedException();
        }

        public void StorePosition(int sheepID, DateTime updateTime, Position position)
        {
            throw new NotImplementedException();
        }
    }
}