using System;
using System.Collections.Generic;
namespace ProducerConsumer
{
    class Quote
    {
        public Quote(List<string> companies)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, companies.Count - 1);
            Company = companies[randomNumber];

            
            double randomDouble = random.NextDouble();
            Value = (float)Math.Round(randomDouble * 500,2);
        }

        public string Company { get; }

        public float Value { get; }


    }

    class Buffer
    {
        public Buffer()
        {
            quotes = new List<Quote>();
        }

        private List<Quote> quotes;

        public void Add(Quote quote)
        {
            quotes.Add(quote);
        }

        public Quote Remove()
        {
            Quote res = quotes[0];
            quotes.RemoveAt(0);
            return res;
        }

        public bool IsEmpty()
        {
            return quotes.Count == 0;
        }
    }

    class Producer
    {
        public Producer(Buffer buff, List<string> comp)
        {
            buffer = buff;

            companies = comp;
        }

        private Buffer buffer;

        private List<string> companies;

        public Quote GetRandomQuote()
        {
             Quote quote = new Quote(companies);
            return quote;
        }

        public void Run()
        {
            for(int i=0; i<1000; i++)
            {
                buffer.Add(GetRandomQuote());
            }
        }
    }

    class Consumer
    {
        public Consumer(Buffer buff, List<string> comp)
        {
            Buffer = buff;


        }
    }



    class Program
    {
        static void Main()
        {
            List<string> companies = new List<string>(new string[] { "AAPL", "AMZN", "GOOG", "FB", "CSCO", "CMCSA", "AMGN", "ADBE", "GILD", "COST" });

            Quote testQuote = new Quote(companies);

            Console.WriteLine(testQuote.Company);
            Console.WriteLine(testQuote.Value);

            Buffer buffer = new Buffer();

            buffer.Add(testQuote);
            Console.WriteLine(buffer.IsEmpty());
            Quote removedQuote = buffer.Remove();
            Console.WriteLine(removedQuote.Company);
            Console.WriteLine(removedQuote.Value);
            Console.WriteLine(buffer.IsEmpty());
            

            Producer producer = new Producer(buffer,companies);

            Quote producerTest = producer.GetRandomQuote();
            Console.WriteLine(producerTest.Company);
            Console.ReadKey();
        }
    }
}
