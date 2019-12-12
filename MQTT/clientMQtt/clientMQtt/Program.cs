using System;
using System.Collections.Generic;
using clientMQtt.Sensors;
using System.Net;
using System.IO;
using System.Collections;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;

namespace clientMQtt
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
                    
                    string BrokerAddress = "192.168.102.76";

                    MqttClient client = new MqttClient(BrokerAddress);
                    

                    string clientId = Guid.NewGuid().ToString();
                    client.Connect(clientId);

                    string Topic = "/Richieste";

                    // publish a message on "/home/temperature" topic with QoS 2
                    client.Publish(Topic, Encoding.UTF8.GetBytes(sensor.toJson()), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                    
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