using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dateisystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Binär
            #region FileStream
            //FileStream stream = new FileStream("demo.txt", FileMode.Create);
            //byte[] data = Encoding.Unicode.GetBytes("Hallo Welt in einer Datei !");
            //stream.Write(data, 0, data.Length);
            //stream.Flush();
            //stream.Close();

            //stream = new FileStream("demo.txt", FileMode.Open);
            //byte[] dataFromFile = new byte[stream.Length];

            //for (int i = 0; i < stream.Length; i++)
            //{
            //    dataFromFile[i] = (byte)stream.ReadByte();
            //}
            //stream.Close();

            //string text = Encoding.Unicode.GetString(dataFromFile);
            //Console.WriteLine(text); 
            #endregion

            // Textdatein
            #region StreamReader/Writer
            ////StreamWriter sw = new StreamWriter("demo2.txt");
            ////sw.WriteLine("Hallo Welt mit einem StreamWriter ❤");
            ////sw.Flush();
            ////sw.Close();

            //using (StreamWriter sw = new StreamWriter("demo2.txt",false,Encoding.UTF8))
            //{
            //    sw.WriteLine("Hallo Welt mit einem StreamWriter ❤");
            //} // Dispose(); -> Flush() und Close() 

            //StreamReader sr = new StreamReader("demo2.txt");
            //string text = sr.ReadToEnd();
            //Console.WriteLine(text);
            //sr.Close(); 
            #endregion

            // Alles
            #region File
            //File.WriteAllText("demo3.txt", "Das ist die letzte Demo");
            //File.SetCreationTime("demo3.txt", new DateTime(1848, 3, 13, 12, 45, 53));
            //Console.WriteLine(File.ReadAllText("demo3.txt")); 
            #endregion

            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            Person p2 = new Person { Vorname = "Anna", Nachname = "Nass", Alter = 20, Kontostand = 2000 };
            Person p3 = new Person { Vorname = "Peter", Nachname = "Silie", Alter = 30, Kontostand = 3000 };

            Person[] personen = { p1, p2, p3 };

            // Serialisierung:
            // Binär:

            #region Binär
            //BinaryFormatter serializer = new BinaryFormatter();
            //FileStream stream = new FileStream("person.bin", FileMode.Create);
            //serializer.Serialize(stream, p1);
            //serializer.Serialize(stream, p2);
            //serializer.Serialize(stream, p3);
            //stream.Close();

            //stream = new FileStream("person.bin", FileMode.Open);

            //object loadedPerson1 = serializer.Deserialize(stream);
            //object loadedPerson2 = serializer.Deserialize(stream);
            //object loadedPerson3 = serializer.Deserialize(stream); 
            #endregion

            XmlSerializer serializer = new XmlSerializer(typeof(Person[]));
            FileStream stream = new FileStream("person.xml", FileMode.Create);

            serializer.Serialize(stream, personen);
            // serializer.Serialize(stream, p2);
            stream.Close();

            stream = new FileStream("person.xml", FileMode.Open);
            object loadedPerson = serializer.Deserialize(stream);
            stream.Close();

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
