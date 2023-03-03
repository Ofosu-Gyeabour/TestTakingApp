namespace PETAS.Classes
{
    public class MailStub
    {
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }

        public string cc { get; set; }
        public string bcc { get; set; }

        public MailAttachment[] attachment { get; set; }
    }

    public class MailAttachment
    {
        public string fileName { get; set; }
        public byte[] fileData { get; set; }
    }
}
