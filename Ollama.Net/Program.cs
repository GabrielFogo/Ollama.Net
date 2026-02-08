using Microsoft.Extensions.AI;
using OllamaSharp;

var uri = new Uri($"http://localhost:11434/");
const string defaultModel = "llama3:latest";

IChatClient chat = new OllamaApiClient(uri, defaultModel);

List<ChatMessage> chatHistory = [];

while (true)
{
    Console.Write("Você: ");
    
    var enterText = Console.ReadLine();
    
    if (enterText?.ToLower() == "exit")
        break;
    
    if(string.IsNullOrWhiteSpace(enterText))
        continue;
    
    var userMessage = new ChatMessage(ChatRole.User, enterText);
    
    chatHistory.Add(userMessage);
    
    Console.Write("Assistente:");

    var assistentMessageText = "";

    await foreach (var messageChunk in chat.GetStreamingResponseAsync(chatHistory))
    {
        Console.Write(messageChunk);
        assistentMessageText += messageChunk;      
    }

    var assistentMesssage = new ChatMessage(ChatRole.Assistant, assistentMessageText);
    
    chatHistory.Add(assistentMesssage);
    
    Console.WriteLine();
    Console.WriteLine();
}