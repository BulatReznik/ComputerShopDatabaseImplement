using ComputerShopContracts.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShopContracts.BusinessLogicsContracts
{
    public interface IPersonalBuildLogic
    {
        //List<PersonalBuildViewModel> Read(PersonalBuildBindingModel model);
        void CreateOrUpdate(PersonalBuildBindingModel model);
        void Delete(PersonalBuildBindingModel model);
    }
}
