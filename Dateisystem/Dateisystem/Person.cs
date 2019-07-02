using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Dateisystem
{
    [Serializable]
    public class Person
    {
        [XmlAttribute("DerVorname")]
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        // [field: NonSerialized]  C# 7.3
        public decimal Kontostand { get; set; }
    }
}
