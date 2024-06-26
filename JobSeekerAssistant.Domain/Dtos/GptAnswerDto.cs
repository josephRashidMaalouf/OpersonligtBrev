namespace JobSeekerAssistant.Domain.Dtos;



public class GptAnswerDto
{
    public string id { get; set; }
    public string _object { get; set; }
    public int created { get; set; }
    public string model { get; set; }
    public Choice[] choices { get; set; }

}



public class Choice
{
    public int index { get; set; }
    public Message message { get; set; }

}

public class Message
{
    public string role { get; set; }
    public string content { get; set; }
}
