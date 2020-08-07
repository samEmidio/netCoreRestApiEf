using System;
using System.Collections.Generic;
using System.Linq;
using netCoreRestApiEf.Model;

namespace netCoreRestApiEf.Data
{

    public class SqlSmartphoneRepo : ISmartphoneRepo
    {

        private readonly SmartphoneContext _context;

        public SqlSmartphoneRepo(SmartphoneContext context)
        {
            _context = context;
        }

        public void CreateSmartphone(Smartphone smartphone)
        {
            if(smartphone == null)
            {
                throw new ArgumentNullException(nameof(smartphone));
            }

            _context.Smartphones.Add(smartphone);
        }

        public IEnumerable<Smartphone> GetAllSmartphones()
        {
            return _context.Smartphones.ToList();
        }

        public Smartphone GetSmartphoneById(int id)
        {
            return _context.Smartphones.FirstOrDefault(x => x.id == id);
        }

        public bool saveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSmartphone(Smartphone smartphone)
        {
            throw new NotImplementedException();
        }
    }



}