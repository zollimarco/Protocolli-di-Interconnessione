using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientMQtt.Sensors
{
    class VirtualGoalSensor : GoalSensorInterface, SensorInterface
    {
        public Random random = new Random();
        public int team;
        public bool goal;
        public int c_t1 = 0;
        public int c_t2 = 0;

        public string toJson()
        {

            SetResult();

            int nrullata = random.Next(1, 11);
            bool rullata = false;
            if (nrullata == 5)
            {

                rullata = true;
            }

            if (rullata == true)
            {
                return "{" + "\"idCampo\":" + "\"" + Match.idCampo + "\"," + "\"idPartita\":" + "\"" + Match.idPartita + "\"," + "\"team\": " + team + "," + "\"Event\":" + "\"Rolling\"" + "," + "\"EventResult\":" + "\"true\"" + "," + "\"pTeam1\":" + Match.goal_p1 + "," + "\"pTeam2\":" + Match.goal_p2 + "}";
            }

            //return "{" + "\"idCampo\":" +  "\"" + Match.idCampo +  "\"," + "\"idPartita\":" +  "\"" + Match.idPartita + "\"," + "\"team\": " + team + "," + "\"GoalDone\":" + goal.ToString().ToLower() + "," + "\"pTeam1\":" + Match.goal_p1 + "," + "\"pTeam2\":" + Match.goal_p2 + "}";
            return "{" + "\"idCampo\":" + "\"" + Match.idCampo + "\"," + "\"idPartita\":" + "\"" + Match.idPartita + "\"," + "\"team\": " + team + "," + "\"Event\":" + "\"GoalDone\"" + "," + "\"EventResult\":" + goal.ToString().ToLower() + "," + "\"pTeam1\":" + Match.goal_p1 + "," + "\"pTeam2\":" + Match.goal_p2 + "}";

        }

        public void SetResult()
        {
            team = random.Next(1, 3);
            //Console.WriteLine("team " + team);
            goal = GetGoalDone();
            if (goal == true)
            {
                if (team == 1)
                {
                    Match.goal_p1++;
                }
                if (team == 2)
                {
                    Match.goal_p2++;
                }
            }

        }

        public bool GetGoalDone()
        {
            return random.Next(2) == 1;
        }
    }
}
