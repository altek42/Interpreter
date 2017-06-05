using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLanguage {
    class VariableNotFoundException : Exception{
        public VariableNotFoundException() 
            : base() {
        }
        
        public VariableNotFoundException(string message) 
            : base(message) {

        }
       
        public VariableNotFoundException(string message, Exception innerException)
            : base(message,innerException) {
        }
    }
}
