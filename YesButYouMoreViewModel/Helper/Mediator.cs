using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesButYouMoreViewModel
{
    /// <summary>
    /// Classes that subscribe a method into the mediator will get added into a dictionary.
    /// 
    /// Classes that define an ICommand property will access the dictionary if there are any events of
    /// the specified name to be called.
    /// </summary>
    public static class Mediator
    {
        private static IDictionary<string, List<Action<object>>> eventDictionary = new Dictionary<string, List<Action<object>>>();

        public static void SubscribeEvent(string key, Action<object> callBack)
        {
            if (eventDictionary.ContainsKey(key))
            {
                //Check if the action is in this collection specified by the key exist
                bool found = false;
                //Iterate through the list of Actions at the specified key
                foreach (Action<object> item in eventDictionary[key])
                {
                    //If the specifed action is found in the list of actions then check is true otherwise add the action into the list.
                    if (item.Method.ToString() == callBack.Method.ToString())
                    {
                        found = true;
                    }

                    if (!found)
                    {
                        eventDictionary[key].Add(callBack);
                    }
                }
            }
            //If the key doesn't exist, create a new key and list of actions
            else
            {
                List<Action<object>> actionList = new List<Action<object>>();
                actionList.Add(callBack);
                eventDictionary.Add(key, actionList);
            }
        }

        public static void RemoveEvent(string key, Action<object> callBack)
        {
            if (eventDictionary.ContainsKey(key))
            {
                eventDictionary[key].Remove(callBack);
            }
        }
        /// <summary>
        /// Define an ICommand Property by calling this method.
        /// </summary>
        public static void Notify(string key, object args = null)
        {
            if (eventDictionary.ContainsKey(key))
            {
                foreach (var callBack in eventDictionary[key])
                {
                    callBack(args);
                }
            }
        }
    }
}
