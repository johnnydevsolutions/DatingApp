namespace back.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; } // this is the user who sent the message
        public string SenderUsername { get; set; } // this is the user who sent the message
        public string SenderPhotoUrl { get; set; }
        public int RecipientId { get; set; } // this is the user who received the message
        public string RecipientUsername { get; set; } // this is the user who received the message
        public string RecipientPhotoUrl { get; set; }
        public string Content { get; set; } // this is the message content
        public DateTime? DateRead { get; set; } // this is the date the message was read
        public DateTime MessageSent { get; set; }  // this is the date the message was sent
        public bool RecipientDeleted { get; set; } // this is the status of the recipient's deletion of the message
        public bool SenderDeleted { get; set; } // this is the status of the sender's deletion of the message
    }
}