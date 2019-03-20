using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Converters
{
    public static class ExtensionToSubject
    {
        public static Subject ToSubject(this SubjectDTO predmet)
        { return new Subject {
            SubjectID = predmet.SubjectID,
            SubjectName = predmet.SubjectName,
            ClassesPerWeek =predmet.ClassesPerWeek,
        }; } } }
           



        //var predmet = new PredmetDTO("1", "Matematika6");
        //var predmet1 = predmet.ToSubject();


    
        
    
