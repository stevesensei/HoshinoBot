using HoshinoBot.Manager;
using Lagrange.Core;
using Lagrange.Core.Common;
using Lagrange.Core.Common.Interface;
using Lagrange.Core.Common.Interface.Api;
using log4net.Core;
using QRCoder;

namespace HoshinoBot.Core;

public class GroupBotController: BotController
{
    private BotContext _context;

    private BotDeviceInfo _device = new BotDeviceInfo()
    {
        Guid = Guid.NewGuid(),
        DeviceName = $"Hoshino-52D02F",
        SystemKernel = "Windows 10.0.19042",
        KernelVersion = "10.0.19042.0"
    };
    protected override void BuildBotInstance()
    {
        BotName = "星野Bot(QQ群-Lagrange)";
        Type = (int)BotType.Group;
        _logger = log4net.LogManager.GetLogger("BotController | Group");
        
        _context = BotFactory.Create(new BotConfig(), _device,new BotKeystore());
    }

    protected override async void BotLogin()
    {
        var qrCode = await _context.FetchQrCode();
        //直接打印二维码
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData data = qrGenerator.CreateQrCode(qrCode.Value.Url,QRCodeGenerator.ECCLevel.Q);
        AsciiQRCode image = new AsciiQRCode(data);
        //直接打印即可
        _logger.Info("KeyStore doesn't exist in redis, using Qrcode to login");
        _logger.Info("Please scan the qrcode below via mobile qq...");
        foreach (var graph in image.GetLineByLineGraphic(1))
        {
            Console.WriteLine(graph);
        }
        //处理登录事件
        await _context.LoginByQrCode();
    }

    protected override void InitialBotEventHandler()
    {
        _context.Invoker.OnBotOnlineEvent += (context, evt) =>
        {
            Console.WriteLine(1);
            EventManager.Instance.BotFinishTask((BotType)Type);
        };
        _context.Invoker.OnBotLogEvent += (context, @event) =>
        {
            Console.WriteLine(@event.EventMessage);
        };
    }

    public override void OnSendingMessage(string message)
    {
        throw new NotImplementedException();
    }
}