using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace Ex01.Model
{
    public class Guest
    {

        //1. Properties maken, bv geslacht, naam etc
        public int Year { get; set; }

        public String GoogleKnowlege_Occcupation { get; set; }

        public DateTime Show { get; set; }

        public String Group { get; set; }

        public String Name { get; set; } //Raw_guest_List


        //2. constructor (ctor) indien geen voorzien, word vor jouw de default ctor gemaakt
        //we gebruiken de default


        //3. toString method override moet er staan
        public override string ToString()
        {
            return string.Format("{0} {1}", this.Name, this.Group);
        }

        //4. methode dat csv gaat inlezen en lijst van objecten teruggeeft
        public static List<Guest> ReadGuestList() {
            List<Guest> res = new List<Guest>();
            //system.reflection toevoegen
            var assembly = typeof(Guest).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Ex01.Assets.daily_show_guests.csv");

            //bytes uitlezen & verwerken
            StreamReader oSR = new StreamReader(stream);

            //lezen van 1e lijn
            string sLine = oSR.ReadLine(); //1e lijn ni verwerken
            sLine = oSR.ReadLine(); //2e lijn lezen
            while (sLine != null) {
                //lijn verwerken vanuit private createguest
                try
                {
                    Guest guest = CreateGuest(sLine);
                    res.Add(guest); //toevoegen aan lijst
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("Error on line: " + sLine);
                }


                //mijn inlezen
                sLine = oSR.ReadLine();
            }


            return res;
        }
        private static Guest CreateGuest(String sLine) {
            Guest guest = new Guest();
            //sLine opsplitsen in stukken
            String[] parts = sLine.Split(';');
            guest.Year = int.Parse(parts[0]); // string omzetten naar int
            guest.GoogleKnowlege_Occcupation = parts[1];
            guest.Show = Convert.ToDateTime(parts[2]); //string omzetten naar datetime
            guest.Group = parts[3];
            guest.Name = parts[4];


            return guest;
        }









    }

}
