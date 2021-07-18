using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasksManager.App_Start
{


    public class Task
    {
        string details;
        DateTime date;

        public Task(string details, DateTime date)
        {
            this.details = details;
            this.date = date;
        }
    }
}