using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace ConsoleApp1
{
    [Serializable]
    public class Person
    {
        public String Name { get; set; }
        public String LastName { get; set;}

        private int Age { get; set; }

        [NonSerialized]
        string typeName = "Human";
        public int Id { get; set; }

        public Person() { }

        public Person(string name, string lastName, int number)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Id = number;
        }
        /// <summary>
        /// ToString override method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Id}:{Name} - {LastName}";
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {

            XmlTextWriter xmlWriter = null;

            try
            {
                xmlWriter = new XmlTextWriter("tours.xml", Encoding.Unicode);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Tours");
                xmlWriter.WriteStartElement("Tour");
                xmlWriter.WriteAttributeString("Company", "MyCompanyName");
                xmlWriter.WriteElementString("Country", "Egypt");
                xmlWriter.WriteElementString("Duration", "14");
                xmlWriter.WriteElementString("Price", "88000");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();

                Console.WriteLine("XML file generated");


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (xmlWriter != null)
                    xmlWriter.Close();
            }




            Person person = new Person("Elena", "Краснова", 12);

            XmlSerializer xmlSerilizer = new XmlSerializer(typeof(Person));

            try
            {
                //using (Stream stream = File.Create("obj_to_xml.xml"))
                //{
                //    xmlSerilizer.Serialize(stream, person);
                //}
                //Console.WriteLine("Serialize is DONE");

                Person p = null;
                using (Stream stream = File.OpenRead("obj_to_xml.xml"))
                {
                    p = (Person)xmlSerilizer.Deserialize(stream);
                }
                Console.WriteLine("DESerialize is DONE - " + p.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }




            DirectoryInfo directoryInfo = new DirectoryInfo(".");
            Console.WriteLine($"FullName - {directoryInfo.FullName}");
            Console.WriteLine($"CreationTime - {directoryInfo.CreationTime}");

            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                Console.WriteLine($"{file.Name}");
            }

            //WRITE TO FILE
            string filePath = @"C:\Users\Администратор\source\repos\ConsoleApp1\ConsoleApp1\new_text.txt";
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fileStream, Encoding.Unicode))
                {
                    Console.WriteLine("Введите текст: ");
                    string str = Console.ReadLine();

                    writer.WriteLine(str);
                    foreach (var item in str)
                    {
                        writer.Write($"{item}");
                    }
                }
            }
            Console.WriteLine("RECORDED");


            //READING
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream, Encoding.Unicode))
                {

                    Console.WriteLine(reader.ReadToEnd());
                }
            }


            Console.ReadKey();
        }
    }
}
