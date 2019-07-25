namespace Xamabrouk.Actions
{
    public class XMViewCardAction
    {
        public XMViewCardAction(string name, XMViewCardActionType type = XMViewCardActionType.Click)
        {
            ActionName = name;
            ActionType = type;
        }

        /// <summary>
        /// Action name : identity for the action
        /// </summary>
        public string ActionName { get; set; }
        public XMViewCardActionType ActionType { get; set; }
    }
}