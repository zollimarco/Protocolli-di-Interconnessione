using System;
using System.Collections.Generic;
using Client.Sensors;
using System.Net;
using System.IO;
using System.Collections;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {            

            // init sensors
            List<SensorInterface> sensors = new List<SensorInterface>();
            sensors.Add(new VirtualGoalSensor());

            
            while (true)
            {
                if (Match.start == false)
                {
                    Match.start = true;

                    
                    Console.WriteLine("Benvenuto sul biliardino di ultima generazione by Momolli!");
                    Console.WriteLine("Inserisci Nome squadra rossa: ");
                    Match.team1 = Console.ReadLine();
                    Console.WriteLine("Inserisci Nome squadra blu: ");
                    Match.team2 = Console.ReadLine();
                    
                    Console.WriteLine("Inserisci Nome player 1 squadra rossa: ");
                    Match.p1_t1 = Console.ReadLine();
                    Console.WriteLine("Inserisci Nome player 2 squadra rossa: ");
                    Match.p2_t1 = Console.ReadLine();
                    Console.WriteLine("Inserisci Nome player 1 squadra blu: ");
                    Match.p1_t2 = Console.ReadLine();
                    Console.WriteLine("Inserisci Nome player 2 squadra blu: ");
                    Match.p2_t2 = Console.ReadLine();

                    Match.GeneraIDPartita();
                    Match.goal_p1 = 0;
                    Match.goal_p2 = 0;

                }
                foreach (SensorInterface sensor in sensors)
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.101.45:8011/tables/AB123");
                    httpWebRequest.ContentType = "text/json";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(sensor.toJson());
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    Console.Out.WriteLine(httpResponse.StatusCode);

                    httpResponse.Close();

                    System.Threading.Thread.Sleep(1000);

                    if (Match.goal_p1 == 10)
                    {
                        Console.WriteLine(Match.team1 + " vince la partita!");
                        Console.ReadKey();
                        Console.Clear();
                        Match.start = false;
                        Match.goal_p1 = 0;
                        Match.goal_p2 = 0;
                        
                    }

                    if (Match.goal_p2 == 10)
                    {
                        Console.WriteLine(Match.team2 + " vince la partita!");
                        Console.ReadKey();
                        Console.Clear();
                        Match.start = false;
                        Match.goal_p1 = 0;
                        Match.goal_p2 = 0;
                        
                    }

                }

            }

        }

    }

}