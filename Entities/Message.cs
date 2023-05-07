using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingProject.Entities;

namespace back.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; } // this is the user who sent the message
        public string SenderUsername { get; set; } // this is the user who sent the message
        public AppUser Sender { get; set; } // this is the user who sent the message
        public int RecipientId { get; set; } // this is the user who received the message
        public string RecipientUsername { get; set; } // this is the user who received the message
        public AppUser Recipient { get; set; } // this is the user who received the message
        public string Content { get; set; } // this is the message content
        public DateTime? DateRead { get; set; } // this is the date the message was read
        public DateTime MessageSent { get; set; } = DateTime.UtcNow; // this is the date the message was sent
        public bool SenderDeleted { get; set; } // this is the user who sent the message
        public bool RecipientDeleted { get; set; } // this is the user who received the message
    }
}