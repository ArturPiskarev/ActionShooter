using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Controller
{
    public class BotController : MonoBehaviour
    {

        private List<Bot> _botList = new List<Bot>();

        public List<Bot> BotList
        {
            get { return _botList; }
            private set { _botList = value; }
        }

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            Transform tempTarget = GameObject.FindGameObjectWithTag("Player").transform;
            Bot[] tempBots = Bot.FindObjectsOfType<Bot>();
            foreach (var tempBot in tempBots)
            {
                AddBotToList(tempBot);
            }
            int i = -1;
            foreach (var tempBot in BotList)
            {
                tempBot.agent.avoidancePriority = ++i;
                tempBot.Target = tempTarget;
            }
        }

        public void AddBotToList(Bot tempBot)
        {
            if (!BotList.Contains(tempBot))
            {
                BotList.Add(tempBot);
            }
        }

        public void RemoveBotToList(Bot tempBot)
        {
            if (BotList.Contains(tempBot))
            {
                BotList.Remove(tempBot);
            }
        }

    }
}