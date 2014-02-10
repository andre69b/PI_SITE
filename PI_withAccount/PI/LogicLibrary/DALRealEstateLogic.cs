using System.Collections.Generic;
using LogicModelLibrary;
using DalLibrary;

namespace LogicLibrary
{
    public class DalRealEstateLogic : IRealEstateLogic
    {
        private readonly IRealEstateDal _dal;

        public DalRealEstateLogic(IRealEstateDal dal)
        {
            _dal = dal;
        }

        public IEnumerable<RealEstate> GetAll()
        {
            return _dal.GetAll();
        }

        public RealEstate GeTById(int id)
        {
            return _dal.GeTById(id);
        }

        public IEnumerable<RealEstate> GeTByUserName(string username)
        {
            return _dal.GeTByUserName(username);
        }

        public IEnumerable<RealEstate> GetRealEstateRegisterByUserNameGeTByUserName(string username)
        {
            return _dal.GetRealEstateRegisterByUserNameGeTByUserName(username);
        }

        public RealEstate AddRealEstate(RealEstate realEstate)
        {
            // Validate realEstate

           return _dal.Add(realEstate);
        }
    }
}
