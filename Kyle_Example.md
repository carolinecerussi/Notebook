PROJECT_NAME / VIEWS / PATIENTS (notes) / INDEX

@{
  Layout = "_Layout";
}

@using PatientTracker.Models;
@model List<PatientTracker.Models.Patient>;

<h1>Patients</h1>

@if (@Model.Count == 0)
{
  <h3>No patients have been added yet!</h3>
} 

@foreach (Patient patient in Model)
{
  <li>@Html.ActionLink($"{patient.Description}", "Details", new { id = patient.PatientId })</li>
}

<p>@Html.ActionLink("Add new patient", "Create")</p>

____________________________________________________

PatientTracker/Views/Patients/Create.cshtml

@{
  Layout = "_Layout";
}

@model PatientTracker.Models.Patient

<h4>Add a new task</h4>

@using (Html.BeginForm())
{
  @Html.LabelFor(model => model.Description)
  @Html.TextBoxFor(model => model.Description)

  @Html.LabelFor(m => m.Birthdate)
  @Html.TextBoxFor(m => m.Birthdate, new {type="date", @class="form-control"})


  @Html.Label("Select doctor")
  @Html.DropDownList("DoctorId")


  <input type="submit" value="Add new patient" class="btn btn-default" />
}
<p>@Html.ActionLink("Show all patients", "Index")</p>