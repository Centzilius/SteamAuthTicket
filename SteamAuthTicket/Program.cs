using Steamworks;

uint appId = Convert.ToUInt32(Environment.GetCommandLineArgs()[1]);
string path = Environment.GetCommandLineArgs()[2];

File.WriteAllText("steam_appid.txt", Convert.ToString(appId));

SteamClient.Init(39210);
byte[] ticket = SteamUser.GetAuthSessionTicket().Data;

File.WriteAllText(path, Convert.ToBase64String(ticket));

Thread.Sleep(1000*60*10); // sleep for 10 minutes