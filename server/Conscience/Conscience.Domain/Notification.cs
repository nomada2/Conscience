﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conscience.Domain
{
    public class Notification : IdentityEntity
    {
        public virtual Account Owner
        {
            get;
            set;
        }

        public int OwnerId
        {
            get;
            set;
        }

        public virtual Host Host
        {
            get;
            set;
        }

        public virtual Employee Employee
        {
            get;
            set;
        }

        public virtual Audio Audio
        {
            get;
            set;
        }

        public DateTime TimeStamp
        {
            get;
            set;
        }

        public bool Processed
        {
            get;
            set;
        }

        public bool Read
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public NotificationTypes NotificationType
        {
            get;
            set;
        }
    }

    public enum NotificationTypes
    {
        CallHost,
        Reset,
        NoReset,
        CoreMemory,
        SystemFailure,
        LowBattery,
        HostHurt,
        HostDead,
        HostFixed,
        StatsModified,
        CharacterModified,
        CharacterAssigned,
        PlotModified,
        Panic,
        Custom,
        UpdateApp
    }
}
