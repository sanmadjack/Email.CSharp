
namespace Email {
    public interface IEmailSource {
        string EmailSender { get; set; }
        string EmailRecipient { get; set; }
    }
}
