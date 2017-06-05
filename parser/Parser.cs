using MyLanguage.kalk;
using MyLanguage.lang;

namespace MyLanguage.parser {
    class Parser {
        string input;    // analizowany tekst
        int position; // wskaźnik na aktualnie "oglądany" znak

        public Parser(string input) {
            this.input = input;
            this.input += char.MinValue;
            this.position = 0;
        }

        // Pomija wszystkie białe znaki i przesuwa wskaźnik
        // na pierwszy znak, który nie jest biały.
        void skipWhitespace() {
            while(input[position] == ' ' || char.IsControl(input[position])) {
                if(input[position] == char.MinValue) {
                    return;
                }
                position++;
            }
        }

        // Pomija białe znaki i informuje jaki znak "oglądamy". 
        char lookAhead() {
            this.skipWhitespace();
            return input[position];
        }

        // Parsuje wyrażanie.
        public IExpression parse_Expression() {
            IExpression e = parse_sum();
            if(position == input.Length-1) {
                return e;
            }
            else {
                throw new NotParsedException("Parsowanie nie udane");
            }
        }

        // Parsuje "sumę".
        IExpression parse_sum() {
            IExpression e = parse_mult();
            char c = lookAhead();
            while(c=='+' || c == '-') {
                position++;
                e = new BinaryOperator(c, e, parse_mult());
                c = lookAhead();
            }
            return e;
        }

        // Parsuje składnik.      
        IExpression parse_mult() {
            IExpression e = parse_term();
            char c = lookAhead();
            while(c=='*' || c== '/' || c == '%') {
                position++;
                e = new BinaryOperator(c, e, parse_term());
                c = lookAhead();
            }
            return e;
        }

        // Parsuje czynnik.     
        IExpression parse_term() {
            char c = lookAhead();
            if (char.IsDigit(c)) {
                return parse_Constant();
            }
            else if (char.IsLetter(c)) {
                return parse_Variable();
            }
            else if (c == '(') {
                return parse_paren();
            }
            else {
                throw new NotParsedException();
            }
        }

        // Parsuje liczbę.   
        IExpression parse_Constant() {
            string number="";
            while (char.IsDigit(input[position])) {
                number += input[position];
                position++;
            }
            return new Constant(int.Parse(number));
        }
        // Parsuje nazwę zmiennej.
        IExpression parse_Variable() {
            string s="";
            while (char.IsLetter(input[position])) {
                s += (input[position]);
                position++;
            }
            return new Variable(s);
        }
        // Parsuje "sumę" w nawiasie.
        IExpression parse_paren() {
            position++; // parse_term zapewnia, że wskaźnik
                        // stoi na nawiasie otwierającym '('

            IExpression e = parse_sum();
            if(lookAhead() == ')') {
                position++;
                return e;
            }
            else {
                throw new NotParsedException();
            }
        }

        string parseIdentifier() {
            string s = "";
            while (char.IsLetter(input[position])) {
                s += (input[position]);
                position++;
            }
            return s;
        }

       public IInstruction parse_Program() {
            IInstruction p = parse_block();
            if (position == input.Length - 1) {
                return p;
            }
            else {
                throw new NotParsedException("end of stream expected");
            }
        }

        IInstruction parse_block() {
            IInstruction p = parse_instruction();
            char c = lookAhead();
            while(c!= '}' && position != input.Length - 1) {
                IInstruction q = parse_instruction();
                p = new Composition(p, q);
                c = lookAhead();
            }
            return p;
        }

        IInstruction parse_instruction() {
            char c = lookAhead();
            if (c == '{' ) {
                position++;
                IInstruction p = parse_block();
                if (lookAhead() == '}') {
                    position++;
                    return p;
                }
                else {
                    throw new NotParsedException("'}' expected");
                }
            }
            else if(char.IsLetter(c)) {
                string s = parseIdentifier();
                switch (s) {
                    case "read":
                        return parse_Read();
                    case "write":
                        return parse_Write();
                    case "if":
                        return parse_If();
                    case "while":
                        return parse_While();
                    case "skip":
                        return new Skip();
                    default:
                        return parse_Assign(s);
                }
            }
            else {
                throw new NotParsedException("identifier or a keyword expected");
            }
        }

        IInstruction parse_Read() {
            char c = lookAhead();
            if(char.IsLetter(c)) {
                string s = parseIdentifier();
                return new Read(s);
            }
            else {
                throw new NotParsedException();
            }
        }

        IInstruction parse_Write() {
            char c = lookAhead();
            if (char.IsLetter(c)) {
                string s = parseIdentifier();
                return new Write(s);
            }
            else {
                throw new NotParsedException("variable expected");
            }

        }

        IInstruction parse_If() {
            IExpression e = parse_sum();
            IInstruction o = parse_instruction();
            if(char.IsLetter(lookAhead())) {
                if(parseIdentifier() == "else") {
                    IInstruction p = parse_instruction();
                    return new If(e, o, p);
                }
                else {
                    throw new NotParsedException("'else' expected");
                }
            }
            else
                throw new NotParsedException("'else' expected");
        }

        IInstruction parse_While() {
            IExpression e = parse_sum();
            IInstruction p = parse_instruction();
            return new While(e, p);
        }

        IInstruction parse_Assign(string v) {
            char c = lookAhead();
            if(c== '=') {
                position++;
                IExpression e = parse_sum();
                return new Assign(v, e);
            }
            else {
                throw new NotParsedException("'=' expected");
            }
        }
    }
    
}

