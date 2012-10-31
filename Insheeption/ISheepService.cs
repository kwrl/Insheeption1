using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Insheeption
{
    [ServiceContract]
    public interface ISheepService
    {
        //Returnerer true dersom alert-eposten blir sendt
        [OperationContract]
        Boolean testmail();

        //Returnerer en flokk med all info om sauene innenfor spesifisert tidsrom, hentet på grunnlag av FlockID til flokken
        [OperationContract]
        Flock LoadFlockByFlockID(int flockID, DateTime startTime, DateTime stopTime, string username, string password);

        //Returnerer en flokk med all info om sauene innenfor spesifisert tidsrom, hentet på grunnlag av SheepID til en sau i flokken.
        [OperationContract]
        Flock LoadFlockBySheepID(int sheepID, DateTime startTime, DateTime stopTime, string username, string password);

        //Returnerer alle saueflokkID
        [OperationContract]
        List<int> LoadAllFlockIDs(string username, string password);

        //Returnerer en helselog for for en sau innenfor spesifisert tidsrom.
        [OperationContract]
        List<HealthStatus> GetHealthLog(int sheepID, DateTime startTime, DateTime stopTime, string username, string password);

        //Oppretter en ny bruker, returnerer hvor vidt operasjonen var vellykket eller ei.
        [OperationContract]
        bool CreateNewUser(Authentication newUser, Authentication adminAuthentication);

        [OperationContract]
        bool NormalLogin(String brukernavn, String passord);
    }

    [DataContract]
    public class Flock
    {
        [DataMember]
        private List<Sheep> sheep;
        [DataMember]
        private int flockID;

        public Flock(int flockID)
        {
            this.sheep = new List<Sheep>();
            this.flockID = flockID;
        }

        public void AddSheep(Sheep element)
        {
            this.sheep.Add(element);
        }

        public void RemoveSheep(Sheep element)
        {
            this.sheep.Remove(element);
        }
    }

    [DataContract]
    public class Sheep
    {
        [DataMember]
        private List<HealthStatus> healthLog;
        [DataMember]
        private List<Position> positionLog;
        [DataMember]
        private int sheepID;

        public Sheep(int sheepID)
        {
            this.sheepID = sheepID;
        }

        public Sheep(int sheepID, List<HealthStatus> healthLog, List<Position> positionLog)
        {
            this.sheepID = sheepID;
            this.healthLog = healthLog;
            this.positionLog = positionLog;
        }

    }

    [DataContract]
    public class HealthStatus
    {
        [DataMember]
        public int Pulse { get; set; }
        [DataMember]
        public bool Alarm { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
        [DataMember]
        public float temperature { get; set; }

        public HealthStatus(int pulse, bool alarm, float temperature, DateTime time)
        {
            this.temperature = temperature;
            this.Pulse = pulse;
            this.Alarm = alarm;
            this.Time = time;
        }
    }

    [DataContract]
    public class Position
    {
        [DataMember]
        public double Longitude { get; set; }
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public DateTime Time { get; set; }

        public Position(double longitude, double latitude, DateTime time)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.Time = time;
        }

    }

    [DataContract]
    public class Authentication
    {

        
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int FarmerID { get; set; }

        public Authentication(string Username, string Password, int FarmerID)
        {
            this.Username = Username;
            this.Password = Password;
            this.FarmerID = FarmerID;
        }

        public Authentication(String brukernavn, String passord) {
            this.FarmerID = -1;
            this.Username = brukernavn;
            this.Password = passord;
        }
    }
}