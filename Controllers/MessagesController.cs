using AutoMapper;
using back.DTOs;
using back.Entities;
using back.Extensions;
using back.Helpers;
using back.Interfaces;
using DatingBack.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft .AspNetCore.Http;


namespace back.Controllers
{
    public class MessagesController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;
        
        private readonly IMapper _Mapper; 
        public MessagesController(IUserRepository userRepository, IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _Mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost]

        public async Task<ActionResult<MessageDto>> CreateMessage(CreateMessageDto createMessageDto)
        {
            var username = User.GetUserName();
            if (username == createMessageDto.RecipientUsername.ToLower())
                return BadRequest("You cannot send messages to yourself");

            var sender = await _userRepository.GetUserByUsernameAsync(username);
            var recipient = await _userRepository.GetUserByUsernameAsync(createMessageDto.RecipientUsername);

            if (recipient == null) return NotFound();
            
            var message = new Message 
            {
                Sender = sender,
                Recipient = recipient,
                SenderUsername = sender.UserName,
                RecipientUsername = recipient.UserName,
                Content = createMessageDto.Content
            };

            _messageRepository.AddMessage(message);

            if (await _messageRepository.SaveAllAsync()) 
             return Ok(_Mapper.Map<MessageDto>(message));
             return BadRequest("Failed to send message");
        }
    

    [HttpGet]
    public async Task<ActionResult<PageList<MessageDto>>> GetMessagesForUser([FromQuery]MessageParams messageParams)

    { 
        messageParams.Username = User.GetUserName();

        var messages = await _messageRepository.GetMessagesForUser(messageParams);

        Response.AddPaginationHeader(new PaginationHeader(messageParams.PageNumber, messageParams.PageSize, messages.TotalCount, messages.TotalPages));

        return messages;

    }

    [HttpGet("thread/{username}")]
    public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessageThread(string username)
    {
        var currentUsername = User.GetUserName();
        return Ok(await _messageRepository.GetMessageThread(currentUsername, username));
    }

    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMessage(int id)
    {
        var username = User.GetUserName();

        var message = await _messageRepository.GetMessage(id);

        if (message.SenderUsername !=  username && message.RecipientUsername != username)
         return Unauthorized();

         if (message.SenderUsername == username) message.SenderDeleted = true;
         if(message.RecipientUsername == username) message.RecipientDeleted = true;

         if (message.SenderDeleted && message.RecipientDeleted)
         {
                _messageRepository.DeleteMessage(message);
         }

         if(await _messageRepository.SaveAllAsync()) return Ok ();
         return BadRequest("Problem deleting the message");
    }

    }
}