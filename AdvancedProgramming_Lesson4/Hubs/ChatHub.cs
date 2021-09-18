using AdvancedProgramming_Lesson4.Data;
using AdvancedProgramming_Lesson4.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AdvancedProgramming_Lesson4.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            var authenticated = Context.User.Identity.IsAuthenticated;

                Messages text = new Messages();
            text.UserName = Context.User.Identity.Name;
            text.Message = message;
            text.Authenticated = authenticated;
                _context.Messages.Add(text);
                _context.SaveChanges();
            }
            
        }
    }

