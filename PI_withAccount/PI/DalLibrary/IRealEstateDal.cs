using System.Collections.Generic;
using LogicModelLibrary;

namespace DalLibrary
{
    public interface IRealEstateDal
    {
        IEnumerable<RealEstate> GetAll();
        RealEstate GeTById(int id);
        IEnumerable<RealEstate> GeTByUserName(string username);
        IEnumerable<RealEstate> GetRealEstateRegisterByUserNameGeTByUserName(string username);
        RealEstate Add(RealEstate realEstate);
    }
}
