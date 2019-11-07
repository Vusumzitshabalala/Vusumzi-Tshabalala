using HospitalManagementSystem.Logic;
using HospitalManagementSystem.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Helpers
{

    public class LookupHelper
    {
        public LookupHelper()
        {
            SelectedListItems = new List<SelectListItem>();
        }

        public List<SelectListItem> SelectedListItems { get; set; }

        //public void GetCategories(int selectedCategoryId)
        //{
        //    var service = new DomainService<Category>();
        //    var categories = service.GetEntities(c => c.Active, null);

        //    if (categories != null)
        //    {
        //        categories.ForEach(c => SelectedListItems.Add(new SelectListItem() { Value = c.Id.ToString(), Text = c.Name, Selected = c.Id == selectedCategoryId }));
        //    }
        //}

        //public void GetCategories(int selectedCategoryId, string defaultValue)
        //{
        //    SelectedListItems.Add(new SelectListItem() { Value = "0", Text = defaultValue, Selected = selectedCategoryId == 0 });
        //    GetCategories(selectedCategoryId);
        //}

        public void GetGenders(int selectedGenderId)
        {
            //var service = new DomainService<Gender>();
            //var genders = service.GetEntities(c => c.Active, null);

            //if (genders != null)
            //{
            //    genders.ForEach(c => SelectedListItems.Add(new SelectListItem() { Value = c.Id.ToString(), Text = c.Name, Selected = c.Id == selectedGenderId }));
            //}

            SelectedListItems.Add(new SelectListItem() { Value = "1", Text = "Male" });
            SelectedListItems.Add(new SelectListItem() { Value = "2", Text = "Female" });
        }

        public void GetGenders(int selectedGenderId, string defaultValue)
        {
            SelectedListItems.Add(new SelectListItem() { Value = "0", Text = defaultValue, Selected = selectedGenderId == 0 });
            GetGenders(selectedGenderId);
        }

        public void GetDoctors(int selectedDoctorId)
        {
            DoctorsRetriever doctorsRetriever = new DoctorsRetriever(new DoctorRepository());

            var doctors = doctorsRetriever.GetAllDoctors();

            if (doctors != null)
            {
                doctors.ForEach(c => SelectedListItems.Add(new SelectListItem() { Value = c.Id.ToString(), Text =  $"{c.Person.FirstName} {c.Person.Surname} ({c.PracticeNumber})"  , Selected = c.Id == selectedDoctorId }));
            }
        }

        public void GetDoctors(int selectedGenderId, string defaultValue)
        {
            SelectedListItems.Add(new SelectListItem() { Value = "0", Text = defaultValue, Selected = selectedGenderId == 0 });
            GetDoctors(selectedGenderId);
        }

        public void GetPatients(int selectedPatientId)
        {
            PatientsRetriever patientsRetriever = new PatientsRetriever(new PatientRepository());

            var doctors = patientsRetriever.GetAllPatients();

            if (doctors != null)
            {
                doctors.ForEach(c => SelectedListItems.Add(new SelectListItem() { Value = c.Id.ToString(), Text = $"{c.Person.FirstName} {c.Person.Surname} ({c.Person.Cellphone})", Selected = c.Id == selectedPatientId }));
            }
        }

        public void GetPatients(int selectedGenderId, string defaultValue)
        {
            SelectedListItems.Add(new SelectListItem() { Value = "0", Text = defaultValue, Selected = selectedGenderId == 0 });
            GetDoctors(selectedGenderId);
        }

        //public void GetCommunicationTypes(int selectedCommunicationTypeId)
        //{
        //    var service = new DomainService<CommunicationType>();
        //    var CommunicationTypes = service.GetEntities(c => c.Active, null);

        //    if (CommunicationTypes != null)
        //    {
        //        CommunicationTypes.ForEach(c => SelectedListItems.Add(new SelectListItem() { Value = c.Id.ToString(), Text = c.Name, Selected = c.Id == selectedCommunicationTypeId }));
        //    }
        //}

        //public void GetCommunicationTypes(int selectedCommunicationTypeId, string defaultValue)
        //{
        //    SelectedListItems.Add(new SelectListItem() { Value = "0", Text = defaultValue, Selected = selectedCommunicationTypeId == 0 });
        //    GetCommunicationTypes(selectedCommunicationTypeId);
        //}
    }
}