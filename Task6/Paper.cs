using System.Text;

namespace ITTask6
{
    public class Paper
    {
        public int Number { get; set; }
        
        public StringBuilder Message { get; set; }
        
        public Paper(int number)
        {
            Number = number;
            Message = new StringBuilder();
        }
        
        public override string ToString()
        {
            return Number + " " + Message;
        }
    }
}