using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientMQtt.Sensors
{
    interface GoalSensorInterface
    {
        void SetResult();
        bool GetGoalDone();
    }
}
