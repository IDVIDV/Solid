using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MenuUtil
{
    public class ActionMenu
    {
        public Encoding Encoding { get; set; }
        private List<KeyValuePair<String, Action>> _actions;

        public ActionMenu(Encoding encoding)
        {
            this._actions = new List<KeyValuePair<String, Action>>();
            Encoding = encoding;
        }

        public ActionMenu(Encoding encoding, List<KeyValuePair<String, Action>> actions)
        {
            this._actions = new List<KeyValuePair<String, Action>>(actions);
            Encoding = encoding;
        }

        public void AddAction(String actionDescription, Action action)
        {
            _actions.Add(KeyValuePair.Create(actionDescription, action));
        }

        public bool TryRemoveAction(int actionNumber)
        {
            if (actionNumber > _actions.Count - 1 || actionNumber < 0)
            {
                return false;
            }

            _actions.RemoveAt(actionNumber);

            return true;
        }

        public bool TryDoAction(int actionNumber)
        {
            if (actionNumber > _actions.Count - 1 || actionNumber < 0)
            {
                return false;
            }

            _actions[actionNumber].Value.Invoke();

            return true;
        }

        public int GetNumberOfActions()
        {
            return _actions.Count;
        }

        public void PrintActionDescriptions(Stream outputStream)
        {
            for (int i = 0; i < _actions.Count; ++i)
            {
                byte[] actionDescriptionAsBytes = Encoding.GetBytes((i + 1).ToString() + ". " +
                    _actions[i].Key + "\n");

                outputStream.Write(actionDescriptionAsBytes, 0, actionDescriptionAsBytes.Length);
            }

            outputStream.Flush();
            outputStream.Close();
        }
    }
}
