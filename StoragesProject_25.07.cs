using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace StoragesProgect
{
    //Astarct class for basic storage object
    abstract class Storage
    {
        private string _name;       //name of storage

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _model;      //model of storage

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public float Volume { get; set; }   //Gygabyte

        /// <summary>
        /// Get volume of storage's memory
        /// </summary>
        /// <returns></returns>
        abstract public float GetVolumeOfMemory();
        /// <summary>
        /// Get volume of FREE storage's memory
        /// </summary>
        /// <returns></returns>
        abstract public float GetFreeVolumeOfMemory(float informationVolume);
    }
    class Hdd : Storage
    {
        public float Speed { get; set; }            //Mbyte in second
        public Dictionary<string, float> sections;  //Section ratio to memory volume
        public Hdd()
        {
            sections = new Dictionary<string, float>();
            Name = "Seagate";
            Model = "ST1000LM035";
            Volume = 500;
            Speed = 140;
        }
        public Hdd(string name, string model, float volume, float speed)
        {
            sections = new Dictionary<string, float>();
            Name = name;
            Model = model;
            Volume = volume;
            Speed = speed;
        }

        public override string ToString()
        {
            //TODO print elements of dictionary
            return $"Name - {Name}\tModel - {Model}\tVolume - {Volume}\tSpeed - {Speed}";
        }

        public override float GetFreeVolumeOfMemory(float informationVolume)
        {
            return this.GetVolumeOfMemory() - informationVolume;
        }
        
        public override float GetVolumeOfMemory()
        {
            return this.Volume;
        }
    }
    class Ssd : Storage
    {
        public string Connector { get; set; }       //Connection connector
        public string Country { get; set; }         //Produced country
        public Ssd()
        {
            Name = "ExeGate";
            Model = "A400TS60";
            Volume = 60;
            Connector = "SATA";
            Country = "China";
        }
        public Ssd(string name, string model, float volume, string connector, string country)
        {
            Name = name;
            Model = model;
            Volume = volume;
            Connector = connector;
            Country = country;
        }

        public override string ToString()
        {
            return $"Name - {Name}\tModel - {Model}\tVolume - {Volume}\tConnector - {Connector}\tCountry - {Country}";
        }

        public override float GetFreeVolumeOfMemory(float informationVolume)
        {
            return this.GetVolumeOfMemory() - informationVolume;
        }

        public override float GetVolumeOfMemory()
        {
            return this.Volume;
        }
    }
    class Flash : Storage
    {
        public float Speed { get; set; }            //Mbyte in second

        public Flash()
        {
            Name = "Mirex";
            Model = "Mirex LINE";
            Volume = 16;
            Speed = 60;
        }

        public Flash(string name, string model, float volume, float speed)
        {
            Name = name;
            Model = model;
            Volume = volume;
            Speed = speed;
        }

        public override string ToString()
        {
            return $"Name - {Name}\tModel - {Model}\tVolume - {Volume}\tSpeed - {Speed}";
        }

        public override float GetFreeVolumeOfMemory(float informationVolume)
        {
            return this.GetVolumeOfMemory() - informationVolume;
        }

        public override float GetVolumeOfMemory()
        {
            throw new NotImplementedException();
        }
    }
    enum DvdType { OneSides = 5, TwoSides = 9}  //Type of DVD Gbyte
    class Dvd : Storage
    {
        public float SpeedRead { get; set; }            //Multiplicity
        public float SpeedWrite { get; set; }            //Multiplicity
        public DvdType DvdType {  get; set; }

        public Dvd()
        {
            Name = "VS";
            Model = "DVD+R";
            Volume = 4.7F;
            SpeedRead = 16;
            SpeedWrite = 16;
            DvdType = DvdType.OneSides;
        }

        public Dvd(string name, string model, float volume, float speedRead, float speedWrite, DvdType dvdType)
        {
            Name = name;
            Model = model;
            Volume = volume;
            SpeedRead = speedRead;
            SpeedWrite = speedWrite;
            DvdType = dvdType;
        }

        public override string ToString()
        {
            return $"Name - {Name}\tModel - {Model}\tVolume - {Volume}\t" +
                   $"SpeedRead - {SpeedRead}\tSpeedWrite - {SpeedWrite}\tDvdType - {DvdType}";
        }

        public override float GetFreeVolumeOfMemory(float informationVolume)
        {
            return this.GetVolumeOfMemory() - informationVolume;
        }

        public override float GetVolumeOfMemory()
        {
            return this.Volume;
        }

    }
    interface ICopyFromStorage
    {
        void CopyFromStorage(Storage storageFrom, Storage storageTo, float info);
        void CopyToStorage(Storage storage, float info);
    }

    class StorageEnumerator : IEnumerator<Storage>
    {
        private Storage[] storage;                              //base array

        private int position = -1;                              //current position for way

        public int Lenght { get { return storage.Length; } }   

        public Storage Current { get { return storage[position]; } }

        public StorageEnumerator(Storage[] newStorage)          //initialise storage newStorage from params
        {
            storage = newStorage;
        }
        public void Reset()
        {
            position = -1;
        }
        public bool MoveNext()
        {
            position++;
            return position < storage.Length;
        }

        object IEnumerator.Current { get { return Current; } }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    class CalculateStorages : IEnumerable, ICopyFromStorage
    {
        Storage[] storages;
        public CalculateStorages(int size)
        {
            storages = new Storage[size];
        }

        public IEnumerator GetEnumerator()
        {
            return new StorageEnumerator(storages);
        }

        void ICopyFromStorage.CopyFromStorage(Storage storageFrom, Storage storageTo, float info)
        {
            storageFrom.Volume = storageFrom.GetFreeVolumeOfMemory(info) + info;
            storageTo.Volume = storageTo.GetFreeVolumeOfMemory(info);
        }

        public void CopyToStorage(Storage storage, float info)
        {
            storage.Volume = storage.GetFreeVolumeOfMemory(info);
        }

        public TimeSpan CaltulateTime(float inf)
        {
            return new TimeSpan((long)inf * 3);
        }
        public double CulculateStoragesMemory ()
        {
            double result = 0;
            foreach (var item in storages)
            {
                result += item.Volume;
            }
            return result;
        }

        //TODO расчет необходимого количества носителей информации представленных типов для переноса информации.
    }
    internal class Program
    {
        static void Main(string[] args)
        {


        }
    }
}
