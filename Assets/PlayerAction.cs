using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets
{
    internal class PlayerAction
    {
        private Action<PlayerCharacter> action;
        private bool isOneTimeUse = false;

        public bool IsOneTimeUse {  get { return isOneTimeUse; } }

        public PlayerAction(Action<PlayerCharacter> action, bool isOneTimeUse = false)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.isOneTimeUse = isOneTimeUse;
        }

        public void Invoke(PlayerCharacter player) => action(player);
    }

    internal class PlayerActionLoop
    {
        private PlayerCharacter player;
        private List<PlayerAction> playerActions = new List<PlayerAction>();

        public PlayerActionLoop(PlayerCharacter player)
        {
            this.player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public void AppendAction(PlayerAction action) => playerActions.Add(action);

        public void ProcessActions()
        {
            foreach (PlayerAction action in playerActions)
                action.Invoke(player);

            playerActions = playerActions.Where(pa => !pa.IsOneTimeUse).ToList();
        }
    }
}
