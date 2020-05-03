namespace MRTKExtensions.Audio
{
    public class SpokenFeedbackMessage
    {
        public SpokenFeedbackMessage()
        {
            
        }

        public SpokenFeedbackMessage(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}
