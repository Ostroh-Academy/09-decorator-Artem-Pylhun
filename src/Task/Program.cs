namespace Task
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Creating a base applicant
            IApplicant applicant = new Applicant("John Doe");

            // Adding portfolio
            applicant = new PortfolioDecorator(applicant, "Projects: A, B, C");

            // Adding recommendation letters
            applicant = new RecommendationDecorator(applicant, "Prof. X, Prof. Y");

            // Displaying applicant information
            applicant.DisplayInfo();
        }
    }

    // Interface for Applicant
    public interface IApplicant
    {
        string Name { get; }
        void DisplayInfo();
    }

    // Concrete class for Applicant
    public class Applicant : IApplicant
    {
        public string Name { get; }

        public Applicant(string name)
        {
            Name = name;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
        }
    }

    // Decorator abstract class
    public abstract class Decorator : IApplicant
    {
        protected IApplicant _applicant;

        public Decorator(IApplicant applicant)
        {
            _applicant = applicant;
        }

        public abstract string Name { get; }
        public abstract void DisplayInfo();
    }

    // Decorator adding portfolio
    public class PortfolioDecorator : Decorator
    {
        public string Portfolio { get; }

        public PortfolioDecorator(IApplicant applicant, string portfolio) : base(applicant)
        {
            Portfolio = portfolio;
        }

        public override string Name => _applicant.Name;

        public override void DisplayInfo()
        {
            _applicant.DisplayInfo();
            Console.WriteLine($"Portfolio: {Portfolio}");
        }
    }

    // Decorator adding recommendation letters
    public class RecommendationDecorator : Decorator
    {
        public string Recommendations { get; }

        public RecommendationDecorator(IApplicant applicant, string recommendations) : base(applicant)
        {
            Recommendations = recommendations;
        }

        public override string Name => _applicant.Name;

        public override void DisplayInfo()
        {
            _applicant.DisplayInfo();
            Console.WriteLine($"Recommendations: {Recommendations}");
        }
    }


}