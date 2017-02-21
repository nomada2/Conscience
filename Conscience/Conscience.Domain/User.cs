﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conscience.Domain
{
    public class User
    {
        public int Id
        {
            get;
            set;
        }

        public Device Device
        {
            get;
            set;
        }

        public List<Notification> Notifications
        {
            get;
            set;
        }

        public Account Account
        {
            get;
            set;
        }
    }
}
