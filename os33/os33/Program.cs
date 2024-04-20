using Newtonsoft.Json;
using os3;
using System;
using System.Collections.Generic;
using System.IO;

namespace OSLabEx3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<person> persons = new List<person>();
            Console.WriteLine("1.set info for new people");
            Console.WriteLine("2.get info");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter number of new people");
                    int count = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < count; i++)
                    {
                        person person = new person();
                        Console.WriteLine("Enter Name :");
                        person.Name = Console.ReadLine();
                        Console.WriteLine("Enter Last Name :");
                        person.LastName = Console.ReadLine();
                        Console.WriteLine("Enter ssd :");
                        person.ssd = Console.ReadLine();
                        Console.WriteLine("Enter Phone number :");
                        person.phoneNumber = Console.ReadLine();
                        Console.WriteLine("Enter Age :");
                        person.Age = Convert.ToInt32(Console.ReadLine());
                        persons.Add(person);
                    }
                    string json = JsonConvert.SerializeObject(persons, Formatting.Indented);
                    File.WriteAllText("people.json", json);
                    Console.WriteLine("people info saved in json file");
                    break;

                case 2:
                    try
                    {
                        string jsonText = File.ReadAllText("people.json");
                        persons = JsonConvert.DeserializeObject<List<person>>(jsonText);
                        if (persons != null)
                        {
                            persons.AddRange(persons);
                            Console.WriteLine("people info getting from json file");
                            for (int i = 0; i < persons.Count; i++)
                            {
                                Console.WriteLine(persons[i].Name + " , " + persons[i].LastName + " , " + persons[i].ssd + " , " + persons[i].phoneNumber + " , " + persons[i].Age + " , ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No person info found");
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("json file not found");
                    }
                    break;

            }
        }
    }
}
