using Flurl;
using Flurl.Http;
using MyCommandPostGet;
using Newtonsoft.Json;
using System.Net;

//示例

var b = await Request.Ping("https://127.0.0.1");
if(b.Retcode != 200)
{
    Console.WriteLine("服务器并不支持插件");
    return;
}
else
{
    Console.WriteLine($"服务器支持OpenCommand插件：{b.Message}");
}

Console.WriteLine("请输入你的服务器游戏角色UID，我们好发送验证码到你的服务器上面");

var token = "";
while (true)
{
    var uid = Console.ReadLine();
    if (uid == null)
        return;
    var a = await Request.SendCode("https://127.0.0.1", int.Parse(uid));

    if (a.Retcode != 200)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(a.Message);
        Console.WriteLine("玩家可能没有在线哦…………，再换一个UID吧！");
        continue;
    }
    else if(a.Retcode == 200)
    {
        token = a.Data.ToString();
        break;
    }
}


while (true)
{
    Console.WriteLine("请输入游戏中虚拟服务器主机给您通过聊天框滴验证码");
    var verison = Console.ReadLine();
    var d = await Request.Verify("https://127.0.0.1", token!, int.Parse(verison!));
    if (d.Retcode == 200)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("好嘞！现在你已经可以通过此命令行发送服务器命令了！");
        break;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(d.Message+"：呃……验证码错了？在输入一遍吧");
        continue;
    }
}

while (true)
{
    Console.WriteLine("来输入一个命令吧！");
    string command = Console.ReadLine()!;
    if(command == "exit")
    {
        break;
    }
    else
    {
        var e = await Request.BeginInvoke("https://127.0.0.1", token!, command);
        if (e.Retcode == 200)
        {
            Console.ForegroundColor = ConsoleColor.Green ;
            Console.WriteLine($"{e.Data}");
            continue;
        }
        else
        {

            Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine($"{e.Message}");
        }
    }
    
}
Console.ReadLine();
