using System.Collections.Generic;
using netCoreRestApiEf.Model;

namespace netCoreRestApiEf.Data{

    public interface ISmartphoneRepo{

        bool saveChanges();

        IEnumerable<Smartphone> GetAllSmartphones();
        Smartphone GetSmartphoneById(int id);

        void CreateSmartphone(Smartphone smartphone);
        void UpdateSmartphone(Smartphone smartphone);

    }

}