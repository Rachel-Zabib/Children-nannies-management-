using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public interface Idal
    {

        #region Child
        void Add_Child(BE.Child child1);
        bool Remove_Child(int id);
        void Update_Child(BE.Child child1);
        BE.Child Get_Child(int id);//our ,return child by his id
        IEnumerable<BE.Child> Get_All_Children(Func<BE.Child, bool> predicate = null);//our

        #endregion

        #region Mother
        void Add_Mother(BE.Mother mother1);
        bool Remove_Mother(int id);
        void Update_Mother(BE.Mother mother1);
        BE.Mother Get_Mother(int id);//our ,return mother by her id
        //IEnumerable<IGrouping<int, BE.Child>> Get_Children_By_Mothers();//groping children by their mothers
        //no neccesary can use predicat in all children//IEnumerable<BE.Child> Get_Children_By_Mom(int Mother_id);//groping all children of a mother
        IEnumerable<BE.Mother> GetAll_Mother(Func<BE.Mother, bool> predicate = null);//if null return all list of mothers
        #endregion mother

        #region Nanny
        void Add_Nanny(BE.Nanny nanny1);
        bool Remove_Nanny(int id);
        void Update_Nanny(BE.Nanny nanny1);
        BE.Nanny Get_Nanny(int id);//our ,return nanny by her id
        IEnumerable<BE.Nanny> GetAll_Nanny(Func<BE.Nanny, bool> predicate = null);//if null return all list of nanies
        #endregion

        #region Contract
        void Add_Contract(BE.Contract contract1);
        bool Remove_Contract(int counter);
        void Update_Contract(BE.Contract contract1);
        BE.Contract Get_Contract(int counter);//our ,return child by his id
        IEnumerable<BE.Contract> GetAll_Contract(Func<BE.Contract, bool> predicate = null);//if null return all list of contracts
        #endregion Contract
    }
}
