﻿using System;
using System.Net.WebSockets;
using Lib.Constants;
using server.Events;
using server.Game.Controllers;
using server.Game.Entities;
using server.Handlers;

namespace Server.Events
{
	public class OnSendUserNameEvent : GameMessageEvent
	{
		public OnSendUserNameEvent() : base(EventName.SendUserNameEvent) { }

        public override async Task OnGameEvent(SocketHandler handler, GamesController gamesController, Player player, string message)
        {
            if(String.IsNullOrWhiteSpace(message))
            {
                await player.SendMessage(EventName.SendMessageEvent + EventName.SUFFIX + "You have to provide a valid name!");
                await player.SendMessage(EventName.AskUserNameRequest + EventName.SUFFIX);
                return;
            }

            player.Name = message;
            await player.SendMessage(EventName.AskGameNameRequest + EventName.SUFFIX);
        }
    }
}
