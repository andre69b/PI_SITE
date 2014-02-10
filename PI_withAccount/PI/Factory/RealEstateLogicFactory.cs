using LogicLibrary;

namespace Factory
{
    public class RealEstateLogicFactory
    {
        private static readonly IRealEstateLogic RealEstateLogic =  new RealEstateLogic();
                                                                //new DalRealEstateLogic(new MemoryRealEstateDal());
        public static  IRealEstateLogic GetInstance()
        {
            return RealEstateLogic;
        }
    }
}