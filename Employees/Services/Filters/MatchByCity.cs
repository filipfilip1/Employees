// Employee filter that checks if the city in employee work address matches the specified city 

using Employees.Models;


namespace Employees.Services.Filters
{
    public class MatchByCity : IMatchEmployee
    {
        private string _city;

        public MatchByCity(string city)
        {
            _city = city;
        }

        public bool Match(Employee employee)
        {
            return employee.WorkAddress.City.ToLower() == _city.ToLower();
        }
    }
}
