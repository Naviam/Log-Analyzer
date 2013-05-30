namespace Naviam.DataGenerator
{
    using System;

    public class TestMessage
    {
        public string Key { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }

        public string Path { get; set; }

        public string Module { get; set; }

        public string ThreadId { get; set; }

        public int Level { get; set; }

        public DateTime Date { get; set; }

        public static TestMessage GetRandomInstance()
        {
            var level = new[] { 1, 2, 4, 8, 16 };
            var message = new TestMessage
                {
                    Key = Guid.NewGuid().ToString("N"),
                    Message = string.Format("Message DateTime ticks = {0}", DateTime.Now.Ticks),
                    Exception = string.Format("Exception DateTime ticks = {0}", DateTime.Now.Ticks),
                    Level = level[new Random().Next(0,4)],
                    Date = DateTime.Now
                };
            return message;
        }

    }
}
