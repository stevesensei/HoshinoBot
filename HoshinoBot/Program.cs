using HoshinoBot.Core;
using HoshinoBot.Manager;
using log4net;


//日志
ILog log = log4net.LogManager.GetLogger("MainThread");
//记录控制器
List<BotController> controllers = new List<BotController>();

//机器人登陆处理
BotController groupController = new GroupBotController();
EventManager.Instance.OnBotFinishTask += type =>
{
    if (type == BotType.Group)
    {
        log.Info($"Bot {groupController.BotName} logged in");
        controllers.Add(groupController);
    }
};

Thread.Sleep(-1);
