﻿using Conscience.Application.Graph.Entities.Accounts;
using Conscience.Application.Graph.Entities.Characters;
using Conscience.Application.Graph.Entities.Memories;
using Conscience.Application.Graph.Entities.Stats;
using Conscience.DataAccess.Repositories;
using Conscience.Domain;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conscience.Application.Graph.Entities.Hosts
{
    public class HostGraphType : ConscienceGraphType<Host>
    {
        public HostGraphType(NotificationRepository notsRepo)
        {
            Name = "Host";

            Field<AccountGraphType>("account", resolve: context => context.Source.Account);
            Field<CharacterInHostGraphType>("currentCharacter", resolve: context => context.Source.CurrentCharacter);
            Field<ListGraphType<CharacterInHostGraphType>>("characters", resolve: context => context.Source.Characters);
            Field<ListGraphType<StatsGraphType>>("stats", resolve: context => context.Source.Stats);
            Field<CoreMemoryGraphType>("coreMemory1", resolve: context => context.Source.CoreMemory1);
            Field<CoreMemoryGraphType>("coreMemory2", resolve: context => context.Source.CoreMemory2);
            Field<CoreMemoryGraphType>("coreMemory3", resolve: context => context.Source.CoreMemory3);
            Field<HostStatusEnumeration>("status", resolve: context => context.Source.Status);

            Field<BooleanGraphType>("coreMemory1readed", resolve: context =>
            {
                var notification = notsRepo.GetByAccount(context.Source.Id).FirstOrDefault(n => n.NotificationType == NotificationTypes.CoreMemory && n.Description.Contains("1"));
                return notification != null && notification.Read;
            });
        }
    }

    public class HostStatusEnumeration : EnumerationGraphType<HostStatus>
    {
        public HostStatusEnumeration()
        {
            Name = "HostStatus";
        }
    }
}
