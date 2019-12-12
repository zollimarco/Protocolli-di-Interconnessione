using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientMQtt
{
    public static class Match
    {
        public static string idCampo = "Campo1PNRorai";
        public static string idPartita = "";
        public static bool start = false;
        public static string team1 = "";
        public static string team2 = "";
        public static string p1_t1 { get; set; }
        public static string p2_t1 { get; set; }
        public static string p1_t2 { get; set; }
        public static string p2_t2 { get; set; }
        public static int goal_p1 = 0;
        public static int goal_p2 = 0;

        public static void GeneraIDPartita()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[13];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            idPartita = new String(stringChars); ;
        }

    }
}
