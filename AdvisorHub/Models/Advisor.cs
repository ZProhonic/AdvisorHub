using System;
using System.Collections.Generic;

namespace AdvisorHub.Models;

public partial class Advisor
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Licenses { get; set; }

    public int? Crd { get; set; }

    public string? RepId { get; set; }

    public string? Osj { get; set; }

    public string? NonOsj { get; set; }

    public string? EmailAddress { get; set; }

    public bool? IsHybrid { get; set; }

    public string? Last4Ssn { get; set; }

    public string? AdditionalRepIds { get; set; }

    public string? StateRegistrations { get; set; }

    public string? RiaId { get; set; }

    public string? RiaName { get; set; }
}
