using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Ex02.Model
{
    public class Major
    {

        //1. Properties maken, bv geslacht, naam etc
        public string Name { get; set; }

        public int Men { get; set; }

        public int Women { get; set; }

        public string Major_category { get; set; }

        public int Employed { get; set; }

        public int Unemployed { get; set; }

        public int NumberOfStudents {
            get
            {
                return this.Men + this.Women;
            }
        }

        public double UnemploymentRate {
            get
            {
                return (double) this.Unemployed / (this.Employed + this.Unemployed);

            }
        }

        public int ShareofWomen {
            get
            {
                return this.Women / (this.Men + this.Women);

            }
        }


        //2. constructor (ctor) indien geen voorzien, word vor jouw de default ctor gemaakt
        //we gebruiken de default


        //3. toString method override moet er staan
        public override string ToString()
        {
            return string.Format("{0} {1}", this.Name, this.Major_category);
        }

        //4. methode dat csv gaat inlezen en lijst van objecten teruggeeft
        public static List<Major> ReadMajorList()
        {
            List<Major> res = new List<Major>();
            //system.reflection toevoegen
            var assembly = typeof(Major).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Ex02.Assets.recent-grads.csv");

            //bytes uitlezen & verwerken
            StreamReader oSR = new StreamReader(stream);

            //lezen van 1e lijn
            string sLine = oSR.ReadLine(); //1e lijn ni verwerken
            sLine = oSR.ReadLine(); //2e lijn lezen
            while (sLine != null)
            {
                //lijn verwerken vanuit private createguest
                try
                {
                    Major major = CreateMajor(sLine);
                    res.Add(major); //toevoegen aan lijst
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error on line: " + sLine);


                }


                //lijn inlezen
                sLine = oSR.ReadLine();
            }


            return res;
        }


        private static Major CreateMajor(String sLine)
        {
            Major major = new Major();
            //sLine opsplitsen in stukken
            String[] parts = sLine.Split(';');
            major.Name = parts[0];
            major.Men = int.Parse(parts[1]);
            major.Women = int.Parse(parts[2]);
            major.Major_category = parts[3];
            major.Employed = int.Parse(parts[4]);
            major.Unemployed = int.Parse(parts[5]);
            return major;
        }

        public static List<Major> GetByCategory(List<Major>allmajors, string category)
        {
            List<Major> filteredMajors = new List<Major>();
       
            foreach(Major major in allmajors) //bekijk elke major 
            {
                if (major.Major_category.ToLower() == category.ToLower()) //als category gelijk is aan de category
                {
                    filteredMajors.Add(major);
                }

            }

            

            return filteredMajors;
        }
    }
}
