using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {

        #region Child
        void Add_Child(BE.Child child1);
        bool Remove_Child(int id);
        void Update_Child(BE.Child child1);
        BE.Child Get_Child(int id);//our ,return child by his id
        IEnumerable<BE.Child> Get_All_Children(Func<BE.Child, bool> predicate = null);//our return all children or by condition
        IEnumerable<Child> children_without_nanny();

        #endregion

        #region Mother
        void Add_Mother(BE.Mother mother1);
        bool Remove_Mother(int id);
        void Update_Mother(BE.Mother mother1);
        BE.Mother Get_Mother(int id);//our ,return mother by her id
        IEnumerable<BE.Mother> GetAll_Mother(Func<BE.Mother, bool> predicate = null);//if null return all list of mothers
       // IEnumerable<IGrouping<int, BE.Child>> Get_Children_By_Mothers();//groping children by their mothers
        //not neccesery IEnumerable<BE.Child> Get_Children_By_Mom(int Mother_id);//groping all children of a mother
        #endregion

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
        BE.Contract Get_Contract(int counter);//our ,return contract by his counter
        IEnumerable<BE.Contract> GetAll_Contract(Func<BE.Contract, bool> predicate = null);//if null return all list of contracts
        #endregion Contract

        #region calculates_and_more
        /// <summary>
        /// calaculate final salary after discount
        /// </summary>
        /// <param name="con"></param>
        /// <param name="nan"></param>
        /// <param name="ch"></param>
        void Calculate_Salary(Contract con, Nanny nan, Child ch);
        /// <summary>
        /// find the closest nannies by the time our priority is same days and then same hours
        /// </summary>
        /// <param name="mom_id"></param>
        /// <returns></returns>
        IEnumerable<Nanny> find_nanny_byTime(int mom_id);
        /// <summary>
        /// find the closest nannies by the distance from adress mom put,if she doesnt put we check in range of 10 km from home(take by car) or 1 km from home(take by leg)
        /// </summary>
        /// <param name="mother_id"></param>
        /// <returns></returns>
        IEnumerable<Nanny> match_byKM(int mother_id);
        /// <summary>
        /// return all nannies that take vacations by TMT
        /// </summary>
        /// <returns></returns>
        IEnumerable<Nanny> vacation_TMT();
        /// <summary>
        /// //return how many contracts are matching to condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int num_condition_contracts(Func<Contract, bool> predicate = null);
        /// <summary>
        /// makes groups of nannies by the age they take
        /// </summary>
        /// <param name="by_max_age"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, Nanny>> nannies_by_children_age(bool by_max_age, bool sort = false);
        /// <summary>
        /// makes groups of contracts by the distance between nanny and adress mom put,if she didnt put we check from home
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, Contract>> contracts_by_km(bool sort = false);
        /// <summary>
        /// return all birthdays in nanny
        /// </summary>
        /// <param name="nanny_id"></param>
        /// <returns></returns>
        string birthdays_in_nanny(int nanny_id);
        /// <summary>
        /// return phonebook of all children in nanny
        /// </summary>
        /// <param name="nanny_id"></param>
        /// <returns></returns>
        string phonebook_for_nanny(int nanny_id);
        /// <summary>
        /// return phonebook of all children in my child's nanny and the nanny herself
        /// </summary>
        /// <param name="child_id"></param>
        /// <returns></returns>
        string phonebook_for_mother(int child_id);
        /// <summary>
        /// return all allergics in nanny and their allergies
        /// </summary>
        /// <param name="nanny_id"></param>
        /// <returns></returns>
        string all_allergies_in_nanny(int nanny_id);
        /// <summary>
        ///mom gives name of nanny and get all phones of mothrs of this nanny,good for asking recommendations
        /// </summary>
        /// <param name="nanny_name"></param>
        /// <param name="nanny_family_name"></param>
        /// <returns></returns>
        string phones_for_recommendations(string nanny_name, string nanny_family_name);
        /// <summary>
        /// return all the best matches nannies by our priority:time,distance,religious,salary,smoking,food,experience
        /// </summary>
        /// <param name="mom_id"></param>
        /// <returns></returns>
        IEnumerable<Nanny> best_match(int mom_id);
  

        #endregion calculates_and_more
    }
}
