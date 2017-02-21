using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RecipeOfMagicalTea
{
    public class GameControl
    {
        GameLoop GameLoop { get; set; }
        InformationPage InformationPage { get; set; }

        public GameControl()
        {
        }

        public void Start()
        {
            InformationPage = new InformationPage();
            InformationPage.DrawIntroduction();
            GameLoop = new GameLoop();
            GameLoop.Loop();
        }

        public void Continue()
        {
            GameLoop.Loop();
        }

        //public void Load()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Save()
        //{
        //        //BinaryFormatter formatter = new BinaryFormatter();
        //        //using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
        //        //{
        //        //    formatter.Serialize(fs, GameLoop.GameProcess);
        //        //}

        //        //// десериализация из файла people.dat
        //        //using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
        //        //{
        //        //    Person newPerson = (Person)formatter.Deserialize(fs);

        //        //    Console.WriteLine("Объект десериализован");
        //        //    Console.WriteLine("Имя: {0} --- Возраст: {1}", newPerson.Name, newPerson.Age);
        //        //}

        //        //Console.ReadLine();
        //}

        //public void About()
        //{
        //    throw new NotImplementedException();
        //}

        public void Exite()
        {
            Environment.Exit(0);
        }
    }
}