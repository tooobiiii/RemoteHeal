using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using InventorySystem.Items;
using InventorySystem.Items.Usables;
using PlayerRoles;
using PlayerStatsSystem;
using UnityEngine;
using Consumable = Exiled.API.Features.Items.Consumable;

namespace RemoteHeal
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class HealCommand : ICommand
    {
        public string Command { get; } = "heal";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Heals the player you are aiming at";
        
        public bool Execute(ArraySegment<string> args, ICommandSender sender, out string response)
        {
            var p = Player.Get(sender);

            if (!p.IsHuman)
            {
                response = "You can't run this command";
                return false;
            }

            var enumerable = p.Items.Where(i => i.Type == ItemType.Medkit);
            if (enumerable.IsEmpty())
            {
                response = "You do not have a medkit";
                return false;
            }

            var cmm = p.CameraTransform;
            if (!Physics.Raycast(cmm.position, cmm.forward, out var hit, Plugin.Instance.Config.Distance))
            {
                response = "You must be looking at a player in order to heal them";
                return false;
            }

            var target = Player.Get(hit.transform.GetComponentInParent<ReferenceHub>());
            if (target == null)
            {
                response = "You must be looking at a player in order to heal them";
                return false;
            }

            if (target.Role.Team == Team.SCPs)
            {
                response = "You cannot heal any scps";
                return false;
            }

            if (target.Health >= target.MaxHealth)
            {
                response = "This player is already fully recovered";
                return false;
            }
            
            var item = enumerable.First(); 
            target.Heal(Medkit.HpToHeal);
            p.RemoveItem(item);
            target.ShowHint($"You got healed by {p.Nickname}");
            response = $"You successfully healed {target.Nickname}";
            return true;
        }
    }
}