using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Email {
    public enum EmailResponse {
        UserNotFound,
        PasswordNeeded,
        PasswordIncorect,
        CredentialsIncorrect,
        ServerUnreachable,
        ServerReachable,
        EmailSent
    }
}
