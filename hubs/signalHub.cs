using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;



/*

  _________ __                   ____         _____          __                     .__         ___.  ._.
 /   _____//  |_  ____ ______   /_   | /\    /     \ _____  |  | __ ____   _____    |  |__  __ _\_ |__| |
 \_____  \\   __\/ __ \\____ \   |   | \/   /  \ /  \\__  \ |  |/ // __ \  \__  \   |  |  \|  |  \ __ \ |
 /        \|  | \  ___/|  |_> >  |   | /\  /    Y    \/ __ \|    <\  ___/   / __ \_ |   Y  \  |  / \_\ \|
/_______  /|__|  \___  >   __/   |___| \/  \____|__  (____  /__|_ \\___  > (____  / |___|  /____/|___  /_
        \/           \/|__|                        \/     \/     \/    \/       \/       \/          \/\
 */


namespace Notey
{
    public class SignalHub : Hub
    {
        public async Task SendMessage(string status)
        {//                    ^ Name of event sent to server
            await Clients.All.SendAsync("ReceiveMessage", status);
                                    //  ^ Name of event sent to everyone else.
        }


    }
}