using System.Collections.Generic;
using netCoreRestApiEf.Model;

namespace netCoreRestApiEf.Data
{
    public class MockSmartphoneRepo : ISmartphoneRepo
    {
        public void CreateSmartphone(Smartphone smartphone)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Smartphone> GetAllSmartphones()
        {
            var Smartphones = new List<Smartphone>{
                new Smartphone{id = 0,manufacturer="Xiomi",color="blue",price=1200.00},
                new Smartphone{id = 1,manufacturer="Apple",color="white",price=4700.00},
                new Smartphone{id = 2,manufacturer="Sony",color="black",price=2300.00},
                new Smartphone{id = 3,manufacturer="LG",color="pink",price=1600.00},
            };

            return Smartphones;
        }

        public Smartphone GetSmartphoneById(int id)
        {
            return new Smartphone{id = 0,manufacturer="Xiomi",color="blue",price=1200.00};
        }

        public bool saveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateSmartphone(Smartphone smartphone)
        {
            throw new System.NotImplementedException();
        }
    }
}