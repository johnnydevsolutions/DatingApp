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
    }
}