using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Email {
    public interface IEmailSource {
        string EmailSender { get; set; }
        string EmailRecipient { get; set; }
    }
}
