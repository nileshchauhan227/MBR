using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO.Interface;
using POS.DTO;
using POS.DAL;

namespace POS.BAL
{
    public class clsBInward
    {
        public static List<PurchaseMasterDTO> GetAll()
        {
            using (clsDInward objDal = new clsDInward())
            {
                return objDal.GetAll();
            }
        }

        public static long Create(PurchaseMasterDTO obj)
        {
            using (clsDInward objDal = new clsDInward())
            {
                return objDal.Create(obj);
            }
        }

        public static PurchaseMasterDTO GetByID(long key)
        {
            using (clsDInward objDal = new clsDInward())
            {
                return objDal.GetByID(key);
            }
        }

        public static bool Update(PurchaseMasterDTO obj)
        {
            using (clsDInward objDal = new clsDInward())
            {
                return objDal.Update(obj);
            }
        }

        public static bool Delete(long key)
        {
            using (clsDInward objDal = new clsDInward())
            {
                return objDal.Delete(key);
            }
        }

        public static PurchaseMasterDTO GetPrevious(long key)
        {
            using (clsDInward objDal = new clsDInward())
            {
                return objDal.GetPrevious(key);
            }
        }

        public static PurchaseMasterDTO GetNext(long key)
        {
            using (clsDInward objDal = new clsDInward())
            {
                return objDal.GetNext(key);
            }
        }

        public static PurchaseMasterDTO GetFirst(long key)
        {
            using (clsDInward objDal = new clsDInward())
            {
                return objDal.GetFirst(key);
            }
        }

        public static PurchaseMasterDTO GetLast(long key)
        {
            using (clsDInward objDal = new clsDInward())
            {
                return objDal.GetLast(key);
            }
        }

        public static int GetNextInwardNumber()
        {
            using (clsDInward objDal = new clsDInward())
            {
                return objDal.GetNextInwardNumber();
            }
        }
    }
}
