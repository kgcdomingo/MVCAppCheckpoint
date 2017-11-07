using PhysicianDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhysicianDirectory.Controllers
{
    public class PhysicianController : Controller
    {
        // GET: Physician
        public ActionResult PersonalInformation()
        {
            var PerInfo = from e in physicians
                          orderby e.Id
                          select e;
            return View(PerInfo);



        }
        public ActionResult ContactInformation()
        {
            var ConInfo = from e in physicians
                          orderby e.Id
                          select e;
            return View(ConInfo);



        }
        public ActionResult SpecializationInformation()
        {
            var SpecInfo = from e in physicians
                           orderby e.Id
                           select e;
            return View(SpecInfo);



        }

        public static List<Physician> physicians = new List<Physician>()
       {
           
               new Physician
            {
                Id = 1, FirstName = "Kristhel", MiddleName = "Comin", LastName="Domingo", BirthDate= DateTime.Now, Gender="Male", Height= 171, Weight= 65,
                ContactInfo = new ContactInfo {Id = 1, HomeAddress= "Address", HomePhone = 099999, OfficeAddress="Office Address", OfficePhone= 0999, CellphoneNumber=0999, EmailAdd= "michael.dionglay@pointwest.com.ph"  }
                , Specialization = new Specialization { Id =1, Name="Opthalmologist", Description = "Opthalmologist Description"} },

             new Physician
            {
                Id = 2, FirstName = "Michael", MiddleName = "Marasigan", LastName="Dionglay", BirthDate= DateTime.Now, Gender="Male", Height= 171, Weight= 65,
                ContactInfo = new ContactInfo {Id = 2, HomeAddress= "Address", HomePhone = 099999, OfficeAddress="Office Address", OfficePhone= 0999, CellphoneNumber=0999, EmailAdd= "michael.dionglay@pointwest.com.ph"  }
                , Specialization = new Specialization { Id =2, Name="Opthalmologist", Description = "Opthalmologist Description"} },

             new Physician
            {
                Id = 3, FirstName = "Diana", MiddleName = "Reyes", LastName="Rosaroso", BirthDate= DateTime.Now, Gender="Male", Height= 171, Weight= 65,
                ContactInfo = new ContactInfo {Id = 3, HomeAddress= "Address", HomePhone = 09999, OfficeAddress="Office Address", OfficePhone= 0999, CellphoneNumber=0999, EmailAdd= "michael.dionglay@pointwest.com.ph"  }
                , Specialization = new Specialization { Id =3, Name="Opthalmologist", Description = "Opthalmologist Description"} }


           
       };
      


// GET: Employee/Edit/
public ActionResult Edit(ulong ID)
        {
            

            var per = physicians.Where(p => p.Id == ID).FirstOrDefault();
            return View(per);
            
        }
        [HttpPost]
        public ActionResult Edit(ulong ID, FormCollection collection)
        {
            try
            {
                var phy = physicians.Single(p => p.Id == ID);
                if (TryUpdateModel(phy))
                {
                    
                    return RedirectToAction("PersonalInformation");
                }
                return View(phy);
            }
            catch
            {
                return View();
            }
            
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }
        static Physician input = new Physician();
        static ContactInfo contact = new ContactInfo();
        static Specialization special = new Specialization();
        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, string next)
        {
            try
            {
                if (next != null)
                {
                    if (ModelState.IsValid)
                    {
                        if (physicians.Count > 0)
                        {
                            input.Id = physicians.Last().Id + 1;
                        }

                        else
                        {
                            input.Id = 1;
                        }

                        input.FirstName = collection["FirstName"];
                        input.MiddleName = collection["MiddleName"];
                        input.LastName = collection["LastName"];
                        DateTime BirthDate;
                        DateTime.TryParse(collection["BirthDate"], out BirthDate);
                        input.BirthDate = BirthDate;
                        
                        input.Gender = collection["Gender"];
                        string Height = collection["Height"];
                        input.Height = Int32.Parse(Height);
                        string Weight = collection["Weight"];
                        input.Weight = Int32.Parse(Weight);
                        
                        return RedirectToAction("Create1");

                    }

                }
                return View();
                    
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Create1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create1(FormCollection collection, string next)
        {
            try
            {
                if (next != null)
                {
                    if (ModelState.IsValid)
                    {
                        
                        contact.HomeAddress = collection["HomeAddress"];
                        string HomePhone = collection["HomePhone"];
                        contact.HomePhone = ulong.Parse(HomePhone);
                        contact.OfficeAddress = collection["OfficeAddress"];
                        string OfficePhone = collection["OfficePhone"];
                        contact.OfficePhone = ulong.Parse(OfficePhone);
                        contact.EmailAdd = collection["EmailAdd"];
                       
                        return RedirectToAction("Create2");
                        //
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Create2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create2(FormCollection collection, string next)
        {
            try
            {
                
                special.Name = collection["Name"];
                special.Description = collection["Description"];
                Physician phys = new Physician();

                phys.Id = input.Id;
                phys.FirstName = input.FirstName;
                phys.MiddleName = input.MiddleName;
                phys.LastName = input.LastName;
                phys.BirthDate = input.BirthDate;
                phys.Gender = input.Gender;
                phys.Height = input.Height;
                phys.Weight = input.Weight;

                phys.ContactInfo = new ContactInfo
                {
                    Id = input.Id,
                    HomeAddress = contact.HomeAddress,
                    HomePhone = contact.HomePhone,
                    OfficeAddress = contact.OfficeAddress,
                    OfficePhone = contact.OfficePhone,
                    EmailAdd = contact.EmailAdd,
                    CellphoneNumber = contact.CellphoneNumber
                };
                phys.Specialization = new Specialization
                {
                    Id = input.Id,
                    Name = special.Name,
                    Description = special.Description
                };
                physicians.Add(phys);
                ViewBag.result = "Record Inserted Successfully!";
                return RedirectToAction("PersonalInformation");
                
            }
              
            catch
            {
                return View();
            }
        }
       
        // GET: Employee/Delete/5
        public ActionResult Delete(ulong ID)
        {
            var del = physicians.Where(p => p.Id == ID).FirstOrDefault();
            return View(del);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(ulong ID, FormCollection collection)
        {
            try
            {
                var per = physicians.FirstOrDefault(p => p.Id == ID);
                
                physicians.Remove(per);
                
                return RedirectToAction("PersonalInformation");
            }
            
            catch
            {
                return View();
            }
        }

    }

}