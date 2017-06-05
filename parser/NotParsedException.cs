using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLanguage.parser {
    class NotParsedException : Exception {
        public NotParsedException() 
            : base() {
        }

        public NotParsedException(string message) 
            : base(message) {

        }

        public NotParsedException(string message, Exception innerException)
            : base(message,innerException) {
        }
    }
}
