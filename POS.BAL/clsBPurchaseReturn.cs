using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POS.DTO;
using POS.DAL;

namespace POS.BAL
{
    public class clsBPurchaseReturn
    {
        public static List<PurchaseReturnMasterDTO> GetAll()
        {
            using (clsDPurchaseReturn objDal = new clsDPurchaseReturn())
            {
                return objDal.GetAll();
            }
        }

        public static long Create(PurchaseReturnMasterDTO obj)
        {
            using (clsDPurchaseReturn objDal = new clsDPurchaseReturn())
            {
                return objDal.Create(obj);
            }
        }

        public static PurchaseReturnMasterDTO GetByID(long key)
        {
            using (clsDPurchaseReturn objDal = new clsDPurchaseReturn())
            {
                return objDal.GetByID(key);
            }
        }

        public static bool Update(PurchaseReturnMasterDTO obj)
        {
            using (clsDPurchaseReturn objDal = new clsDPurchaseReturn())
            {
                return objDal.Update(obj);
            }
        }

        public static bool Delete(long key)
        {
            using (clsDPurchaseReturn objDal = new clsDPurchaseReturn())
            {
                return objDal.Delete(key);
            }
        }

        public static PurchaseReturnMasterDTO GetPrevious(long key)
        {
            using (clsDPurchaseReturn objDal = new clsDPurchaseReturn())
            {
                return objDal.GetPrevious(key);
            }
        }

        public static PurchaseReturnMasterDTO GetNext(long key)
        {
            using (clsDPurchaseReturn objDal = new clsDPurchaseReturn())
            {
                return objDal.GetNext(key);
            }
        }

        public static PurchaseReturnMasterDTO GetFirst(long key)
        {
            using (clsDPurchaseReturn objDal = new clsDPurchaseReturn())
            {
                return objDal.GetFirst(key);
            }
        }

        public static PurchaseReturnMasterDTO GetLast(long key)
        {
            using (clsDPurchaseReturn objDal = new clsDPurchaseReturn())
            {
                return objDal.GetLast(key);
            }
        }
    }
}
