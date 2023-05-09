using System;
using System.Collections.Generic;

namespace HmoServer.Models;

public partial class CoronaDetail
{
    public DateTime? FirstVaccitionDate { get; set; }

    public DateTime? SecondVaccitionDate { get; set; }

    public DateTime? ThirdVaccitionDate { get; set; }

    public DateTime? ForthVaccitionDate { get; set; }

    public string? FirstVaccinationManufacturer { get; set; }

    public string? SecondVaccinationManufacturer { get; set; }

    public string? ThirdVaccinationManufacturer { get; set; }

    public string? ForthVaccinationManufacturer { get; set; }

    public DateTime? PositiveResultDate { get; set; }

    public DateTime? RecoveryDate { get; set; }

    public long CustomerId { get; set; }

    public int Id { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
