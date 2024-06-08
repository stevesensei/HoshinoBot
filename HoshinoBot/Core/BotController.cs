using Lagrange.Core;
using Lagrange.Core.Common;
using log4net;

namespace HoshinoBot.Core;

public enum BotType
{
    Group = 0,
    Channel = 1
}

public abstract class BotController
{
    public BotController() 
    {
        BuildBotInstance();
        InitialBotEventHandler();
        BotLogin();
    }

    public string BotName;
    public int Type;
    protected ILog _logger;
    protected abstract void BuildBotInstance();
    protected abstract void BotLogin();
    protected abstract void InitialBotEventHandler();
    public abstract void OnSendingMessage(string message);
}