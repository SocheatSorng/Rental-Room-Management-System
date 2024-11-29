using Microsoft.Data.SqlClient;

public class Policy : IEntity
{
    // Original properties
    public int PolID { get; set; }
    public string? PolName { get; set; }
    public string? Des { get; set; }
    public DateTime CreDate { get; set; }
    public DateTime? UpdDate { get; set; }
    public int ResiID { get; set; }
    public string? ResiName { get; set; }

    // Implementing applicable interface members
    public int ID { get => PolID; set => PolID = value; }
    public string FirstName { get => PolName ?? string.Empty; set => PolName = value; }
    public string Description { get => Des ?? string.Empty; set => Des = value; }
    public DateTime Start { get => CreDate; set => CreDate = value; }
    public DateTime End { get => UpdDate ?? DateTime.MinValue; set => UpdDate = value; }

    // Not applicable properties
    public string LastName { get => string.Empty; set => throw new NotSupportedException(); }
    public string Sex { get => string.Empty; set => throw new NotSupportedException(); }
    public DateTime BirthDate { get => DateTime.MinValue; set => throw new NotSupportedException(); }
    public string Type { get => string.Empty; set => throw new NotSupportedException(); }
    public string HouseNo { get => string.Empty; set => throw new NotSupportedException(); }
    public string StreetNo { get => string.Empty; set => throw new NotSupportedException(); }
    public string Commune { get => string.Empty; set => throw new NotSupportedException(); }
    public string District { get => string.Empty; set => throw new NotSupportedException(); }
    public string Province { get => string.Empty; set => throw new NotSupportedException(); }
    public string PersonalNumber { get => string.Empty; set => throw new NotSupportedException(); }
    public string ContactNumber { get => string.Empty; set => throw new NotSupportedException(); }
    public double Salary { get => 0; set => throw new NotSupportedException(); }
    public DateTime Booking { get => DateTime.MinValue; set => throw new NotSupportedException(); }
    public bool Status { get => false; set => throw new NotSupportedException(); }
    public double CostPrice { get => 0; set => throw new NotSupportedException(); }
    public double RentPrice { get => 0; set => throw new NotSupportedException(); }
    public string Password { get => string.Empty; set => throw new NotSupportedException(); }

    public void AddParameters(SqlCommand cmd)
    {
        cmd.Parameters.AddWithValue("@PolName", PolName as object ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Des", Des as object ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@CreDate", CreDate as object ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@UpdDate", UpdDate as object ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ResiID", ResiID as object ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ResiName", ResiName as object ?? DBNull.Value);
    }

    public void AddParametersWithID(SqlCommand cmd)
    {
        cmd.Parameters.AddWithValue("@PolID", PolID);
        cmd.Parameters.AddWithValue("@PolName", PolName as object ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Des", Des as object ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@CreDate", CreDate as object ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@UpdDate", UpdDate as object ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ResiID", ResiID as object ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ResiName", ResiName as object ?? DBNull.Value);
    }

    public void AddOnlyIDParameter(SqlCommand cmd)
    {
        cmd.Parameters.AddWithValue("@PolID", PolID);
    }
}