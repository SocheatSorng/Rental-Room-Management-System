using Microsoft.Data.SqlClient;

public interface IEntity
{
    int ID { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Sex { get; set; }
    DateTime BirthDate { get; set; }
    string Type { get; set; }
    string HouseNo { get; set; }
    string StreetNo { get; set; }
    string Commune { get; set; }
    string District { get; set; }
    string Province { get; set; }
    string PersonalNumber { get; set; }
    string ContactNumber { get; set; }
    double Salary { get; set; }
    DateTime Booking { get; set; }
    bool Status { get; set; }
    DateTime Start { get; set; }
    DateTime End { get; set; }
    string Description { get; set; }
    double CostPrice { get; set; }
    double RentPrice { get; set; }
    string Password { get; set; }
    void AddParameters(SqlCommand cmd);
    void AddParametersWithID(SqlCommand cmd);
    void AddOnlyIDParameter(SqlCommand cmd);
}