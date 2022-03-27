using System.Diagnostics;
using Steamworks;

uint appId = Convert.ToUInt32(Environment.GetCommandLineArgs()[1]);

string gameExec = Environment.GetCommandLineArgs()[2];
IEnumerable<String> gameArgs = Environment.GetCommandLineArgs().Skip(3);

File.WriteAllText("steam_appid.txt", Convert.ToString(appId));

SteamClient.Init(appId);
byte[] ticket = SteamUser.GetAuthSessionTicket().Data;
string ticketArg = Convert.ToBase64String(ticket);

Process game = Process.Start(gameExec, gameArgs.Append("--steamticket=" + ticketArg));
Thread.Sleep(1000*60*10);