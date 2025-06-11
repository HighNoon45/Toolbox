using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Infrastructure.DTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using AutoMapper;
using Toolbox.Infrastructure;

namespace Toolbox
{


    public class OllamaService
    {
        private readonly HttpClient _httpClient;
        private readonly ToolboxDbContext _dbContext;
        private readonly IMapper _mapper;

        public OllamaService(HttpClient httpClient, ToolboxDbContext dbContext, IMapper mapper)
        {
            _httpClient = httpClient;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Chat> SendPromptAsync(string prompt, int userId, string model = "gemma:3b")
        {
            // Create request DTO
            var requestDto = new OllamaRequestDto
            {
                Model = model,
                Prompt = prompt,
                Stream = false
            };

            // Send to Ollama API
            var response = await _httpClient.PostAsJsonAsync(
                "http://localhost:11434/api/generate", requestDto);

            response.EnsureSuccessStatusCode();

            // Deserialize response
            var responseJson = await response.Content.ReadAsStringAsync();
            var responseDto = JsonSerializer.Deserialize<OllamaResponseDto>(responseJson);

            // Map DTOs to entities
            var requestEntity = _mapper.Map<Request>(requestDto);
            var responseEntity = _mapper.Map<Response>(responseDto);

            // Save to database
            _dbContext.Requests.Add(requestEntity);
            _dbContext.Responses.Add(responseEntity);
            await _dbContext.SaveChangesAsync();

            // Create chat linking request and response
            var chat = new Chat
            {
                UserId = userId,
                RequestId = requestEntity.Id,
                ResponseId = responseEntity.Id,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Chats.Add(chat);
            await _dbContext.SaveChangesAsync();

            return chat;
        }

        public async Task<List<Chat>> GetUserChatsAsync(int userId)
        {
            return await _dbContext.Chats
                .Include(c => c.Request)
                .Include(c => c.Response)
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }
    }
}
