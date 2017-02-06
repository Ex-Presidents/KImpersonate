using Rocket.API;
using Steamworks;
using SDG.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kr4ken.Impersonate
{
    public class CImpersonate : IRocketCommand
    {
        public AllowedCaller AllowedCaller { get { return AllowedCaller.Both; } }
        public string Name { get { return "Impersonate"; } }
        public string Help { get { return "Impersonate a player through text"; } }
        public string Syntax { get { return "/impersonate <player> [message]"; } }
        public List<string> Aliases { get { return new List<string>(); } }
        public List<string> Permissions { get { return new List<string> { "KImpersonate.impersonate" }; } }
        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length != 2)
            {
                if (caller.Id == "Console")
                {
                    Rocket.Core.Logging.Logger.Log("The correct syntax is, /Impersonate <player> '[message]'");
                    return;
                }
                else
                {
                    UnturnedChat.Say(caller, "The correct syntax is, '/Impersonate <player> [message]'");
                    return;
                }
            }
            if (UnturnedPlayer.FromName(command[0]) == null)
            {
                if (caller.Id == "Console")
                {
                    Rocket.Core.Logging.Logger.Log("Could not find player, '" + command[0] + "'.");
                    return;
                }
                else
                {
                    UnturnedChat.Say(caller, "Could not find player, '" + command[0] + "'.");
                    return;
                }
            }

            UnturnedPlayer target = UnturnedPlayer.FromName(command[0]);
            List<string> M = UnturnedChat.wrapMessage(command[1]);
            for (int i = 0; i < M.Count; i++)
                ChatManager.instance.channel.send("tellChat", ESteamCall.OTHERS, ESteamPacket.UPDATE_RELIABLE_BUFFER, new object[ { target.CSteamID, (byte)EChatMode.GLOBAL, target.Color, M[i] }])
        }
    }
}
