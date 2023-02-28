using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.ViewModels
{
    internal class SelfEstimationViewModel
    {
        public List<SelfEstimation> SelfEstimationQuestions { get; set; }

        //public SelfEstimationViewModel()
        //{
        //    var task = Task.Run(() => Helpers.FileManager.SplitFileToStringListAsync("skattning.txt"));
        //    task.Wait();
        //    SelfEstimationQuestions = task.Result;
        //}
    
    }
}
