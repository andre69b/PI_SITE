using System.Collections.Generic;
using LogicModelLibrary;

namespace LogicLibrary
{
    public interface IRealEstateLogic
    {
        IEnumerable<RealEstate> GetAll();
        RealEstate GeTById(int id);
        IEnumerable<RealEstate> GeTByUserName(string username);
        IEnumerable<RealEstate> GetRealEstateRegisterByUserNameGeTByUserName(string username);
        RealEstate AddRealEstate(RealEstate realEstate);
    }
}
